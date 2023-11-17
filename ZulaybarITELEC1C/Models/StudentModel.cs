using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ZulaybarITELEC1C.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Major")]
        public Major Major { get; set; }
    }

    public enum Major
    {
        BSIT, BSCS, BSIS
    }
}
