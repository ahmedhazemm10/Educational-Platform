using Educational_Platform.DTOs;
using Educational_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonServices lessonServices;

        public LessonController(ILessonServices lessonServices)
        {
            this.lessonServices = lessonServices;
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var lessons = lessonServices.GetAll();
            var response = new GeneralResponse<List<LessonReadDTO>>()
            {
                Data = lessons,
                IsSucceeded = true,
                Messsage = "The data returned successfully"
            };
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Add(LessonCreateDTO lessonCreateDTO)
        {
            var result = lessonServices.Add(lessonCreateDTO);
            var response = new GeneralResponse<LessonCreateDTO>()
            {
                Data = lessonCreateDTO
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
        public IActionResult Update(LessonCreateDTO lessonCreateDTO, int id)
        {
            var result = lessonServices.Update(lessonCreateDTO, id);
            var response = new GeneralResponse<LessonCreateDTO>()
            {
                Data = lessonCreateDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was updated successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The courseId or lessonId or both are invalid";
            return NotFound(response);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var result = lessonServices.Delete(id);
            var response = new GeneralResponse<LessonReadDTO>()
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
            response.Messsage = "The lessonId is invalid";
            return NotFound(response);
        }
        [HttpGet("GetById/{id:int}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var lesson = lessonServices.Details(id);
            var response = new GeneralResponse<LessonReadDTO>();
            if (lesson != null)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data returned successfully";
                response.Data = lesson;
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The lessonId is invalid";
            response.Data = null;
            return NotFound(response);
        }
        [HttpGet("GetLessonsByCourseId/{id:int}")]
        [Authorize]
        public IActionResult GetLessonsByCourseId(int id)
        {
            var result = lessonServices.GetLessonsByCourseId(id);
            var response = new GeneralResponse<List<LessonReadDTO?>>();
            if (result is null)
            {
                response.IsSucceeded= false;
                response.Data = null;
                response.Messsage = "The courseId is invalid";
                return NotFound(response);
            }
            response.IsSucceeded = true;
            response.Data= result;
            response.Messsage = "The data returned successfully";
            return Ok(response);
        }
    }
}
