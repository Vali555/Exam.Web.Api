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
    public interface IStudentService
    {
        Task<StudentResponseDto?> GetByIdAsync(Guid id);
        Task<ListResult<StudentResponseDto>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<StudentResponseDto>> GetAllAsync();
        Task<Guid> AddAsync(StudentRequestDto item);
        Task<Guid> UpdateAsync(StudentRequestDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
