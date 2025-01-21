using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Test
{
    public class TestForCreationDTO
    {
    public string StudentRollNum { get; set; }

    public string SublectName { get; set; }

    public string TestType { get; set; }

    public DateTime Date { get; set; } = DateTime.Now.Date;

    public decimal Scores { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Term { get; set; }

    public string SchoolId { get; set; }

    public string FillersId { get; set; }
    }
}