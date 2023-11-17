using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ZulaybarITELEC1C.Models;

namespace ZulaybarITELEC1C.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<StudentModel> Students { get; set; }

        public DbSet<InstructorModel> Instructors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentModel>().HasData(
                //STUDENT
                new StudentModel()
                {
                    Id = 1,
                    FirstName = "Zeia Samantha",
                    LastName = "Dimaano",
                    Birthday = DateTime.Parse("08/08/2002"),
                    Major = Major.BSIT,
                    Email = "zeiasamantha.dimaano.cics@ust.edu.ph"
                },
                new StudentModel()
                {
                    Id = 2,
                    FirstName = "Ricky Carlo",
                    LastName = "Tiolengco",
                    Birthday = DateTime.Parse("30/05/2002"),
                    Major = Major.BSIT,
                    Email = "rickycarlo.tiolengco.cics@ust.edu.ph"
                },
                new StudentModel()
                {
                    Id = 3,
                    FirstName = "Jason Rafael",
                    LastName = "Rodriguez",
                    Birthday = DateTime.Parse("15/05/2002"),
                    Major = Major.BSIT,
                    Email = "jasonrafael.rodriguez.cics@ust.edu.ph"
                }
                );

            modelBuilder.Entity<InstructorModel>().HasData(
                new InstructorModel()
                {
                    Id = 1,
                    FirstName = "Ten",
                    LastName = "Zulaybar",
                    IsTenured = true,
                    Phone = "00-1111-1112",
                    Rank = Rank.Professor,
                    HiringDate = DateTime.Parse("09/01/2017"),
                },
                new InstructorModel()
                {
                    Id = 2,
                    FirstName = "Zeia",
                    LastName = "Dimaano",
                    IsTenured = false,
                    Phone = "00-2222-2222",
                    Rank = Rank.Instructor,
                    HiringDate = DateTime.Parse("11/08/2022"),
                },
                new InstructorModel()
                {
                    Id = 3,
                    FirstName = "Zeke",
                    LastName = "Gonzalez",
                    IsTenured = true,
                    Phone = "00-1111-1111",
                    Rank = Rank.AssistantProfessor,
                    HiringDate = DateTime.Parse("28/11/2018")
                }
                );


        }
    }
}
