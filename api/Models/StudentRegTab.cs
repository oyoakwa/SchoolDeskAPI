﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace api.Models;

public partial class StudentRegTab
{
    public int StudentIdS { get; set; }

    public Guid? UserId { get; set; }

    public string SchoolId { get; set; }

    public string StudentRollNumber { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string Sex { get; set; }

    public string? ResidentialAddress { get; set; }

    public DateTimeOffset AdmissionDate { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }

    public string? PresentClass { get; set; }

    public string? GuidianceName { get; set; }

    public string? StudentPhoneNumber { get; set; }

    public string? EmailAdress { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int Lga { get; set; }

    public string? Disability { get; set; }

    public byte[] Passport { get; set; }

    public string? GuidiancePhoneNo { get; set; }

    public string? SchoolAttended { get; set; }

    public string? ReasonForChange { get; set; }

    public string? StudentEmail { get; set; }

    public string? Isborder { get; set; }

    public DateTimeOffset? LastEditedOn { get; set; }

    public int? Armsid { get; set; }

    public string? SecreatPassWord { get; set; }

    public string? BloodGroup { get; set; }

    public string? Genotype { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<ExamsTable> ExamsTables { get; set; } = new List<ExamsTable>();

    public virtual ICollection<PaymentTable> PaymentTables { get; set; } = new List<PaymentTable>();

    public virtual ICollection<ResultTable> ResultTables { get; set; } = new List<ResultTable>();

    public virtual SchoolAdminRegistration School { get; set; }

    public virtual ICollection<TestTable> TestTables { get; set; } = new List<TestTable>();
}