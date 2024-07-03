using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.States;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StateController : ControllerBase
    {

        private readonly IStateRepository _repo;
        public StateController(IStateRepository repo)
        {
            _repo = repo ?? throw new NullReferenceException(nameof(repo));
        }

        [HttpGet]
        [Route("{countryId}")]
        public async Task<ActionResult<StateDTO>> GetByCountryId([FromRoute] int countryId)
        {
            var states = await _repo.GetStateByCountryIDAsync(countryId);
            return Ok(states);
        }
    }
}