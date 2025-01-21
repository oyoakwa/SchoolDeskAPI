using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Class;
using api.Models;

namespace api.Mappers
{
    public static class ClassMapper
    {
        public static ClassesTable ToBaseFromCreationDTO(this ClassForCreationDTO clas){
            return new ClassesTable{
                SchoolId = clas.SchoolId,
                Class = clas.Class
            };
        }

         public static ClassDTO ToClassDTOFromBase(this ClassesTable clas){
            return new ClassDTO{
                Class = clas.Class
            };
        }

    } 

}