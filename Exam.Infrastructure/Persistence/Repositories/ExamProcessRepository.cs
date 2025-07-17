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
    public class ExamProcessRepository:IExamProcessRepository
    {
        private readonly AppDbContext _context;

        public ExamProcessRepository(AppDbContext context)
        {
            _context = context;

        }

        public Task<Guid> AddAsync(ExamProcess examProcess)
        {
            _context.ExamProcesses.Add(examProcess);
            return Task.FromResult(examProcess.Id);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);

            if (entity == null)
                return false;

            _context.ExamProcesses.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<ExamProcess>> GetAllAsync()
        {
            return await _context.ExamProcesses
                .Include(e => e.Lesson)
                .Include(e => e.Student)
                .ToListAsync();
        }

        public async Task<ExamProcess?> GetByIdAsync(Guid id)
        {
            return await _context.ExamProcesses
                         .Include(e => e.Lesson)
                         .Include(e => e.Student)
                         .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ListResult<ExamProcess>> GetPaginationAsync(int offset, int limit)
        {
            var totalCount = await _context.ExamProcesses.CountAsync();

            var items = await _context.ExamProcesses
                .Include(e => e.Lesson)
                .Include(e => e.Student)
                .OrderBy(s => s.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return new ListResult<ExamProcess>
            {
                List = items,
                TotalCount = totalCount
            };
        }

        public Task<Guid> UpdateAsync(ExamProcess examProcess)
        {
            _context.ExamProcesses.Update(examProcess);
            return Task.FromResult(examProcess.Id);
        }
    }
}
