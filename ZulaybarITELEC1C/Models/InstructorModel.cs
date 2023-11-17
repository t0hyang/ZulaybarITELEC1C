using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ZulaybarITELEC1C.Models
{
    public class InstructorModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Display(Name = "Tenure")]
        public bool IsTenured { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        [Display(Name = "Rank")]
        public Rank Rank { get; set; }
    }

    public enum Rank
    {
        Instructor, AssistantProfessor, AssociateProfessor, Professor,
    }
}