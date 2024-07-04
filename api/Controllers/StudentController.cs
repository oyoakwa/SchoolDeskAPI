using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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

    }
}