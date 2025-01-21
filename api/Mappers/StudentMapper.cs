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
        public static StudentForUpdateDTO ToUpdateFromSelectObject(this StudentForSelectDTO stud){
            var fullName = stud.FullName;
            string fName, mName, lName;
            string[] names = fullName.Split(' ');
                fName=names[0];
                mName = names[1];
                lName = names[2];
            return new StudentForUpdateDTO{
                FirstName = fName,
                MiddleName = mName,
                LastName = lName,
                GuidianceName = stud.GuidianceName,
                GuidiancePhoneNo = stud.GuidiancePhoneNo,
                ResidentialAddress = stud.ResidentialAddress,
                EmailAdress = stud.EmailAdress
            };
        }

        public static StudentForUpdateDTO ToUpdateFromBaseObject(this StudentRegTab stud){
            
            return new StudentForUpdateDTO{
                FirstName = stud.FirstName,
                MiddleName = stud.MiddleName,
                LastName = stud.LastName,
                GuidianceName = stud.GuidianceName,
                GuidiancePhoneNo = stud.GuidiancePhoneNo,
                ResidentialAddress = stud.ResidentialAddress,
                EmailAdress = stud.EmailAdress,
            };
        }

        public static StudentRegTab ToBaseFromUpdateObject(this StudentForUpdateDTO stud, StudentRegTab stu){
                stu.FirstName = stud.FirstName;
                stu.MiddleName = stud.MiddleName;
                stu.LastName = stud.LastName;
                stu.GuidianceName = stud.GuidianceName;
                stu.GuidiancePhoneNo = stud.GuidiancePhoneNo;
                stu.ResidentialAddress = stud.ResidentialAddress;
                stu.EmailAdress = stud.EmailAdress;
                stu.LastEditedOn = DateTime.UtcNow;
                return stu;
        }
        
    }
}