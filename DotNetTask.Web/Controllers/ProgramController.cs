using AutoMapper;
using DotNetTask.Application.Services;
using DotNetTask.Models.Applications;
using DotNetTask.Models.DTO.Programs;
using DotNetTask.Models.Programs;
using DotNetTask.Models.Workflows;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DotNetTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;
        private readonly IApplicationService _applicationService;
        private readonly IWorkflowService _workflowService;
        private readonly IMapper _mapper;

        public ProgramController(
            IProgramService programService,
            IMapper mapper,
            IApplicationService applicationService,
            IWorkflowService workflowService)
        {
            _programService = programService ?? throw new ArgumentNullException(nameof(programService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));
            _workflowService = workflowService;
        }

        // GET api/program
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await _programService.GetMultipleAsync("SELECT * FROM c"));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        // GET api/program/5
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

        // POST api/program
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProgramCreateDto item)
        {
            try
            {
                //item.Id = Guid.NewGuid().ToString();
                var model = _mapper.Map<ProgramModel>(item);
                model.Id = Guid.NewGuid().ToString();
                await _programService.AddAsync(model);
                var response = _mapper.Map<ProgramDto>(model);
                if (response.Id != null)
                {
                    //Add Application Form
                    var app = new ApplicationFormModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProgramId = response.Id
                    };
                    await _applicationService.AddAsync(app);


                    //Add Workflow
                    var workflow = new WorkflowModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProgramId = response.Id,
                        ShowHide = true,
                        StageName = "Applied"
                        
                    };
                    await _workflowService.AddAsync(workflow);

                };
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
           
        }

        // PUT api/program/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] ProgramDto item)
        {
            try
            {
                var model = _mapper.Map<ProgramModel>(item);
                await _programService.UpdateAsync(model.Id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
          
        }

        // DELETE api/program/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    await _programService.DeleteAsync(id);
        //    return NoContent();
        //}
    }
}
