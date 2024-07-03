using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Students;
using api.Models;

namespace api.Mappers
{
    public static class StudentMapper
    {
        public static StudentRegTab ToBaseModelFromCreationDTO(this StudentForCreatDTO studForCreation){
            return new StudentRegTab{
                UserId = studForCreation.UserId,
                FirstName = studForCreation.FirstName,
                MiddleName = studForCreation.MiddleName,
                LastName = studForCreation.LastName,
                Sex = studForCreation.Sex,
                StudentRollNumber = studForCreation.StudentRollNumber,
                RegistrationDate = studForCreation.RegistrationDate,
                PresentClass = studForCreation.PresentClass,
                SchoolId = studForCreation.SchoolId,
                ResidentialAddress = studForCreation.ResidentialAddress,
                GuidianceName = studForCreation.GuidianceName,
                GuidiancePhoneNo = studForCreation.GuidiancePhoneNo
            };
        }
        
    }
}