using AutoMapper;
using EduWebsite.DTOs;
using EduWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EduWebsite.Services
{
    public class ExamServices(AppDbContext context,IMapper _mapper) : IExamServices
    {
        public async Task Create(ExamDto exam)
        {
            var examEntity = _mapper.Map<Exam>(exam);
            await context.Exams.AddAsync(examEntity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ExamDto>> GetAllPayments()
        {
            var exams = await context.Exams.ToListAsync();
            return _mapper.Map<IEnumerable<ExamDto>>(exams);
        }
    }
}
