using Exam.Application.Services.Interfaces;
using Exam.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById([FromQuery] Guid Id)
        {
            return Ok(await _teacherService.GetByIdAsync(Id));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPagination([FromQuery] int offset, int limit)
        {
            return Ok(await _teacherService.GetPaginationAsync(offset, limit));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _teacherService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeacherDto item)
        {
            return Ok(await _teacherService.AddAsync(item));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TeacherDto item)
        {
            return Ok(await _teacherService.UpdateAsync(item));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            return Ok(await _teacherService.DeleteAsync(Id));
        }
    }
}
