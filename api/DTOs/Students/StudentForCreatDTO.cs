using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Students
{
    public class StudentForCreatDTO
    {
    public Guid? UserId { get; set; }
    public string SchoolId { get; set; }
    public string StudentRollNumber { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string PresentClass { get; set; }
    public string ResidentialAddress { get; set; }
    public string GuidianceName { get; set; }
    public string GuidiancePhoneNo { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }
        
    }
}