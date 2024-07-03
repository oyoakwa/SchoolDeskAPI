using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Arms
{
    public class ArmsDTO
    {
        public int ArmsId { get; set; }
        public string Arm { get; set; } = string.Empty;
    }

    public class ArmsForCreationDTO
    {
        
        public required string SchoolId { get; set; } 
        public string Arm { get; set; } = string.Empty;
    }
}