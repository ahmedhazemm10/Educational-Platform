using Educational_Platform.DTOs;
using Educational_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServices questionServices;

        public QuestionController(IQuestionServices questionServices)
        {
            this.questionServices = questionServices;
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Add(QuestionCreateDTO questionCreateDTO)
        {
            var result = questionServices.Add(questionCreateDTO);
            var response = new GeneralResponse<QuestionCreateDTO>()
            {
                Data = questionCreateDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was added successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The examId is invalid";
            return NotFound(response);
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(QuestionCreateDTO questionCreateDTO, int id)
        {
            var result = questionServices.Update(questionCreateDTO, id);
            var response = new GeneralResponse<QuestionCreateDTO>()
            {
                Data = questionCreateDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data was updated successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The questionId or examId or both are invalid";
            return NotFound(response);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var result = questionServices.Delete(id);
            var response = new GeneralResponse<QuestionReadDTO?>()
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
            response.Messsage = "The questionId is invalid";
            return NotFound(response);
        }
        [HttpGet("ExamQuestions/{examId:int}")]
        [Authorize]
        public IActionResult ExamQuestions(int examId)
        {
            var questions = questionServices.ExamQuestions(examId);
            var response = new GeneralResponse<List<QuestionReadDTO>?>();
            if (questions is null)
            {
                response.IsSucceeded = false;
                response.Messsage = "examId is invalid";
                response.Data = null;
                return NotFound(response);
            }
            response.IsSucceeded = true;
            response.Data = questions;
            response.Messsage = "The data returned successfully";
            return Ok(response);
        }
        [HttpGet("GetById/{id:int}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var question = questionServices.GetById(id);
            var response = new GeneralResponse<QuestionReadDTO?>();
            if (question != null)
            {
                response.IsSucceeded = true;
                response.Messsage = "The data returned successfully";
                response.Data = question;
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "The questionId is invalid";
            response.Data = null;
            return NotFound(response);
        }
    }
}
