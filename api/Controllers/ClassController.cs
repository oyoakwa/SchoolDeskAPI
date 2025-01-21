using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Class;
using api.Interfaces;
using api.Mappers;
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
        public async Task<ActionResult<List<ClassDTO>>> GetClassBySchoolIdAsync([FromRoute] string schoolId)
        {
            var clas = await _repo.GetClassesBySchoolIDAsync(schoolId);
            return Ok(clas);
        }
/// <summary>
/// I will have to create a controller that retuns one class and use it in the CreatedAtRoute value
/// </summary>
/// <param name="classCreateDTO"></param>
/// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> CreateClassAsync([FromBody] ClassForCreationDTO classCreateDTO)
        {
            var klas = await _repo.CreateClass(classCreateDTO);
            return Ok(klas);
        }

        [HttpDelete]
        [Route("{classId}")]
        public async Task<int> Delete([FromRoute] int classId)
        {
            var clas = await _repo.DeleteAsync(classId);
            if(clas < 1)
            {
                return 0;
            }

            return clas;
        }

    }
}