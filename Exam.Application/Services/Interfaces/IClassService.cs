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
        Task<Class?> GetByIdAsync(Guid id);
        Task<ListResult<Class>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Guid> AddAsync(ClassDto item);
        Task<Guid> UpdateAsync(ClassDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
