using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using ZulaybarITELEC1C.Models;
using ZulaybarITELEC1C.Services;
namespace InstructorController.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _fakeData;
        public InstructorController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        /*List<InstructorModel> InstructorList = new List<InstructorModel>()
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
              };*/

        public IActionResult Index()
        {
            return View(_fakeData.InstructorList);
        }

        public IActionResult ShowDetails(int id)
        {
            
            InstructorModel? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);

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
            _fakeData.InstructorList.Add(newInstructor);
            return View("Index", _fakeData.InstructorList);
        }
        //
        [HttpGet]
        public IActionResult Edit(int id)
        {
            InstructorModel? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }
       
        [HttpPost]
        public IActionResult Edit(InstructorModel updatedInstructor)
        {

            InstructorModel? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == updatedInstructor.Id);


            if (instructor != null)
            {
                instructor.Id = updatedInstructor.Id;
                instructor.FirstName = updatedInstructor.FirstName;
                instructor.LastName = updatedInstructor.LastName;
                instructor.IsTenured = updatedInstructor.IsTenured;
                instructor.Rank = updatedInstructor.Rank;
                instructor.HiringDate = updatedInstructor.HiringDate;
            }  
            
            return View("Index", _fakeData.InstructorList);
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            InstructorModel? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);

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

            InstructorModel? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == deleteInstructor.Id);
            {
                _fakeData.InstructorList.Remove(instructor);
                return View("Index", _fakeData.InstructorList);
            }
        }
    }
}