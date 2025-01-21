using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Arms;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmsController : ControllerBase
    {
        //private readonly ILogger<ArmsController> _logger;
        private readonly IArmsRepository _repo;

        public ArmsController( IArmsRepository repo)
        {
            //_logger = logger;
            _repo = repo ?? throw new NullReferenceException(nameof(repo));
        }
        
        [HttpGet]
        [Route("{schoolId}")]
        public async Task<IActionResult> GetBySchoolId([FromRoute] string schoolId)
        {
            var arms = await _repo.GetBySchoolIdAsync(schoolId);
            return Ok(arms);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArmsForCreationDTO armsDto)
        {
            var s = await _repo.CreateAsync(armsDto);
            return Ok(s);
        }

        [HttpDelete]
        [Route("{armid}")]
        public async Task<int> Delete([FromRoute] int armid ){
            int arm = await _repo.DeleteAsync(armid);
            if(arm < 1)
            {
                return 0;
            }

            return arm;
        }
    }
}