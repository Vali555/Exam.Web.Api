using Exam.Application.Services.Interfaces;
using Exam.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById([FromQuery] Guid Id)
        {
            return Ok(await _classService.GetByIdAsync(Id));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPagination([FromQuery] int offset, int limit)
        {
            return Ok(await _classService.GetPaginationAsync(offset, limit));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _classService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClassrequestDto item)
        {
            return Ok(await _classService.AddAsync(item));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClassrequestDto item)
        {
            return Ok(await _classService.UpdateAsync(item));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            return Ok(await _classService.DeleteAsync(Id));
        }
    }
}
