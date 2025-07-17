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
    public interface IClassService
    {
        Task<ClassResponseDto?> GetByIdAsync(Guid id);
        Task<ListResult<ClassResponseDto>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<ClassResponseDto>> GetAllAsync();
        Task<Guid> AddAsync(ClassrequestDto item);
        Task<Guid> UpdateAsync(ClassrequestDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
