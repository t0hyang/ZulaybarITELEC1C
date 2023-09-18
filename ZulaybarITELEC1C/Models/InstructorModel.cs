using System.Security.Cryptography.X509Certificates;

namespace ZulaybarITELEC1C.Models
{
    public class InstructorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsTenured { get; set; }
        public DateTime HiringDate { get; set; }
        public Rank Rank { get; set; }
    }

    public enum Rank
    {
        Instructor, AssistantProfessor, AssociateProfessor, Professor,
    }
}