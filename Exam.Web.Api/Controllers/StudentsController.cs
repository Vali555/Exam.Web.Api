using Exam.Application.Services.Interfaces;
using Exam.Common.DTOs;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById([FromQuery] Guid Id)
        {
            return Ok(await _studentService.GetByIdAsync(Id));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPagination([FromQuery] int offset, int limit)
        {
            return Ok(await _studentService.GetPaginationAsync(offset, limit));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentRequestDto item)
        {
            return Ok(await _studentService.AddAsync(item));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StudentRequestDto item)
        {
            return Ok(await _studentService.UpdateAsync(item));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            return Ok(await _studentService.DeleteAsync(Id));
        }
    }
}
