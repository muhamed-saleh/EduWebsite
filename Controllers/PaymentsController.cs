using EduWebsite.DTOs;
using EduWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IpaymentServices services) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto payment)
        {
            if (payment == null)
            {
                return BadRequest("Payment data is null");
            }
            await services.CreatePayment(payment);
            return Ok("Payment created successfully");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await services.GetAllPayments();
            return Ok(payments);
        }
    }
}
