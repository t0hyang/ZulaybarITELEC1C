using Microsoft.AspNetCore.Mvc;
using ZulaybarITELEC1C.Models;
using ZulaybarITELEC1C.Services;
using ZulaybarITELEC1C.Controllers;
namespace ZulaybarITELEC1C.Services;

public class MyFakeDataService : IMyFakeDataService
{
    public List<StudentModel> StudentList { get; }
    public List<InstructorModel> InstructorList { get; }

    public MyFakeDataService()
    {
        StudentList = new List<StudentModel>();
        InstructorList = new List<InstructorModel>();
        {


            //INSTRUCTOR
            new InstructorModel()
            {
                Id = 1,
                FirstName = "Ten",
                LastName = "Zulaybar",
                IsTenured = true,
                Rank = Rank.Professor,
                HiringDate = DateTime.Parse("09/01/2017"),
            };
            new InstructorModel()
            {
                Id = 2,
                FirstName = "Zeia",
                LastName = "Dimaano",
                IsTenured = false,
                Rank = Rank.Instructor,
                HiringDate = DateTime.Parse("11/08/2022"),
            };
            new InstructorModel()
            {
                Id = 3,
                FirstName = "Zeke",
                LastName = "Gonzalez",
                IsTenured = true,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateTime.Parse("28/11/2018"),
            };
        }

        //STUDENT
        new StudentModel()
        {
            Id = 1,
            FirstName = "Zeia Samantha",
            LastName = "Dimaano",
            Birthday = DateTime.Parse("08/08/2002"),
            Major = Major.BSIT,
            Email = "zeiasamantha.dimaano.cics@ust.edu.ph"
        };
        new StudentModel()
        {
            Id = 2,
            FirstName = "Ricky Carlo",
            LastName = "Tiolengco",
            Birthday = DateTime.Parse("30/05/2002"),
            Major = Major.BSIT,
            Email = "rickycarlo.tiolengco.cics@ust.edu.ph"
        };
        new StudentModel()
        {
            Id = 3,
            FirstName = "Jason Rafael",
            LastName = "Rodriguez",
            Birthday = DateTime.Parse("15/05/2002"),
            Major = Major.BSIT,
            Email = "jasonrafael.rodriguez.cics@ust.edu.ph"
        };
}
}

