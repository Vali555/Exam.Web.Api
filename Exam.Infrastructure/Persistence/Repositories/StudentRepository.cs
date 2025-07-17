using Exam.Application;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
     
        public StudentRepository(AppDbContext context)
        {
            _context = context;
    
        }

        public  Task<Guid> AddAsync(Student student)
        {
            _context.Students.Add(student);
            return Task.FromResult(student.Id);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);
            
            if (entity == null)
                return false;

            _context.Students.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
           return await _context.Students.Include(s => s.Class).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students.Include(s => s.Class).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ListResult<Student>> GetPaginationAsync(int offset, int limit)
        {
            var totalCount = await _context.Students.CountAsync();

            var items = await _context.Students
                .Include(s => s.Class)
                .OrderBy(s => s.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return new ListResult<Student>
            {
                List = items,
                TotalCount = totalCount
            };
        }

        public Task<Guid> UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            return Task.FromResult(student.Id);
        }
    }
}
