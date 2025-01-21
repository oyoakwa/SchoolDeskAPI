using api.Data;
using api.DTOs.Students;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        private readonly SchoolPortalContext _context;

        public StudentController(IStudentRepository repo, SchoolPortalContext context)
        {
            _context = context ;
            _repo = repo;
        }

        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetStudentsBySchoolId([FromRoute] string schoolId)
        {
            var students = await _repo.GetAllStudentFromSchool(schoolId);
            if(students is null){
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("rollId/{studentId}")]
        public async Task<ActionResult<StudentForSelectDTO>> GetStudentsByStudentId([FromRoute] string studentId)
        {
            var student = await _repo.GetStudentByStudentRollNumber(studentId);
            if(student is null){
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentForSelectDTO>> CreateStudent([FromBody] StudentForCreatDTO student){
            var studs = await _repo.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudentsByStudentId), new{studentId = student.StudentRollNumber}, studs);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateStudent(string id, [FromBody] JsonPatchDocument<StudentForUpdateDTO> patchObj){
            if(patchObj is null){
                return BadRequest();
            }

            var student = await _repo.GetBaseStudentByStudentRollNumber(id);
            if(student is null){
                return NotFound();
            }
            var studForUpdate = student.ToUpdateFromBaseObject();
            patchObj.ApplyTo(studForUpdate,ModelState); 
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var studentBaseObj = studForUpdate.ToBaseFromUpdateObject(student);
            studentBaseObj.StudentRollNumber = student.StudentRollNumber;
            _context.StudentRegTabs.Add(studentBaseObj);
            _context.Entry(studentBaseObj).State = EntityState.Modified;
            _context.Entry(studentBaseObj).Property(s => s.StudentIdS).IsModified = false;
            await _context.SaveChangesAsync();
           
            return Ok(studForUpdate);
        }

    }
}