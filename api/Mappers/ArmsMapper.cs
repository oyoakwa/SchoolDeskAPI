using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Arms;
using api.Models;


namespace api.Mappers
{
    public static class ArmsMapper
    {
        public static ArmsTable ToArmsFromCreationDTO(this ArmsForCreationDTO armsDTO)
        {
            return new ArmsTable
            {
                SchoolId = armsDTO.SchoolId,
                Arm = armsDTO.Arm
            };
        }
    }
}