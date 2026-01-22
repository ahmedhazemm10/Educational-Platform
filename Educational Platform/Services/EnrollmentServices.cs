using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Educational_Platform.Repository;

namespace Educational_Platform.Services
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IEnrollmentRepository enrollmentRepository;

        public EnrollmentServices(IStudentRepository studentRepository, ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository)
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
            this.enrollmentRepository = enrollmentRepository;
        }

        public bool Register(EnrollmentDTO enrollmentDTO)
        {
            var student = studentRepository.Details(enrollmentDTO.StudentId);
            if (student is null)
            {
                return false;
            }
            var course = courseRepository.Details(enrollmentDTO.CourseId);
            if (course is null)
            {
                return false;
            }
            var enrollment = new Enrollment()
            {
                CourseId = enrollmentDTO.CourseId,
                StudentId = enrollmentDTO.StudentId
            };
            var result = enrollmentRepository.GetEnrollment(enrollment);
            if (result is null)
            {
                enrollment.Status = Status.Active;
                enrollmentRepository.Add(enrollment);
                enrollmentRepository.Save();
                return true;
            }
            else
            {
                if (result.Status == Status.Active)
                {
                    return false;
                }
                result.Status = Status.Active;
                result.EnrollAt = DateTime.Now;
                enrollmentRepository.Update(result);
                enrollmentRepository.Save();
                return true;
            }
        }

        public bool UnRegister(EnrollmentDTO enrollmentDTO)
        {
            var student = studentRepository.Details(enrollmentDTO.StudentId);
            if (student is null)
            {
                return false;
            }
            var course = courseRepository.Details(enrollmentDTO.CourseId);
            if (course is null)
            {
                return false;
            }
            var enrollment = new Enrollment()
            {
                CourseId = enrollmentDTO.CourseId,
                StudentId = enrollmentDTO.StudentId
            };
            var result = enrollmentRepository.GetEnrollment(enrollment);
            if (result is null)
            {
                return false;
            }
            else
            {
                if (result.Status == Status.Active)
                {
                    result.Status = Status.Cancelled;
                    enrollmentRepository.Update(result);
                    enrollmentRepository.Save();
                    return true;
                }
                return false;
            }
        }
    }
    public interface IEnrollmentServices
    {
        public bool Register(EnrollmentDTO enrollmentDTO);
        public bool UnRegister(EnrollmentDTO enrollmentDTO);
    }
}
