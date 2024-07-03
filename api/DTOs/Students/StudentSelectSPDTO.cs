namespace api.DTOs.Students
{
    public class StudentSelectSPDTO
    { 
    public string StudentRollNumber { get; set; }= string.Empty;
    public string FullName { get; set; }= string.Empty;
    public string Sex { get; set; }= string.Empty;
    public DateTimeOffset? RegistrationDate { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ClassAdmited { get; set; }= string.Empty;
    public string ResidentialAddress { get; set; }= string.Empty;
    public string GuidianceName { get; set; }= string.Empty;
    public string GuidiancePhoneNo { get; set; }= string.Empty;
    }
}