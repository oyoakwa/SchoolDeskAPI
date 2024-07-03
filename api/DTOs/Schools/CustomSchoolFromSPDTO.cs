namespace api.DTOs.Schools
{
    public class CustomSchoolFromSPDTO
    {
        public int countStudentInSchool { get; set; }
        public string SchoolName { get; set; } = string.Empty;
        public string SchoolId { get; set; } = string.Empty;
        public string SchoolEmailAdress { get; set; } = string.Empty;
        public string SchoolPhoneNumber { get; set; } = string.Empty;
       // public bool IsApproved { get; set; }
    }


}