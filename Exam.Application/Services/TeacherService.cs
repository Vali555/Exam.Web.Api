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
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherService(IUnitOfWork unitOfWork, ITeacherRepository teacherRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(TeacherDto item)
        {
            item.Id = Guid.NewGuid();
            var teacher = _mapper.Map<Teacher>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _teacherRepository.AddAsync(teacher);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return teacher.Id;
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
                var result = await _teacherRepository.DeleteAsync(Id);
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

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teacher?> GetByIdAsync(Guid id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task<ListResult<Teacher>> GetPaginationAsync(int offset, int limit)
        {
            return await _teacherRepository.GetPaginationAsync(offset, limit);
        }

        public async Task<Guid> UpdateAsync(TeacherDto item)
        {
            var teacher = _mapper.Map<Teacher>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _teacherRepository.UpdateAsync(teacher);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return teacher.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
