using Exam.Common.Results;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(Guid id);
        Task<ListResult<Student>> GetPaginationAsync(int offset,int limit);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Guid> AddAsync(Student student);
        Task<Guid> UpdateAsync(Student student);
        Task<bool> DeleteAsync(Guid Id);
    }
}
