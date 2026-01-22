using Educational_Platform.DTOs;
using Educational_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices courseServices;

        public CourseController(ICourseServices courseServices)
        {
            this.courseServices = courseServices;
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var courses = courseServices.GetAll();
            var response = new GeneralResponse<List<CourseReadDTO>>()
            {
                Data = courses,
                IsSucceeded = true,
                Messsage = "The data returned successfully"
            };
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Add(CourseCreateDTO courseCreateDTO)
        {
            courseServices.Add(courseCreateDTO);
            var response = new GeneralResponse<CourseCreateDTO>()
            {
                Data = courseCreateDTO,
                Messsage = "The data was added successfully",
                IsSucceeded = true
            };
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(CourseCreateDTO courseCreateDTO, int id)
        {
            var result = courseServices.Update(id, courseCreateDTO);
            var response = new GeneralResponse<CourseCreateDTO>()
            {
                Data = courseCreateDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was updated successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The courseId is invalid";
            return NotFound(response);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var result = courseServices.Delete(id);
            var response = new GeneralResponse<CourseReadDTO>()
            {
                Data = null
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was deleted successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The courseId is invalid";
            return NotFound(response);
        }
        [HttpGet("GetById/{id:int}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var course = courseServices.GetById(id);
            var response = new GeneralResponse<CourseReadDTO>();
            if (course != null)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data returned successfully";
                response.Data = course;
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The courseId is invalid";
            response.Data = null;
            return NotFound(response);
        }
        [HttpGet("NumOfCourseStudents/{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult NumOfCourseStudents(int id)
        {
            var count = courseServices.NumOfCourseStudents(id);
            var response = new GeneralResponse<int>()
            {
                Data = count,
                IsSucceeded = true,
                Messsage = "The data returned successfully"
            };
            return Ok(response);
        }
        [HttpGet("Search/{title:alpha}")]
        [AllowAnonymous]
        public IActionResult Search(string title)
        {
            var courses = courseServices.Search(title);
            var response = new GeneralResponse<List<CourseReadDTO>?>();
            if (courses != null)
            {
                response.IsSucceeded = true;
                response.Data = courses;
                response.Messsage = "The data returned successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Data = null;
            response.Messsage = "The title cannot be null or white space";
            return BadRequest(response);
        }
    }
}
