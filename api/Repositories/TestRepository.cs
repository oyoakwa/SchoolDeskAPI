using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Test;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class TestRepository: ITestRepository
    {
        private readonly SchoolPortalContext _context;
        public TestRepository(SchoolPortalContext context)
        {
            _context = context;
        }

        public async Task<TestTable> InsertTest(TestForCreationDTO testCreateDTO)
        {
            var test = testCreateDTO.ToTestTableFromCreationDTO();
            var schoolIdParam = new SqlParameter("@SchoolID", test.SchoolId);
            var fillersIdParam = new SqlParameter("@FillersID",test.FillersId);
            var dateParam = new SqlParameter("@Date",test.Date);
            var firstNameParam = new SqlParameter("@FirstName",test.FirstName);
            var lastNameParam = new SqlParameter("@LastName",test.LastName);
            var StudentRollIdParam = new SqlParameter("@StudentRollNum", test.StudentRollNum);
            var subjectNameParam = new SqlParameter("@SublectName",test.SublectName);
            var termParam = new SqlParameter("@Term",test.Term);
            var testypeParam = new SqlParameter("@TestType",test.TestType);
            var scoresParam = new SqlParameter("@Scores",test.Scores);

            int rowsAffected = await _context.Database.ExecuteSqlRawAsync("EXEC InsertTestScores @SchoolID,@FillersID,@Date,@FirstName,@LastName,@StudentRollNum,@SublectName,@Term,@TestType,@Scores",
            schoolIdParam,fillersIdParam,dateParam,firstNameParam,lastNameParam,StudentRollIdParam,subjectNameParam,termParam,testypeParam,scoresParam);

            if(rowsAffected<1){
                throw new Exception("Error while creating resources. SP InsertTestScores");
            }

            return test;
        }
    }
}