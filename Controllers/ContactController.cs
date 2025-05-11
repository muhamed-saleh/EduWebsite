using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost]
    public async Task<IActionResult> SendContact([FromBody] ContactMessageDto dto)
    {
        await _contactService.SaveContactAsync(dto);
        return Ok(new { message = "Message sent successfully!" });
    }
}
