using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Schools;
using api.Models;

namespace api.Interfaces
{
    public interface ISchoolRepository
    {
        Task<List<CustomSchoolFromSPDTO>> GetAllAsync();
        Task<SchoolAdminRegistration?> GetByIdAsync(string Id);
        Task<SchoolAdminRegistration?> CreateAsync(SchoolForCreationDTO creationDTO);
        Task<SchoolAdminRegistration?> UpdateAsync(string schoolId, UpdateSchoolRequestDTO requestDTO);
        Task<string?> DeleteAsync(string schoolId);
    }
}