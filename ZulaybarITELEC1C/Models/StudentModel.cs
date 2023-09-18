using System.Security.Cryptography.X509Certificates;

namespace ZulaybarITELEC1C.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public Major Major { get; set; }
    }

    public enum Major
    {
        BSIT, BSCS, BSIS
    }
}
