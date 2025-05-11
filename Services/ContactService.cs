using AutoMapper;

public class ContactService : IContactService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ContactService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task SaveContactAsync(ContactMessageDto dto)
    {
        ContactMessage contact = _mapper.Map<ContactMessage>(dto);
        _context.ContactMessages.Add(contact);
        await _context.SaveChangesAsync();

    }
}
