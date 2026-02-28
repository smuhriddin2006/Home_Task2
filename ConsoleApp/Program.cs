
using Domain.Models;
using Infrastructure.Services;


StatisticsService statisticsService = new();

System.Console.WriteLine(statisticsService.GetTotalStudentsCount());
System.Console.WriteLine(statisticsService.GetTotalGroupsCount());
System.Console.WriteLine(statisticsService.GetTotalCoursesCount());
System.Console.WriteLine(statisticsService.GetTotalMentorsCount());





















// StudentServices studentServices = new();
// CourseService courseService = new();
// MentorService mentorService = new();
// GroupServices groupServices = new();
// StudentGroups new_studentGroups = new(){
//     StudentGroupId = 13,
//     StudentId = 4,
//     GroupId = 10,
//     Status = "Активен"
// };

// StudentGroupsService studentGroupsService = new();

// // studentGroupsService.DeleteStudentGroup(34);
// studentGroupsService.UpdateStudentGroup(new_studentGroups);

// var d = studentGroupsService.GetAllStudentGroup();

// foreach(var s in d)
// {
//     System.Console.WriteLine($"{s.StudentGroupId} {s.StudentId} {s.GroupId} {s.Status}");
// }






// Groups new_groups = new()
// {
//     GroupId = 34,
//     GroupName = "C++",
//     CourseId = 3,
//     MentorId = 2,
//     StartDate = new DateTime(2023,02,21),
//     EndDate = new DateTime(2026,03,22)
// };

// // groupServices.DeleteGroup(8);
// groupServices.UpdateGroup(new_groups);

// var d = groupServices.GetAllGroups();
// foreach (var s in d)
// {
//     System.Console.WriteLine($"{s.GroupId} {s.GroupName} {s.CourseId} {s.MentorId} {s.StartDate} {s.EndDate}");
// }






















// Mentors new_mentors = new()
// {
//     MentorId = 10,
//     FullName = "Hakim Juraev",
//     Email = "hakimjuraev32@gmail.com",
//     Phone = "+99293239143",
//     Specialization = "Programming Teacher"
// };

// mentorService.AddMentor(mentors);

// mentorService.DeleteMentor(34);

// mentorService.UpdateMentor(new_mentors);

// var d = mentorService.GetAllMentors();

// foreach (var s in d)
// {
//     System.Console.WriteLine($"{s.MentorId} {s.FullName} {s.Email} {s.Phone} {s.Specialization}");
// }










// Courses new_courses = new()
// {
//     CourseId = 34,
//     Title = "C++",
//     Description = "Programming",
//     DurationWeeks = 7
// };


// courseService.AddCourse(courses);

// courseService.UpdateCourse(new_courses);


// var d = courseService.GetAllCourses();
// foreach (var s in d)
// {
//     System.Console.WriteLine($"{s.CourseId} {s.Title} {s.Description} {s.DurationWeeks}");
// }


// studentServices.DeleteStudent(8);

// Students up_students = new()
// {
//     StudentId = 34, 
//     FullName = "Muhriddin Safarov",
//     Email = "smuhriddin008@gmail.com",
//     Phone = "+970424499",
//     EnrollmentDate = DateTime.Now
// };

// studentServices.UpdateStudent(up_students);

// var d = studentServices.GetAllStudents();

// foreach(var s in d)
// {
//     System.Console.WriteLine($"{s.StudentId} {s.FullName} {s.Email} {s.Phone} {s.EnrollmentDate}");
// }