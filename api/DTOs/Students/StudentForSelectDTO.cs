namespace api.DTOs.Students
{
    public class StudentForSelectDTO
    {
    public string SchoolId { get; set; }
    public string StudentRollNumber { get; set; }
    public string ResidentialAddress { get; set; }
    public string LGA { get; set; }
    public string FullName { get; set; }
    public string GuidiancePhoneNo { get; set; }
    public DateTimeOffset? AdmissionDate { get; set; }
    
    //For now, this represents the class admitted into
    public string PresentClass { get; set; }
    public string GuidianceName { get; set; }
    public string Sex { get; set; }
    public string EmailAdress { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Passport { get; set; }
    }
}