using Exam.Common.Results;
using Exam.Domain.Entities;
using Exam.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Infrastructure.Persistence.Repositories
{
    public class TeacherRepository:ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;

        }

        public Task<Guid> AddAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            return Task.FromResult(teacher.Id);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);

            if (entity == null)
                return false;

            _context.Teachers.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(Guid id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<ListResult<Teacher>> GetPaginationAsync(int offset, int limit)
        {
            var totalCount = await _context.Teachers.CountAsync();

            var items = await _context.Teachers
                .OrderBy(s => s.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return new ListResult<Teacher>
            {
                List = items,
                TotalCount = totalCount
            };
        }

        public Task<Guid> UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            return Task.FromResult(teacher.Id);
        }
    }
}
