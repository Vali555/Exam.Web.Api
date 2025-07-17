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
    public class ClassService:IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClassService(IUnitOfWork unitOfWork, IClassRepository  classRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _classRepository = classRepository;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(ClassDto item)
        {
            item.Id = Guid.NewGuid();
            var classItem = _mapper.Map<Class>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _classRepository.AddAsync(classItem);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return classItem.Id;
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
                var result = await _classRepository.DeleteAsync(Id);
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

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _classRepository.GetAllAsync();
        }

        public async Task<Class?> GetByIdAsync(Guid id)
        {
            return await _classRepository.GetByIdAsync(id);
        }

        public async Task<ListResult<Class>> GetPaginationAsync(int offset, int limit)
        {
            return await _classRepository.GetPaginationAsync(offset, limit);
        }

        public async Task<Guid> UpdateAsync(ClassDto item)
        {
            var classItem = _mapper.Map<Class>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _classRepository.UpdateAsync(classItem);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return classItem.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
