using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Test;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _repo;
        private readonly SchoolPortalContext _context;

        public TestController(ITestRepository repo, SchoolPortalContext context)
        {
            _context = context ;
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<TestForDisplayDTO>> InsertTest(TestForCreationDTO test)
        {
            var testResult = await _repo.InsertTest(test);
            if(String.IsNullOrEmpty(testResult.FirstName))
            {
                return BadRequest();
            }
            var testViewObject = testResult.ToDisplayFromBase();
            return Ok(testViewObject);
        }

        
    }
}