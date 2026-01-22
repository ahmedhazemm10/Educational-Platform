using Educational_Platform.DTOs;
using Educational_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentServices enrollmentServices;

        public EnrollmentController(IEnrollmentServices enrollmentServices)
        {
            this.enrollmentServices = enrollmentServices;
        }
        [HttpPost]
        [Authorize]
        public IActionResult Register(EnrollmentDTO enrollmentDTO)
        {
            var result = enrollmentServices.Register(enrollmentDTO);
            var response = new GeneralResponse<EnrollmentDTO>()
            {
                Data = enrollmentDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "You registered in this course successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "Validate studentId or courseId, And if they true, you are already registered";
            return BadRequest(response);
        }
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(EnrollmentDTO enrollmentDTO)
        {
            var result = enrollmentServices.UnRegister(enrollmentDTO);
            var response = new GeneralResponse<EnrollmentDTO>()
            {
                Data = enrollmentDTO
            };
            if (result)
            {
                response.IsSucceeded = true;
                response.Messsage = "You unregistered from this course successfully";
                return Ok(response);
            }
            response.IsSucceeded = false;
            response.Messsage = "Validate studentId or courseId, And if they true, you are already unregistered";
            return BadRequest(response);
        }
    }
}
