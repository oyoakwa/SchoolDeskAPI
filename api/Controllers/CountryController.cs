using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Country;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _repo;
        public CountryController(ICountryRepository repo)
        {
            _repo = repo ?? throw new NullReferenceException(nameof(repo));
        }


        [HttpGet]
        public async Task<ActionResult<CountryDTO>> GetAll()
        {
            var countries = await _repo.GetCountriesAsync();
            return Ok(countries);
        }
    }
}