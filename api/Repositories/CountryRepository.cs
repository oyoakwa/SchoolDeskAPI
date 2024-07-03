using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Country;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SchoolPortalContext _context;
        public CountryRepository(SchoolPortalContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }
        public async Task<List<CountryDTO>> GetCountriesAsync()
        {
             var countries =  await _context.Nations.FromSqlRaw("EXEC GetNation").ToListAsync();
            return countries;
        }
    }
}