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
    public interface ILessonService
    {
        Task<LessonResponseDto?> GetByIdAsync(Guid id);
        Task<ListResult<LessonResponseDto>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<LessonResponseDto>> GetAllAsync();
        Task<Guid> AddAsync(LessonRequestDto item);
        Task<Guid> UpdateAsync(LessonRequestDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
