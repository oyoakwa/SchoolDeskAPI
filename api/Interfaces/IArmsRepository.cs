using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Arms;
using api.Models;

namespace api.Interfaces
{
    public interface IArmsRepository
    {
        Task<List<ArmsDTO>> GetBySchoolIdAsync(string schoolId);
        Task<ArmsTable?> CreateAsync(ArmsForCreationDTO armsDTO);
        //Task
    }
}