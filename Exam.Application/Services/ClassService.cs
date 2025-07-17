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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<Guid> AddAsync(ClassrequestDto item)
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

        public async Task<IEnumerable<ClassResponseDto>> GetAllAsync()
        {
            var data = await _classRepository.GetAllAsync();
            var responseData = _mapper.Map<IEnumerable<ClassResponseDto>>(data);
            return responseData;
        }

        public async Task<ClassResponseDto?> GetByIdAsync(Guid id)
        {
            var data= await _classRepository.GetByIdAsync(id);
            var responseData = _mapper.Map<ClassResponseDto>(data);
            return responseData;
        }

        public async Task<ListResult<ClassResponseDto>> GetPaginationAsync(int offset, int limit)
        {
            var data= await _classRepository.GetPaginationAsync(offset, limit);
            var responseData = _mapper.Map<ListResult<ClassResponseDto>>(data);
            return responseData;
        }

        public async Task<Guid> UpdateAsync(ClassrequestDto item)
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
