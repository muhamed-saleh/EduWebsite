using EduWebsite.DTOs;
using EduWebsite.Models;

namespace EduWebsite.Services
{
    public interface IExamServices
    {
        Task Create (ExamDto exam);
        Task<IEnumerable<ExamDto>> GetAllPayments();
    }
}
