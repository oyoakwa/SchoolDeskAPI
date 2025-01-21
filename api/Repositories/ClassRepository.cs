using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Class;
using api.Interfaces;
using api.Mappers;
using api.Models;
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

        public async Task<int> CreateClass(ClassForCreationDTO clas){
            var klas = clas.ToBaseFromCreationDTO();
            var schoolIdParam = new SqlParameter("@SchoolId",klas.SchoolId);
            var classParam = new SqlParameter("@class",klas.Class);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync("EXEC InsertClasses @class, @schoolId", classParam, schoolIdParam);
            if(rowsAffected<1){
                throw new Exception("Error while creating resources. Make sure class does not already exist");
            }
            return rowsAffected;
        }

        public async Task<int> DeleteAsync(int classId)
        {
            var clas= await _context.ClassesTables.FirstOrDefaultAsync(c=>c.ClassId == classId);
            if(clas == null)
            {
                return 0;
            }
            _context.ClassesTables.Remove(clas);
            await _context.SaveChangesAsync();

            return clas.ClassId;
        }
    }
}