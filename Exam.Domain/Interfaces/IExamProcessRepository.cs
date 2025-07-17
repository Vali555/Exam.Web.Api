using Exam.Common.Results;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Interfaces
{
    public interface IExamProcessRepository
    {
        Task<ExamProcess?> GetByIdAsync(Guid id);
        Task<ListResult<ExamProcess>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<ExamProcess>> GetAllAsync();
        Task<Guid> AddAsync(ExamProcess examProcess);
        Task<Guid> UpdateAsync(ExamProcess examProcess);
        Task<bool> DeleteAsync(Guid Id);
    }
}
