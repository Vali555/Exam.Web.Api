using AutoMapper;
using Exam.Application.Services.Interfaces;
using Exam.Common.DTOs;
using Exam.Common.Results;
using Exam.Domain.Entities;
using Exam.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(StudentDto item)
        {
            item.Id = Guid.NewGuid();
            var student=_mapper.Map<Student>(item);
            try
            {
               await _unitOfWork.BeginTransactionAsync();
               await _studentRepository.AddAsync(student);
               await _unitOfWork.SaveChangesAsync();
               await _unitOfWork.CommitAsync();
               return student.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result= await _studentRepository.DeleteAsync(Id);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<ListResult<Student>> GetPaginationAsync(int offset, int limit)
        {
            return await _studentRepository.GetPaginationAsync(offset, limit);
        }

        public async Task<Guid> UpdateAsync(StudentDto item)
        {
            var student = _mapper.Map<Student>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _studentRepository.UpdateAsync(student);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return student.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
