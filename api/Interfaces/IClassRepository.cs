using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Class;

namespace api.Interfaces
{
    public interface IClassRepository
    {
        Task<List<ClassDTO>> GetClassesBySchoolIDAsync(string schoolId);
    }
}