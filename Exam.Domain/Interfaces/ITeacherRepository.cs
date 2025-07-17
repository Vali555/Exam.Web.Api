using Exam.Common.Results;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teacher?> GetByIdAsync(Guid id);
        Task<ListResult<Teacher>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Guid> AddAsync(Teacher student);
        Task<Guid> UpdateAsync(Teacher student);
        Task<bool> DeleteAsync(Guid Id);
    }
}
