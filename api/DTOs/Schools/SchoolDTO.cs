using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Schools
{
    public class SchoolDTO
    {
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public string SchoolId { get; set; } = string.Empty;

    public string SchoolName { get; set; } = string.Empty;

    public string AdminOtherNames { get; set; } = string.Empty;

    public string AdminSurName { get; set; } = string.Empty;

    public string StreetName { get; set; } = string.Empty;

    public int LgaId { get; set; }

    public DateTimeOffset? RegistrationDate { get; set; }

    public string SchoolPhoneNumber { get; set; } = string.Empty;

    public string SchoolEmailAdress { get; set; } = string.Empty;

    public string SchoolPostalCode { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    }


}