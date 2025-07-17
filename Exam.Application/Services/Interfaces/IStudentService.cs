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
        Task<Student?> GetByIdAsync(Guid id);
        Task<ListResult<Student>> GetPaginationAsync(int offset, int limit);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Guid> AddAsync(StudentDto item);
        Task<Guid> UpdateAsync(StudentDto item);
        Task<bool> DeleteAsync(Guid Id);
    }
}
