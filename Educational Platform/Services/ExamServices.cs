using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Educational_Platform.Repository;

namespace Educational_Platform.Services
{
    public class ExamServices : IExamServices
    {
        private readonly IExamRepository examRepository;
        private readonly ICourseRepository courseRepository;

        public ExamServices(IExamRepository examRepository, ICourseRepository courseRepository)
        {
            this.examRepository = examRepository;
            this.courseRepository = courseRepository;
        }

        public bool Add(ExamCreateDTO entity)
        {
            var course = courseRepository.Details(entity.CourseId);
            if (course is null)
            {
                return false;
            }
            var exam = new Exam()
            {
                CourseId = entity.CourseId,
                Description = entity.Description,
                Title = entity.Title,
                TotalMarks = entity.TotalMarks
            };
            examRepository.Add(exam);
            examRepository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var exam = examRepository.Details(id);
            if (exam is null)
            {
                return false;
            }
            examRepository.Delete(exam);
            examRepository.Save();
            return true;
        }

        public ExamReadDTO? Details(int id)
        {
            var exam = examRepository.Details(id);
            if (exam is null)
            {
                return null;
            }
            var examDTO = new ExamReadDTO()
            {
                Id = exam.Id,
                CourseId = exam.CourseId,
                Description = exam.Description,
                Title = exam.Title,
                TotalMarks = exam.TotalMarks
            };
            return examDTO;
        }

        public List<ExamReadDTO> GetAll()
        {
            return examRepository.GetAll().Select(e => new ExamReadDTO()
            {
                Id = e.Id,
                TotalMarks = e.TotalMarks,
                Title = e.Title,
                CourseId = e.CourseId,
                Description = e.Description
            }).ToList();
        }

        public ExamReadDTO? GetCourseExam(int courseId)
        {
            var course = courseRepository.Details(courseId);
            if (course is null)
            {
                return null;
            }
            var exam = examRepository.GetCourseExam(courseId);
            if (exam is null)
            {
                return null;
            }
            var examDTO = new ExamReadDTO()
            {
                CourseId = exam.CourseId,
                Title = exam.Title,
                TotalMarks = exam.TotalMarks,
                Description = exam.Description,
                Id = exam.Id
            };
            return examDTO;
        }

        public bool Update(ExamCreateDTO entity, int id)
        {
            var course = courseRepository.Details(entity.CourseId);
            if (course is null)
            {
                return false;
            }
            var exam = examRepository.Details(id);
            if (exam is null)
            {
                return false;
            }
            exam.Title = entity.Title;
            exam.TotalMarks = entity.TotalMarks;
            exam.Description = entity.Description;
            exam.CourseId = entity.CourseId;
            examRepository.Update(exam);
            examRepository.Save();
            return true;
        }
    }
    public interface IExamServices
    {
        public List<ExamReadDTO> GetAll();
        public bool Add(ExamCreateDTO entity);
        public bool Update(ExamCreateDTO entity, int id);
        public bool Delete(int id);
        public ExamReadDTO? Details(int id);
        public ExamReadDTO? GetCourseExam(int courseId);
    }
}
