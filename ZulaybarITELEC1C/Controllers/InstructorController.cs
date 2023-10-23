using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ZulaybarITELEC1C.Data;
using ZulaybarITELEC1C.Models;
using ZulaybarITELEC1C.Services;
namespace InstructorController.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbContext;
        public InstructorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Instructors);
        }

        public IActionResult ShowDetails(int id)
        {
            
            InstructorModel? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(InstructorModel newInstructor)
        {
            _dbContext.Instructors.Add(newInstructor);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Instructors);
        }
        //
        [HttpGet]
        public IActionResult Edit(int id)
        {
            InstructorModel? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }
       
        [HttpPost]
        public IActionResult Edit(InstructorModel updatedInstructor)
        {

            InstructorModel? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == updatedInstructor.Id);


            if (instructor != null)
            {
                instructor.Id = updatedInstructor.Id;
                instructor.FirstName = updatedInstructor.FirstName;
                instructor.LastName = updatedInstructor.LastName;
                instructor.IsTenured = updatedInstructor.IsTenured;
                instructor.Rank = updatedInstructor.Rank;
                instructor.HiringDate = updatedInstructor.HiringDate;
            }
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Instructors);
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            InstructorModel? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
            {
                return View(instructor);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(InstructorModel deleteInstructor)
        {
            InstructorModel? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == deleteInstructor.Id);
            _dbContext.Instructors.Remove(instructor);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Instructors);
        }
    }
}