using Microsoft.AspNetCore.Mvc;
using ZulaybarITELEC1C.Models;

namespace ZulaybarITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        List<StudentModel> StudentList = new List<StudentModel>()
            {
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
              };
        public IActionResult Index()
        {
            return View(StudentList);
        }
        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            StudentModel? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(StudentModel newStudent)
        {
            StudentList.Add(newStudent);
            return View("Index", StudentList);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Search for the student whose id matches the given id
            StudentModel? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(StudentModel updatedStudent)
        {

            StudentModel? student = StudentList.FirstOrDefault(st => st.Id == updatedStudent.Id);


            if (student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.Email = updatedStudent.Email;
                student.Birthday = updatedStudent.Birthday;
                student.Major = updatedStudent.Major;
            }

            return View("Index", StudentList);
        }
    }
}