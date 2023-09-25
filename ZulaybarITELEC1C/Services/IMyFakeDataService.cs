using System;
using ZulaybarITELEC1C.Services;
using ZulaybarITELEC1C.Models;
namespace ZulaybarITELEC1C.Services;

public interface IMyFakeDataService
{
    List<StudentModel> StudentList { get; }
    List<InstructorModel> InstructorList { get; }
}
