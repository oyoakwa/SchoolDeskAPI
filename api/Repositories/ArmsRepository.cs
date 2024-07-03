using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Arms;
using api.Interfaces;
using api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using api.Mappers;

namespace api.Repositories
{
    public class ArmsRepository :IArmsRepository
    {
        private readonly SchoolPortalContext _context;
        public ArmsRepository(SchoolPortalContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public async Task<ArmsTable?> CreateAsync(ArmsForCreationDTO armsDTO)
        {
            var arm = armsDTO.ToArmsFromCreationDTO();
            var schIdParam = new SqlParameter("@SchoolId",arm.SchoolId);
            var armparam = new SqlParameter("@arms",arm.Arm);
            int rowsAffected = await _context.Database.ExecuteSqlRawAsync("EXEC InsertSchoolArm @arms, @SchoolId",armparam,schIdParam);

            if(rowsAffected < 1)
                throw new Exception("Error while creating Resources");
            
            return arm;
        }

        public async Task<List<ArmsDTO>> GetBySchoolIdAsync(string schoolId)
        {
            var schIdParam = new SqlParameter("@SchoolId",schoolId);
            var arms =  await _context.Arms.FromSqlRaw("EXEC GetArns @SchoolId", schIdParam).ToListAsync();
            return arms;
        }
    }
}