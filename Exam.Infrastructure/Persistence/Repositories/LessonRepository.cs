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
    public class LessonRepository:ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;

        }

        public Task<Guid> AddAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            return Task.FromResult(lesson.Id);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);

            if (entity == null)
                return false;

            _context.Lessons.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync()
        {
            return await _context.Lessons
                .Include(l => l.Class)
                .Include(l => l.Teacher)
                .ToListAsync();
        }

        public async Task<Lesson?> GetByIdAsync(Guid id)
        {
            return await _context.Lessons
                        .Include(l => l.Class)
                        .Include(l => l.Teacher)
                        .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<ListResult<Lesson>> GetPaginationAsync(int offset, int limit)
        {
            var totalCount = await _context.Lessons.CountAsync();

            var items = await _context.Lessons
                .OrderBy(s => s.Id)
                .Include(l => l.Class)
                .Include(l => l.Teacher)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return new ListResult<Lesson>
            {
                List = items,
                TotalCount = totalCount
            };
        }

        public Task<Guid> UpdateAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            return Task.FromResult(lesson.Id);
        }
    }
}
