using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.LGA;
using api.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    
    public class LGARepository : ILGARepository
    {
        private readonly SchoolPortalContext _context;
        public LGARepository(SchoolPortalContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public async Task<List<LgaDTO>> GetLGAByStateIDAsync(int stateId)
        {
            var StateIdIdParam = new SqlParameter("@stateID",stateId);
            var lga =  await _context.LGA.FromSqlRaw("EXEC GetLGA @stateID", StateIdIdParam).ToListAsync();
            if(lga is null){
                return null;
            }
            return lga;
        }
    }
}