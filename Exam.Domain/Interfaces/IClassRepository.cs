using Exam.Common.Results;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Interfaces
{
    public interface IClassRepository
    {
        Task<Class?> GetByIdAsync(Guid id);
        Task<ListResult<Class>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Guid> AddAsync(Class student);
        Task<Guid> UpdateAsync(Class student);
        Task<bool> DeleteAsync(Guid Id);
    }
}
