using Exam.Application.Services.Interfaces;
using Exam.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
           _lessonService = lessonService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById([FromQuery] Guid Id)
        {
            return Ok(await _lessonService.GetByIdAsync(Id));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPagination([FromQuery] int offset, int limit)
        {
            return Ok(await _lessonService.GetPaginationAsync(offset, limit));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _lessonService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LessonRequestDto item)
        {
            return Ok(await _lessonService.AddAsync(item));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LessonRequestDto item)
        {
            return Ok(await _lessonService.UpdateAsync(item));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            return Ok(await _lessonService.DeleteAsync(Id));
        }
    }
}
