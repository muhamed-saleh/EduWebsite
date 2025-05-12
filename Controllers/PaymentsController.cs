using EduWebsite.DTOs;
using EduWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduWebsite.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;

        /// <summary>
        /// Constructor with dependency injection and null check
        /// </summary>
        public PaymentsController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices ?? throw new ArgumentNullException(nameof(paymentServices));
        }

        /// <summary>
        /// Creates a new payment record
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _paymentServices.CreatePayment(paymentDto);
                return CreatedAtAction(
                    actionName: nameof(GetAllPayments),
                    value: new { message = "Payment created successfully" });
            }
            catch (Exception ex)
            {
                // In production, log this exception (e.g., using ILogger)
                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: "An unexpected error occurred while processing your payment");
            }
        }

        /// <summary>
        /// Retrieves all payment records
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                var payments = await _paymentServices.GetAllPayments();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                // In production, log this exception
                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: "An unexpected error occurred while retrieving payments");
            }
        }
    }
}

/*
// Original PaymentsController (commented for reference)
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
*/
