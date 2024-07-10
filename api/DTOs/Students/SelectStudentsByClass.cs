using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Students
{
    public class SelectStudentsByClass
    {
        public string Name { get; set; }
        public int PresentClass { get; set; }
        public string GuidiancePhoneNo { get; set; }
        public string ResidentialAddress { get; set; }
        public string StudentRollNumber { get; set; }
    }
}