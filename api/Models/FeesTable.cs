﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace api.Models;

public partial class FeesTable
{
    public int FeesId { get; set; }

    public string SchoolId { get; set; }

    public decimal Amount { get; set; }

    public string Class { get; set; }

    public virtual SchoolAdminRegistration School { get; set; }
}