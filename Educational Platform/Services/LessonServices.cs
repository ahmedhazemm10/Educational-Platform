using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Educational_Platform.Repository;

namespace Educational_Platform.Services
{
    public class LessonServices : ILessonServices
    {
        private readonly ILessonRepository lessonRepository;
        private readonly ICourseRepository courseRepository;

        public LessonServices(ILessonRepository lessonRepository, ICourseRepository courseRepository)
        {
            this.lessonRepository = lessonRepository;
            this.courseRepository = courseRepository;
        }

        public bool Add(LessonCreateDTO entity)
        {
            var course = courseRepository.Details(entity.CourseId);
            if (course is null)
            {
                return false;
            }
            var lesson = new Lesson()
            {
                CourseId = entity.CourseId,
                DurationMinutes = entity.DurationMinutes,
                Name = entity.Name,
                Order = entity.Order,
                URL = entity.URL
            };
            lessonRepository.Add(lesson);
            lessonRepository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var lesson = lessonRepository.Details(id);
            if (lesson is null)
            {
                return false;
            }
            lessonRepository.Delete(lesson);
            lessonRepository.Save();
            return true;
        }

        public LessonReadDTO? Details(int id)
        {
            var lesson = lessonRepository.Details(id);
            if (lesson is null)
            {
                return null;
            }
            var lessonDTO = new LessonReadDTO()
            {
                Id = lesson.Id,
                CourseId = lesson.CourseId,
                DurationMinutes = lesson.DurationMinutes,
                Name = lesson.Name,
                Order = lesson.Order,
                URL = lesson.URL
            };
            return lessonDTO;
        }

        public List<LessonReadDTO> GetAll()
        {
            return lessonRepository.GetAll().Select(l => new LessonReadDTO()
            {
                Id = l.Id,
                CourseId = l.CourseId,
                DurationMinutes = l.DurationMinutes,
                Name = l.Name,
                Order = l.Order,
                URL = l.URL
            }).ToList();
        }

        public List<LessonReadDTO>? GetLessonsByCourseId(int courseId)
        {
            var course = courseRepository.Details(courseId);
            if (course is null)
            {
                return null;
            }
            return lessonRepository.GetLessonsByCourseId(courseId).Select(l => new LessonReadDTO()
            {
                Id = l.Id,
                CourseId = l.CourseId,
                DurationMinutes = l.DurationMinutes,
                Name = l.Name,
                Order = l.Order,
                URL = l.URL
            }).ToList();
        }

        public bool Update(LessonCreateDTO entity, int id)
        {
            var course = courseRepository.Details(entity.CourseId);
            if (course is null)
            {
                return false;
            }
            var lesson = lessonRepository.Details(id);
            if (lesson is null)
            {
                return false;
            }
            lesson.Order = entity.Order;
            lesson.URL = entity.URL;
            lesson.Name = entity.Name;
            lesson.CourseId = entity.CourseId;
            lesson.DurationMinutes = entity.DurationMinutes;
            lessonRepository.Update(lesson);
            lessonRepository.Save();
            return true;
        }
    }
    public interface ILessonServices
    {
        public List<LessonReadDTO> GetAll();
        public bool Add(LessonCreateDTO entity);
        public bool Update(LessonCreateDTO entity, int id);
        public bool Delete(int id);
        public LessonReadDTO? Details(int id);
        public List<LessonReadDTO>? GetLessonsByCourseId(int courseId);
    }
}
