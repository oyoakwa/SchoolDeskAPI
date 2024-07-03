using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Students;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentRegTab> CreateStudent(StudentForCreatDTO student);
        Task<IEnumerable<StudentSelectSPDTO>> GetAllStudentsAsync();
        Task<IEnumerable<StudentSelectSPDTO>> GetAllStudentFromSchool(string scholId);
        Task DeleteStudent(StudentRegTab student);
    }
}