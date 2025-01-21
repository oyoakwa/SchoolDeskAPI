using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Class;
using api.Models;

namespace api.Interfaces
{
    public interface IClassRepository
    {
        Task<List<ClassDTO>> GetClassesBySchoolIDAsync(string schoolId);
        Task<int> CreateClass(ClassForCreationDTO clas);
        Task<int> DeleteAsync(int classId);
    }
}