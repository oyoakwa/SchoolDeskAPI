using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Schools;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/school")]
    [ApiController]
    public class SchoolRegistrationController:ControllerBase
    {
        private readonly ISchoolRepository _schRepo;
        private readonly SchoolPortalContext _context;
        public SchoolRegistrationController(SchoolPortalContext context, ISchoolRepository schRepo)
        {
            _context = context ;
            _schRepo = schRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schoolAdmins = await _schRepo.GetAllAsync();
            return Ok(schoolAdmins);
        }

        [HttpGet("{schoolId}")]
        public async  Task<IActionResult> GetBySchoolId([FromRoute] string schoolId)
        {
            var schoolAdmin = await _schRepo.GetByIdAsync(schoolId);
            if(schoolAdmin is null){
                return NotFound();
            }
            return Ok(schoolAdmin.ToSchoolDTO());
        }

        [HttpPost]
        public async Task<ActionResult<SchoolDTO>> CreateSchool([FromBody] SchoolForCreationDTO schoolDTO)
        {
            var school = await _schRepo.CreateAsync(schoolDTO);
            return CreatedAtAction(nameof(GetBySchoolId), new {schoolId = school.SchoolId}, school.ToSchoolDTO() );
        }

        [HttpPut]
        [Route("{schoolId}")]
        public async Task<IActionResult> Update([FromRoute] string schoolId, [FromBody] UpdateSchoolRequestDTO schoolDTO)
        {
            var school = await _schRepo.UpdateAsync(schoolId,schoolDTO);
            if(school is null){
                return NotFound();
            }
            return Ok(school.ToSchoolDTO());
        }

        [HttpDelete]
        [Route("{schoolId}")]
        public async Task<IActionResult> Delete([FromRoute] string schoolId)
        {
            var school = await _schRepo.DeleteAsync(schoolId);
            if(school is null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}