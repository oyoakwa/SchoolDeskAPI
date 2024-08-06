using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Class
{
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public string Class { get; set; }
    }

    public class ClassForCreationDTO
    {
        public string SchoolId { get; set; }

        public string Class { get; set; }
    }
}