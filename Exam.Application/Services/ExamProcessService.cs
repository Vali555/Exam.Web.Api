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
    public class ExamProcessService:IExamProcessService
    {
        private readonly IExamProcessRepository _examProcessRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamProcessService(IUnitOfWork unitOfWork, IExamProcessRepository examProcessRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _examProcessRepository = examProcessRepository;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(ExamProcessRequestDto item)
        {
            item.Id = Guid.NewGuid();
            var examProcess = _mapper.Map<ExamProcess>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _examProcessRepository.AddAsync(examProcess);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return examProcess.Id;
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
                var result = await _examProcessRepository.DeleteAsync(Id);
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

        public async Task<IEnumerable<ExamProcessResponseDto>> GetAllAsync()
        {
            var data= await _examProcessRepository.GetAllAsync();
            var responseData=_mapper.Map<IEnumerable<ExamProcessResponseDto>>(data);
            return responseData;
        }

        public async Task<ExamProcessResponseDto?> GetByIdAsync(Guid id)
        {
            var data= await _examProcessRepository.GetByIdAsync(id);
            var responseData = _mapper.Map<ExamProcessResponseDto>(data);
            return responseData;
        }

        public async Task<ListResult<ExamProcessResponseDto>> GetPaginationAsync(int offset, int limit)
        {
            var data= await _examProcessRepository.GetPaginationAsync(offset, limit);
            var responseData = _mapper.Map<ListResult<ExamProcessResponseDto>>(data);
            return responseData;
        }

        public async Task<Guid> UpdateAsync(ExamProcessRequestDto item)
        {
            var examProcess = _mapper.Map<ExamProcess>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _examProcessRepository.UpdateAsync(examProcess);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return examProcess.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
