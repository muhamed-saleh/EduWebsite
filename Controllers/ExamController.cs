using EduWebsite.DTOs;
using EduWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamServices _examServices;

        // Improved constructor with null check
        public ExamController(IExamServices examServices)
        {
            _examServices = examServices ?? throw new ArgumentNullException(nameof(examServices));
        }

        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] ExamDto examDto)
        {
            try
            {
                // Validate model state
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _examServices.Create(examDto);
                
                // Returns 201 Created with location header
                return CreatedAtAction(nameof(GetAllExams), new { message = "Exam created successfully" });
            }
            catch (Exception ex)
            {
                // Log exception here (add logging service if needed)
                return StatusCode(500, "An error occurred while creating the exam");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            try
            {
                var exams = await _examServices.GetAllExams();
                return Ok(exams);
            }
            catch (Exception ex)
            {
                // Log exception here
                return StatusCode(500, "An error occurred while retrieving exams");
            }
        }
    }
}

/*
// Original Code (commented out for reference)
using EduWebsite.DTOs;
using EduWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController(IExamServices services) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] ExamDto exam)
        {
            if (exam == null)
            {
                return BadRequest("Exam data is null");
            }
            await services.Create(exam);
            return Ok("Exam created successfully");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await services.GetAllPayments();  // Note: Appears to be a typo (Payments vs Exams)
            return Ok(exams);
        }
    }
}
*/
