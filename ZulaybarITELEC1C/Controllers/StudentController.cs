using Microsoft.AspNetCore.Mvc;
using ZulaybarITELEC1C.Data;
using ZulaybarITELEC1C.Models;
using ZulaybarITELEC1C.Services;

namespace ZulaybarITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbContext;
        public StudentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            return View(_dbContext.Students);
        }
        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            StudentModel? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

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
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Students);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Search for the student whose id matches the given id
            StudentModel? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(StudentModel updatedStudent)
        {

            StudentModel? student = _dbContext.Students.FirstOrDefault(st => st.Id == updatedStudent.Id);


            if (student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.Email = updatedStudent.Email;
                student.Birthday = updatedStudent.Birthday;
                student.Major = updatedStudent.Major;
            }
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Students);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            StudentModel? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

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
            StudentModel? student = _dbContext.Students.FirstOrDefault(st => st.Id == deleteStudent.Id);
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Students);
            
        }
    }
}
