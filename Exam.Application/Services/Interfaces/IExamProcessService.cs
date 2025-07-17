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
        Task<ExamProcessResponseDto?> GetByIdAsync(Guid id);
        Task<ListResult<ExamProcessResponseDto>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<ExamProcessResponseDto>> GetAllAsync();
        Task<Guid> AddAsync(ExamProcessRequestDto item);
        Task<Guid> UpdateAsync(ExamProcessRequestDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
