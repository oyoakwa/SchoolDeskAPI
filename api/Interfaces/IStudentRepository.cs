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
        Task<StudentForSelectDTO> GetStudentByStudentRollNumber(string rollNumber);
        Task<StudentRegTab> GetBaseStudentByStudentRollNumber(string rollNumber);
        Task DeleteStudent(StudentRegTab student);
        Task UpdateStudent(StudentRegTab student);
        Task<int> SaveChangesAsync();
    }
}