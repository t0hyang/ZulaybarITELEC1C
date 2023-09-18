using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using ZulaybarITELEC1C.Models;
namespace InstructorController.Controllers
{
    public class InstructorController : Controller
    {


        List<InstructorModel> InstructorList = new List<InstructorModel>()
            {
            new InstructorModel()
            {
                Id = 1,
                FirstName = "Ten",
                LastName = "Zulaybar",
                IsTenured = true,
                Rank = Rank.Professor,
                HiringDate = DateTime.Parse("09/01/2017"),
            },
            new InstructorModel()
            {
                Id = 2,
                FirstName = "Zeia",
                LastName = "Dimaano",
                IsTenured = false,
                Rank = Rank.Instructor,
                HiringDate = DateTime.Parse("11/08/2022"),
            },
            new InstructorModel()
            {
                Id = 3,
                FirstName = "Zeke",
                LastName = "Gonzalez",
                IsTenured = true,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateTime.Parse("28/11/2018"),
            },
              };

        public IActionResult Index()
        {
            return View(InstructorList);
        }

        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            InstructorModel? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
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
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }
        //
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Search for the student whose id matches the given id
            InstructorModel? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();
        }
       
        [HttpPost]
        public IActionResult Edit(InstructorModel updatedInstructor)
        {

            InstructorModel? instructor = InstructorList.FirstOrDefault(st => st.Id == updatedInstructor.Id);


            if (instructor != null)
            {
                instructor.Id = updatedInstructor.Id;
                instructor.FirstName = updatedInstructor.FirstName;
                instructor.IsTenured = updatedInstructor.IsTenured;
                instructor.Rank = updatedInstructor.Rank;
                instructor.HiringDate = updatedInstructor.HiringDate;
            }  
            
            return View("Index", InstructorList);
        }
    }
}