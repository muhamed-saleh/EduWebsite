using EduWebsite.DTOs;
using EduWebsite.Models;

namespace EduWebsite.Services
{
    public interface IpaymentServices
    {
        Task CreatePayment(PaymentDto payment);
        Task<IEnumerable<PaymentDto>> GetAllPayments();

    }
}
