using Educational_Platform.DTOs;
using Educational_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeServices gradeServices;

        public GradesController(IGradeServices gradeServices)
        {
            this.gradeServices = gradeServices;
        }
        [HttpPost("Submit")]
        [Authorize]
        public IActionResult SubmitExam(List<SubmitExamDTO> answers, int examId, int studentId)
        {
            var result = gradeServices.SubmitExam(answers, examId, studentId);
            var response = new GeneralResponse<int?>();
            if (result is null)
            {
                response.IsSucceeded = false;
                response.Data = null;
                response.Messsage = "ExamId or studentId or both are invalid";
                return NotFound(response);
            }
            response.IsSucceeded = true;
            response.Data = result;
            response.Messsage = $"Your score is : {result}";
            return Ok(response);
        }
    }
}
