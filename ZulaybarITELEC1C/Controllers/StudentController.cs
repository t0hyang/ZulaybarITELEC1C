using Microsoft.AspNetCore.Mvc;
using ZulaybarITELEC1C.Models;
using ZulaybarITELEC1C.Services;

namespace ZulaybarITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _fakeData;
        public StudentController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }
        /*   List<StudentModel> StudentList = new List<StudentModel>()
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
                 };*/
        public IActionResult Index()
        {
            return View(_fakeData.StudentList);
        }
        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            StudentModel? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

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
            _fakeData.StudentList.Add(newStudent);
            return View("Index", _fakeData.StudentList);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Search for the student whose id matches the given id
            StudentModel? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(StudentModel updatedStudent)
        {

            StudentModel? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == updatedStudent.Id);


            if (student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.Email = updatedStudent.Email;
                student.Birthday = updatedStudent.Birthday;
                student.Major = updatedStudent.Major;
            }

            return View("Index", _fakeData.StudentList);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            StudentModel? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
            {
                return View(student);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(StudentModel deleteStudent)
        {

            StudentModel? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == deleteStudent.Id);
            {
                _fakeData.StudentList.Remove(student);
                return View("Index", _fakeData.StudentList);
            }
        }
    }
}
