using Exam.Common.DTOs;
using Exam.Common.Results;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Interfaces
{
    public interface ILessonRepository
    {
        Task<Lesson?> GetByIdAsync(Guid id);
        Task<ListResult<Lesson>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<Lesson>> GetAllAsync();
        Task<Guid> AddAsync(Lesson lesson);
        Task<Guid> UpdateAsync(Lesson lesson);
        Task<bool> DeleteAsync(Guid Id);
    }
}
