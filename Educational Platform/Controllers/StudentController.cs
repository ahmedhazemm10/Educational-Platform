using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Educational_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices studentServices;
        public StudentController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }
        [HttpGet("GetAll")]
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            var students = studentServices.GetAll();
            var response = new GeneralResponse<List<StudentReadDTO>>()
            {
                Data = students,
                IsSucceeded = true,
                Messsage = "The data returned successfully"
            };
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(StudentDTO studentDTO)
        {
            var result = studentServices.Add(studentDTO);
            var response = new GeneralResponse<StudentDTO>()
            {
                Data = studentDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was added successfully";
                return Ok(response);
            }
                response.IsSucceeded = false;
                response.Messsage = "The userId is null";
            return BadRequest(response);
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(StudentDTO studentDTO, int id)
        {
            var result = studentServices.Update(studentDTO, id);
            var response = new GeneralResponse<StudentDTO>()
            {
                Data = studentDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was updated successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The studentId is invalid";
            return NotFound(response);
            
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var result = studentServices.Delete(id);
            var response = new GeneralResponse<StudentDTO>()
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
            response.Messsage = "The studentId is invalid";
            return NotFound(response);
            
        }
        [HttpGet("GetById/{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(int id)
        {
            var student = studentServices.Details(id);
            var response = new GeneralResponse<StudentReadDTO>();
            if (student != null)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data returned successfully";
                response.Data = student;
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The studentId is invalid";
            response.Data = null;
            return NotFound(response);
        }
        [HttpGet("MyProfile")]
        [Authorize]
        public IActionResult GetMyProfile()
        {
            var student = studentServices.GetMyProfile();
            var response = new GeneralResponse<StudentReadDTO>();
            if (student != null)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data returned successfully";
                response.Data = student;
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The studentId is invalid";
            response.Data = null;
            return NotFound(response);
        }
        [HttpGet("StudentCourses/{id:int}")]
        [Authorize]
        public IActionResult StudentCourses(int id)
        {
            var courses = studentServices.StudentCourses(id);
            var response = new GeneralResponse<List<StudentCoursesDTO>>();
            response.IsSucceeded = true;
            response.Messsage = "The data returned successfully";
            response.Data = courses;
            return Ok(response);
        }
        [HttpGet("StudentGrades/{id:int}")]
        [Authorize]
        public IActionResult StudentGrades(int id)
        {
            var grades = studentServices.StudentGrades(id);
            var response = new GeneralResponse<List<StudentGradesDTO>>();
            response.IsSucceeded = true;
            response.Messsage = "The data returned successfully";
            response.Data = grades;
            return Ok(response);
        }
    }
}
