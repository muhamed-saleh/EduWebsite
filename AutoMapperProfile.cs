using AutoMapper;
using EduWebsite.DTOs;
using EduWebsite.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ContactMessageDto, ContactMessage>();
        CreateMap<ContactMessage, ContactMessageDto>();
        CreateMap<Payment, PaymentDto>();
        CreateMap<PaymentDto, Payment>();
        CreateMap<Exam, ExamDto>();
        CreateMap<ExamDto, Exam>();

    }
}
