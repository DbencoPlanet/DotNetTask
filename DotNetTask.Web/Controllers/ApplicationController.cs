using AutoMapper;
using DotNetTask.Application;
using DotNetTask.Application.Services;
using DotNetTask.Models.Applications;
using DotNetTask.Models.DTO.Applications;
using DotNetTask.Models.DTO.Programs;
using DotNetTask.Models.Programs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Reflection;

namespace DotNetTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApplicationController : ControllerBase
    {
        private static readonly string _serverPath = ServerPath.RootPath();
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }

        public ApplicationController(
            IMapper mapper,
            IApplicationService applicationService,
            IConfiguration configuration
            )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));
            Configuration = configuration;
        }

        // GET api/application
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await _applicationService.GetMultipleAsync("SELECT * FROM c"));
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            

        }

        // GET api/application/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await _applicationService.GetAsync(id));
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        // PUT api/application/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] ApplicationFormDto item)
        {
            try
            {
                var getcoverurl = await ConvertBase64toUrl(item.CoverPhotoBase64String);
                var model = _mapper.Map<ApplicationFormModel>(item);
                model.CoverPhotoUrl = getcoverurl;
                await _applicationService.UpdateAsync(model.Id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }


        /// <summary>
        /// Convert Image Base64String to image Url and save file
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
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

                string name = "CoverPhoto.png";
                string guid = Guid.NewGuid().ToString();
                string guid2 = guid.Replace("-", "");

                filepath = filepath + guid2 + name;

                System.IO.File.WriteAllBytes(filepath, imageBytes);
                var response = $"{siteUrl}/{filepath}";
                return response;
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }

        }

    }
}
