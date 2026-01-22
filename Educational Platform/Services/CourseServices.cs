using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Educational_Platform.Repository;

namespace Educational_Platform.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepository courseRepository;

        public CourseServices(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public void Add(CourseCreateDTO courseCreateDTO)
        {
            var course = new Course()
            {
                Description = courseCreateDTO.Description,
                Price = courseCreateDTO.Price,
                Title = courseCreateDTO.Title
            };
            courseRepository.Add(course);
            courseRepository.Save();
        }

        public bool Delete(int id)
        {
            var course = courseRepository.Details(id);
            if (course is null)
            {
                return false;
            }
            courseRepository.Delete(course);
            courseRepository.Save();
            return true;
        }

        public List<CourseReadDTO> GetAll()
        {
            return courseRepository.GetAll().Select(c => new CourseReadDTO()
            {
                Price = c.Price,
                Description = c.Description,
                Id = c.Id,
                Title = c.Title
            }).ToList();
        }

        public CourseReadDTO? GetById(int id)
        {
            var course = courseRepository.Details(id);
            if (course is null)
            {
                return null;
            }
            var courseDTO = new CourseReadDTO()
            {
                Description = course.Description,
                Id = course.Id,
                Price = course.Price,
                Title = course.Title
            };
            return courseDTO;
        }

        public int NumOfCourseStudents(int id)
        {
            return courseRepository.NumOfCourseStudents(id);
        }

        public List<CourseReadDTO>? Search(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return null;
            }
            return courseRepository.Search(title).Select(c => new CourseReadDTO()
            {
                Price = c.Price,
                Description = c.Description,
                Id = c.Id,
                Title = c.Title
            }).ToList();
        }

        public bool Update(int id, CourseCreateDTO courseCreateDTO)
        {
            var course = courseRepository.Details(id);
            if (course is null)
            {
                return false;
            }
            course.Price = courseCreateDTO.Price;
            course.Title = courseCreateDTO.Title;
            course.Description = courseCreateDTO.Description;
            courseRepository.Update(course);
            courseRepository.Save();
            return true;
        }
    }
    public interface ICourseServices
    {
        public List<CourseReadDTO> GetAll();
        public CourseReadDTO? GetById(int id);
        public bool Update(int id, CourseCreateDTO courseCreateDTO);
        public void Add(CourseCreateDTO courseCreateDTO);
        public bool Delete(int id);
        public List<CourseReadDTO>? Search(string title);
        public int NumOfCourseStudents(int id);
    }
}
