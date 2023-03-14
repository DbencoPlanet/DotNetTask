using AutoMapper;
using DotNetTask.Application;
using DotNetTask.Application.Services;
using DotNetTask.Models.Applications;
using DotNetTask.Models.DTO.Applications;
using DotNetTask.Models.DTO.Programs;
using DotNetTask.Models.DTO.Workflows;
using DotNetTask.Models.Programs;
using DotNetTask.Models.Workflows;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Reflection;

namespace DotNetTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WorkflowController : ControllerBase
    {
        private static readonly string _serverPath = ServerPath.RootPath();
        private readonly IWorkflowService _workflowService;
        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }

        public WorkflowController(
            IMapper mapper,
            IWorkflowService workflowService,
            IConfiguration configuration

            )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _workflowService = workflowService ?? throw new ArgumentNullException(nameof(workflowService));
            Configuration = configuration;
        }

        // GET api/workflow
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await _workflowService.GetMultipleAsync("SELECT * FROM c"));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
           
        }

        // GET api/workflow/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await _workflowService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
           
        }

        // PUT api/workflow/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] WorkflowDto item)
        {
            try
            {
                List<VideoQuestionDto> vid = new List<VideoQuestionDto>();
                foreach (var itemlist in item.VideoInterview)
                {
                    if (itemlist != null)
                    {
                        itemlist.VideoUrl = await ConvertBase64toUrl(itemlist.VideoBase64String);
                        vid.Add(itemlist);


                    }
                }
                item.VideoInterview = vid;
                var model = _mapper.Map<WorkflowModel>(item);

                await _workflowService.UpdateAsync(model.Id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        [NonAction]
        public async Task<string> ConvertBase64toUrl(string base64String)
        {
            try
            {
                var siteUrl = Configuration.GetSection("AppSettings").GetValue<string>("appurl");
                string filepath = Path.Combine(_serverPath, "files/");

                byte[] imageBytes = Convert.FromBase64String(base64String);

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }

                string name = "QuestionVideo.mp4";
                string guid = Guid.NewGuid().ToString();
                string guid2 = guid.Replace("-", "");

                filepath = filepath + guid2 + name;

                System.IO.File.WriteAllBytes(filepath, imageBytes);
                var response = $"{siteUrl}/{filepath}";
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
