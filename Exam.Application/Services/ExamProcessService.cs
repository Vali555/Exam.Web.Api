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
        public async Task<Guid> AddAsync(ExamProcessDto item)
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

        public async Task<IEnumerable<ExamProcess>> GetAllAsync()
        {
            return await _examProcessRepository.GetAllAsync();
        }

        public async Task<ExamProcess?> GetByIdAsync(Guid id)
        {
            return await _examProcessRepository.GetByIdAsync(id);
        }

        public async Task<ListResult<ExamProcess>> GetPaginationAsync(int offset, int limit)
        {
            return await _examProcessRepository.GetPaginationAsync(offset, limit);
        }

        public async Task<Guid> UpdateAsync(ExamProcessDto item)
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
