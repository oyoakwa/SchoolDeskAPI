﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ExamsTable
{
    public string StudentRollNumber { get; set; }

    public string SubjectName { get; set; }

    public decimal ExamsScores { get; set; }

    public int ExamsId { get; set; }

    public string Term { get; set; }

    public DateOnly Date { get; set; }

    public string StudentName { get; set; }

    public string SchoolId { get; set; }

    public string FillersId { get; set; }

    public virtual SchoolAdminRegistration School { get; set; }

    public virtual StudentRegTab StudentRollNumberNavigation { get; set; }
}