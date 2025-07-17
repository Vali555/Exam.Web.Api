using Exam.Application.Services.Interfaces;
using Exam.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamProcessController : ControllerBase
    {
        private readonly IExamProcessService _examProcessService;
        public ExamProcessController(IExamProcessService  examProcessService)
        {
            _examProcessService = examProcessService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById([FromQuery] Guid Id)
        {
            return Ok(await _examProcessService.GetByIdAsync(Id));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPagination([FromQuery] int offset, int limit)
        {
            return Ok(await _examProcessService.GetPaginationAsync(offset, limit));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _examProcessService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ExamProcessDto item)
        {
            return Ok(await _examProcessService.AddAsync(item));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExamProcessDto item)
        {
            return Ok(await _examProcessService.UpdateAsync(item));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            return Ok(await _examProcessService.DeleteAsync(Id));
        }
    }
}
