using AutoMapper;
using DotNetTask.Application.Services;
using DotNetTask.Models.Applications;
using DotNetTask.Models.DTO.Applications;
using DotNetTask.Models.DTO.Programs;
using DotNetTask.Models.DTO.Workflows;
using DotNetTask.Models.Programs;
using DotNetTask.Models.Workflows;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DotNetTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PreviewController : ControllerBase
    {
        private readonly IProgramService _programService;
        private readonly IMapper _mapper;

        public PreviewController(
            IMapper mapper,
            IProgramService programService
            )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _programService = programService ?? throw new ArgumentNullException(nameof(programService));
        }

        // GET api/preview/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await _programService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

    }
}
