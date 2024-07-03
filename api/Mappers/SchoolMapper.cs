using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Schools;
using api.Models;

namespace api.Mappers
{
    public static class SchoolMapper
    {
        public static SchoolDTO ToSchoolDTO(this SchoolAdminRegistration schoolModel)
        {
            return new SchoolDTO
            {
                Id = schoolModel.Id,
                UserId = schoolModel.UserId,
                SchoolId = schoolModel.SchoolId,
                SchoolName = schoolModel.SchoolName,
                SchoolEmailAdress = schoolModel.SchoolEmailAdress,
                StreetName = schoolModel.StreetName,
                SchoolPhoneNumber = schoolModel.SchoolPhoneNumber,
                SchoolPostalCode = schoolModel.SchoolPostalCode,
                AdminSurName = schoolModel.AdminSurName,
                AdminOtherNames = schoolModel.AdminOtherNames,
                LgaId = schoolModel.LgaId,
                Gender = schoolModel.Gender,
                RegistrationDate = schoolModel.RegistrationDate
            };
        }

        public static SchoolAdminRegistration ToSchoolFromSchoolCreatDTO(this SchoolForCreationDTO schoolForCreation)
        {
            return new SchoolAdminRegistration
            {
                UserId = schoolForCreation.UserId,
                SchoolId = schoolForCreation.SchoolId,
                SchoolEmailAdress = schoolForCreation.SchoolEmailAdress,
                SchoolPhoneNumber = schoolForCreation.SchoolPhoneNumber,
                SchoolName = schoolForCreation.SchoolName,
                SchoolPostalCode = schoolForCreation.SchoolPostalCode,
                AdminOtherNames = schoolForCreation.AdminOtherNames,
                AdminSurName = schoolForCreation.AdminSurName,
                StreetName = schoolForCreation.StreetName,
                Gender = schoolForCreation.Gender,
                LgaId = schoolForCreation.LgaId,
                RegistrationDate = schoolForCreation.RegistrationDate
            };
        }

    }
}