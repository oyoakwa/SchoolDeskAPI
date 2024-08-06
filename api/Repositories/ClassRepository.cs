using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Class;
using api.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ClassRepository : IClassRepository
    {
         private readonly SchoolPortalContext _context;
        public ClassRepository(SchoolPortalContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }
        public async Task<List<ClassDTO>> GetClassesBySchoolIDAsync(string schoolId)
        {
             var schoolIdParam = new SqlParameter("@SchoolId",schoolId);
            var clas =  await _context.ClassDTO.FromSqlRaw("EXEC GettClasses @SchoolId", schoolIdParam).ToListAsync();
            if(clas is null){
                return null;
            }
            return clas;
        }
    }
}