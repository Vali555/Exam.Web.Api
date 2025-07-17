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
    public interface ITeacherService
    {
        Task<Teacher?> GetByIdAsync(Guid id);
        Task<ListResult<Teacher>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Guid> AddAsync(TeacherDto item);
        Task<Guid> UpdateAsync(TeacherDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
