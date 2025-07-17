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
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context)
        {
            _context = context;

        }

        public Task<Guid> AddAsync(Class classItem)
        {
            _context.Classes.Add(classItem);
            return Task.FromResult(classItem.Id);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);

            if (entity == null)
                return false;

            _context.Classes.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class?> GetByIdAsync(Guid id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<ListResult<Class>> GetPaginationAsync(int offset, int limit)
        {
            var totalCount = await _context.Classes.CountAsync();

            var items = await _context.Classes
                .OrderBy(s => s.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return new ListResult<Class>
            {
                List = items,
                TotalCount = totalCount
            };
        }

        public Task<Guid> UpdateAsync(Class classItem)
        {
            _context.Classes.Update(classItem);
            return Task.FromResult(classItem.Id);
        }

    }
}
