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
            var exams = await services.GetAllPayments();
            return Ok(exams);
        }
    }
}
