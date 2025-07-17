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
        public async Task<Guid> AddAsync(StudentRequestDto item)
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

        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            var data= await _studentRepository.GetAllAsync();
            var responseData = _mapper.Map<IEnumerable<StudentResponseDto>>(data);
            return responseData;
        }

        public async Task<StudentResponseDto?> GetByIdAsync(Guid id)
        {
            var data= await _studentRepository.GetByIdAsync(id);
            var responseData=_mapper.Map<StudentResponseDto>(data);
            return responseData;
        }

        public async Task<ListResult<StudentResponseDto>> GetPaginationAsync(int offset, int limit)
        {
            var data= await _studentRepository.GetPaginationAsync(offset, limit);
            var responseData = _mapper.Map<ListResult<StudentResponseDto>>(data);
            return responseData;

        }

        public async Task<Guid> UpdateAsync(StudentRequestDto item)
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
