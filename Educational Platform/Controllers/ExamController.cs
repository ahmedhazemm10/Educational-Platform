using Educational_Platform.DTOs;
using Educational_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamServices examServices;

        public ExamController(IExamServices examServices)
        {
            this.examServices = examServices;
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var exams = examServices.GetAll();
            var response = new GeneralResponse<List<ExamReadDTO>>()
            {
                Data = exams,
                IsSucceeded = true,
                Messsage = "The data returned successfully"
            };
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Add(ExamCreateDTO examCreateDTO)
        {
            var result = examServices.Add(examCreateDTO);
            var response = new GeneralResponse<ExamCreateDTO>()
            {
                Data = examCreateDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was added successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The courseId is invalid";
            return NotFound(response);
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(ExamCreateDTO examCreateDTO, int id)
        {
            var result = examServices.Update(examCreateDTO, id);
            var response = new GeneralResponse<ExamCreateDTO>()
            {
                Data = examCreateDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was updated successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The courseId or examId or both are invalid";
            return NotFound(response);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var result = examServices.Delete(id);
            var response = new GeneralResponse<ExamReadDTO?>()
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
            response.Messsage = "The examId is invalid";
            return NotFound(response);
        }
        [HttpGet("GetById/{id:int}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var exam = examServices.Details(id);
            var response = new GeneralResponse<ExamReadDTO?>();
            if (exam != null)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data returned successfully";
                response.Data = exam;
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The examId is invalid";
            response.Data = null;
            return NotFound(response);
        }
        [HttpGet("GetCourseExam/{courseId:int}")]
        [Authorize]
        public IActionResult GetCourseExam(int courseId)
        {
            var result = examServices.GetCourseExam(courseId);
            var response = new GeneralResponse<ExamReadDTO?>();
            if (result is null)
            {
                response.IsSucceeded = false;
                response.Data = null;
                response.Messsage = "courseId is invalid";
                return NotFound(response);
            }
            response.IsSucceeded = true;
            response.Data = result;
            response.Messsage = "The data returned successfully";
            return Ok(response);
        }
    }
}
