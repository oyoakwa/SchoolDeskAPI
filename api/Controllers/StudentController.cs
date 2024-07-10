using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Students;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("/rollId/{studentId}")]
        public async Task<IActionResult> GetStudentsByStudentId([FromRoute] string studentId)
        {
            var student = await _repo.GetStudentByStudentRollNumber(studentId);
            if(student is null){
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentForCreatDTO student){
            var studs = await _repo.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudentsByStudentId), new{studentId = student.StudentRollNumber}, studs);
        }

    }
}