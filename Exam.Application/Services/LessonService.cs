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
    public class LessonService:ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LessonService(IUnitOfWork unitOfWork, ILessonRepository lessonRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
          _lessonRepository = lessonRepository;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(LessonRequestDto item)
        {
            item.Id = Guid.NewGuid();
            var lesson = _mapper.Map<Lesson>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _lessonRepository.AddAsync(lesson);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return lesson.Id;
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
                var result = await _lessonRepository.DeleteAsync(Id);
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

        public async Task<IEnumerable<LessonResponseDto>> GetAllAsync()
        {
            var data= await _lessonRepository.GetAllAsync();
            var responseData = _mapper.Map<IEnumerable<LessonResponseDto>>(data);
            return responseData;
        }

        public async Task<LessonResponseDto?> GetByIdAsync(Guid id)
        {
            var data= await _lessonRepository.GetByIdAsync(id);
            var responseData=_mapper.Map<LessonResponseDto>(data);
            return responseData;
        }

        public async Task<ListResult<LessonResponseDto>> GetPaginationAsync(int offset, int limit)
        {
            var data= await _lessonRepository.GetPaginationAsync(offset, limit);
            var responseData=_mapper.Map<ListResult<LessonResponseDto>>(data);
            return responseData;
        }

        public async Task<Guid> UpdateAsync(LessonRequestDto item)
        {
            var lesson = _mapper.Map<Lesson>(item);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _lessonRepository.UpdateAsync(lesson);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return lesson.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
