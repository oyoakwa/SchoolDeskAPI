using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Class;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _repo;

        public ClassController(IClassRepository repo)
        {
            _repo = repo ?? throw new NullReferenceException(nameof(repo));
        }

        [HttpGet]
        [Route("{schoolId}")]
        public async Task<ActionResult<ClassDTO>> GetClassBySchoolIdAsync([FromRoute] string schoolId)
        {
            var clas = await _repo.GetClassesBySchoolIDAsync(schoolId);
            return Ok(clas);
        }
    }
}