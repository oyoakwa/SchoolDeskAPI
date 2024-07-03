using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Schools;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolPortalContext _context;
        public SchoolRepository(SchoolPortalContext context)
        {
            _context = context;
        }

        public async Task<SchoolAdminRegistration?> CreateAsync(SchoolForCreationDTO creationDTO)
        {
            var school = creationDTO.ToSchoolFromSchoolCreatDTO();
            school.RegistrationDate = DateTimeOffset.UtcNow;

            var schoolIdParam = new SqlParameter("@SchoolId", school.SchoolId);
            var userIdParam = new SqlParameter("@UserId",Guid.NewGuid());
            var schoolNameParam = new SqlParameter("@SchoolName",school.SchoolName);
            var adminSurnameparam = new SqlParameter("@AdminSurName",school.AdminSurName);
            var adminOtherNamesParam = new SqlParameter("@AdminOtherNames",school.AdminOtherNames);
            var streetNameParam = new SqlParameter("@StreetName",school.StreetName);
            var lgaIdParam = new SqlParameter("@LgaId", school.LgaId);
            var regDateParam = new SqlParameter("@RegistrationDate", school.RegistrationDate);
            var schoolTelParam = new SqlParameter("@SchoolPhoneNumber",school.SchoolPhoneNumber);
            var schoolEmailParam = new SqlParameter("@SchoolEmailAdress", school.SchoolEmailAdress);
            var schoolPostalCodeParam = new SqlParameter("@SchoolPostalCode", school.SchoolPostalCode);
            var genderParamParam = new SqlParameter("@Gender", school.Gender);

            int rowsAffected = await _context.Database.ExecuteSqlRawAsync("EXEC RegisterNewSchoolAdmin @SchoolId,@UserId,@SchoolName,@AdminSurName,@AdminOtherNames,@StreetName,@LgaId,@RegistrationDate,@SchoolPhoneNumber,@SchoolEmailAdress,@SchoolPostalCode,@Gender",
            schoolIdParam,userIdParam,schoolNameParam,adminSurnameparam,adminOtherNamesParam,streetNameParam,lgaIdParam,regDateParam,schoolTelParam,
            schoolEmailParam,schoolPostalCodeParam,genderParamParam);

            if(rowsAffected<1){
                throw new Exception("Error while creating resources.");
            }
            return school;
        }

        public async Task<string?> DeleteAsync(string schoolId)
        {
            var school = await _context.SchoolAdminRegistrations.FirstOrDefaultAsync(x => x.SchoolId == schoolId);
            if(school is null)
            {
                return null;
            }

            _context.SchoolAdminRegistrations.Remove(school);
            await _context.SaveChangesAsync();

            return school.SchoolId;
        }

        public async Task<List<CustomSchoolFromSPDTO>> GetAllAsync()
        {
            return await _context.CustomSchoolResults.FromSqlRaw("EXEC SelectSchoolAdmins").ToListAsync();
        }

        public async Task<SchoolAdminRegistration?> GetByIdAsync(string Id)
        {
            return await _context.SchoolAdminRegistrations.FindAsync(Id);
        }

        public async Task<SchoolAdminRegistration?> UpdateAsync(string schoolId, UpdateSchoolRequestDTO schoolDTO)
        {
            var school = await _context.SchoolAdminRegistrations.FirstOrDefaultAsync(s => s.SchoolId == schoolId);
            if(school is null)
            {
                return null;
            }

            school.SchoolName = schoolDTO.SchoolName;
            school.AdminOtherNames = schoolDTO.AdminOtherNames;
            school.AdminSurName = schoolDTO.AdminSurName;
            school.StreetName= schoolDTO.StreetName;
            school.LgaId = schoolDTO.LgaId;
            school.SchoolPhoneNumber = schoolDTO.SchoolPhoneNumber;
            school.SchoolEmailAdress = schoolDTO.SchoolEmailAdress;
            school.SchoolPostalCode = schoolDTO.SchoolPostalCode;
            school.Gender = schoolDTO.Gender;
            school.LastEditedOn = DateTimeOffset.UtcNow;

             await _context.SaveChangesAsync();
             return school;
        }
    }
}