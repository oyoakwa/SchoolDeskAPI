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
            student.UserId = Guid.NewGuid(); // Remember to remove this line when Guid is supplied by code
            
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

            int rowsAffected = await _context.Database.ExecuteSqlRawAsync("EXEC RegisterNewStudent @SchoolId,@UserId,@FirstName,@MiddleName,@LastName,@PresentClass,@ResidentialAddress,@GuidianceName,@StudentRollNumber,@Sex,@RegistrationDate,@GuidiancePhoneNo",
            scholIdParam,userIdParam,firstNameParam,middleNameParam,lastNameParam,presentClassParam,residentialAddressParam,parentsNameParam,studRollNumParam,sexParam,RegDateParam,parentTelNumParam);

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
            var studs = await _context.StudDTO.FromSqlRaw("EXEC SelStudsBySchoolId @SchoolId",schoolIdParam).ToListAsync();
            if(studs is null){
                return new List<StudentSelectSPDTO>();
            }
            return studs;
        }

        public Task<IEnumerable<StudentSelectSPDTO>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentForSelectDTO> GetStudentByStudentRollNumber(string rollNumber)
        {
            var StudentRollIdParam = new SqlParameter("@StudentRollNumber", rollNumber);
            var stud = await _context.StudSelDTO.FromSqlRaw("EXEC GetStudentProfile @StudentRollNumber",StudentRollIdParam).ToListAsync();
            if(stud is null){
                return new StudentForSelectDTO();
            }
            return stud.FirstOrDefault();
        }

        public async Task UpdateStudent(StudentRegTab student){
              _context.StudentRegTabs.Update(student); // Mark the entity as modified
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync(); // Save changes to the database
        }

        public async Task<StudentRegTab> GetBaseStudentByStudentRollNumber(string rollNumber)
        {
            var b= await _context.StudentRegTabs.FirstOrDefaultAsync(a=>a.StudentRollNumber == rollNumber);
            return b;
        }
    }
}