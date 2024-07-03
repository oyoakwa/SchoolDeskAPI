using api.Data;
using api.DTOs.Students;
using api.Interfaces;
using api.Models;
using api.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolPortalContext _context;
        public StudentRepository(SchoolPortalContext context)
        {
            _context = context;
        }

        public async Task<StudentRegTab> CreateStudent(StudentForCreatDTO studForCreate)
        {
            var student = studForCreate.ToBaseModelFromCreationDTO();
            student.RegistrationDate = DateTimeOffset.UtcNow;
            student.UserId = Guid.NewGuid();
            
            var scholIdParam = new SqlParameter("@SchoolId",student.SchoolId);
            var userIdParam = new SqlParameter("@UserId", student.UserId);
            var firstNameParam = new SqlParameter("@FirstName",student.FirstName);
            var middleNameParam = new SqlParameter("@MiddleName", student.MiddleName);
            var lastNameParam = new SqlParameter("@LastName", student.LastName);
            var presentClassParam = new SqlParameter("@PresentClass", student.PresentClass);
            var residentialAddressParam = new SqlParameter("@ResidentialAddress", student.ResidentialAddress);
            var parentsNameParam = new SqlParameter("@GuidianceName", student.GuidianceName);
            var studRollNumParam = new SqlParameter("@StudentRollNumber", student.StudentRollNumber);
            var sexParam = new SqlParameter("@Sex", student.Sex);
            var RegDateParam = new SqlParameter("@RegistrationDate", student.RegistrationDate);
            var parentTelNumParam = new SqlParameter("@GuidiancePhoneNo", student.GuidiancePhoneNo);

            int rowsAffected = await _context.Database.ExecuteSqlRawAsync("EXEC RegisterNewStudent @SchoolId,@UserId,@FirstName,@MiddleName,@LastName,@PresentClass,@ResidentialAddress,@GuidianceName,@StudentRollNumber,@Sex,@RegistrationDate,@GuidiancePhoneNo");

            if(rowsAffected<1){
                throw new Exception("Error while creating resources. SP RegisterNewStudent");
            }
            return student;
        }

        public Task DeleteStudent(StudentRegTab student)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentSelectSPDTO>> GetAllStudentFromSchool(string schoolId)
        {
            var schoolIdParam = new SqlParameter("@SchoolId", schoolId);
            var stud = await _context.StudDTO.FromSqlRaw("EXEC SelStudsBySchoolId @SchoolId",schoolIdParam).ToListAsync();
            if(stud is null){
                return new List<StudentSelectSPDTO>();
            }
            return stud;
        }

        public Task<IEnumerable<StudentSelectSPDTO>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}