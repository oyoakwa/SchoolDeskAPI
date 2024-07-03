using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.States;
using api.Interfaces;
using api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly SchoolPortalContext _context;

        public StateRepository(SchoolPortalContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }
        public async Task<List<StateDTO>> GetStateByCountryIDAsync(int countryId)
        {
            var countIdIdParam = new SqlParameter("@CountryID",countryId);
            var states =  await _context.StateDTO.FromSqlRaw("EXEC GetState @CountryID", countIdIdParam).ToListAsync();
            if(states is null){
                return null;
            }
            return states;
        }

        
    }
}