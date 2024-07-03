using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.LGA;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LGAController : ControllerBase
    {
        private readonly ILGARepository _repo;
        public LGAController(ILGARepository repo)
        {
            _repo = repo ;
        }

        [HttpGet]
        [Route("{stateId}")]
        public async Task<ActionResult<LgaDTO>> GetByStateId([FromRoute] int stateId)
        {
            var lgas = await _repo.GetLGAByStateIDAsync(stateId);
            return Ok(lgas);
        }
    }
}