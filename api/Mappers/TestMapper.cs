using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.DTOs.Test;
namespace api.Mappers
{
    public static class TestMapper
    {
         public static TestTable ToTestTableFromCreationDTO(this TestForCreationDTO createDto){
            return new TestTable{
                Date=DateTimeOffset.UtcNow,
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                SchoolId = createDto.SchoolId,
                FillersId = createDto.FillersId,
                Scores = createDto.Scores,
                StudentRollNum = createDto.StudentRollNum,
                SublectName = createDto.SublectName,
                Term = createDto.Term,
                TestType = createDto.TestType
            };

         }

         public static TestForDisplayDTO ToDisplayFromBase(this TestTable test){
            return new TestForDisplayDTO{
                Date = test.Date,
                FirstName = test.FirstName,
                LastName = test.LastName,
                SchoolId = test.SchoolId,
                Scores = test.Scores,
                SublectName = test.SublectName,
                Term = test.Term,
                TestType = test.TestType
            };
         }
    }
}