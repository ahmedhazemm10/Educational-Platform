using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Educational_Platform.Repository;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Educational_Platform.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository studentRepository;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StudentServices(IStudentRepository studentRepository, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.studentRepository = studentRepository;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool Add(StudentDTO entity)
        {
            var user = httpContextAccessor.HttpContext?.User;
            if (user is null)
            {
                return false;
            }
            var student = new Student()
            {
                Name = entity.Name,
                Level = entity.Level,
                Governorate = entity.Governorate,
                UserId = userManager.GetUserId(user)
            };
            if (student.UserId is null)
            {
                return false;
            }
            studentRepository.Add(student);
            studentRepository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var student = studentRepository.Details(id);
            if (student is null)
            {
                return false;
            }
            studentRepository.Delete(student);
            studentRepository.Save();
            return true;
        }

        public StudentReadDTO? Details(int id)
        {
            var student = studentRepository.Details(id);
            if (student is null)
            {
                return null;
            }
            var studentDTO = new StudentReadDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Level = student.Level,
                Governorate = student.Governorate
            };
            return studentDTO;
        }

        public List<StudentReadDTO> GetAll()
        {
            return studentRepository.GetAll().Select(s => new StudentReadDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Level = s.Level,
                Governorate = s.Governorate
            }).ToList();
        }

        public StudentReadDTO? GetMyProfile()
        {
            var user = httpContextAccessor.HttpContext?.User;
            if (user is null)
            {
                return null;
            }
            var userId = userManager.GetUserId(user);
            if (userId == null)
            {
                return null;
            }
            var student = studentRepository.GetMyProfile(userId);
            if (student is null)
            {
                return null;
            }
            var studentDTO = new StudentReadDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Level = student.Level,
                Governorate = student.Governorate
            };
            return studentDTO;
        }

        public List<StudentCoursesDTO> StudentCourses(int id)
        {
            return studentRepository.StudentCourses(id).Select(e => new StudentCoursesDTO()
            {
                StudentName = e.Student.Name,
                CourseTitle = e.Course.Title,
                Status = e.Status,
                EnrollAt = e.EnrollAt
            }).Where(sc => sc.Status == Status.Active).ToList();
        }

        public List<StudentGradesDTO> StudentGrades(int id)
        {
            return studentRepository.StudentGrades(id).Select(g => new StudentGradesDTO()
            {
                StudentName = g.Student.Name,
                ExamTitle = g.Exam.Title,
                Score = g.Score
            }).ToList();
        }

        public bool Update(StudentDTO entity, int id)
        {
            var student = studentRepository.Details(id);
            if (student is null)
            {
                return false;
            }
            student.Name = entity.Name;
            student.Level = entity.Level;
            student.Governorate = entity.Governorate;
            studentRepository.Update(student);
            studentRepository.Save();
            return true;
        }
    }
    public interface IStudentServices
    {
        public List<StudentReadDTO> GetAll();
        public bool Add(StudentDTO entity);
        public bool Update(StudentDTO entity, int id);
        public bool Delete(int id);
        public StudentReadDTO? Details(int id);
        public StudentReadDTO? GetMyProfile();
        public List<StudentGradesDTO> StudentGrades(int id);
        public List<StudentCoursesDTO> StudentCourses(int id);
    }
}
