using AutoMapper;
using EduWebsite.DTOs;
using EduWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EduWebsite.Services
{
    public class PaymentServices(AppDbContext context,IMapper _mapper) : IpaymentServices
    {
        public async Task CreatePayment(PaymentDto payment)
        {
            Payment pay = _mapper.Map<Payment>(payment);
            context.Payments.Add(pay);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPayments()
        {
            IEnumerable<Payment> payments = await context.Payments.ToListAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }
    }
}
