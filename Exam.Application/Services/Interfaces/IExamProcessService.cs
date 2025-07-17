using Exam.Common.DTOs;
using Exam.Common.Results;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Services.Interfaces
{
    public interface IExamProcessService
    {
        Task<ExamProcess?> GetByIdAsync(Guid id);
        Task<ListResult<ExamProcess>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<ExamProcess>> GetAllAsync();
        Task<Guid> AddAsync(ExamProcessDto item);
        Task<Guid> UpdateAsync(ExamProcessDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
