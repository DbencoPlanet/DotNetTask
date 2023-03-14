using AutoMapper;
using DotNetTask.Application.MapProfile;
using DotNetTask.Application.Services;
using DotNetTask.Models.DTO.Programs;
using DotNetTask.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.UnitTest
{
    public class ProgramControllerTest
    {
        private readonly ProgramController _controller;
        private readonly IProgramService _programService;
        private readonly IApplicationService _appService;
        private readonly IWorkflowService _workflowService;
        //private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = new MapperConfiguration(
       cfg =>
       {
           cfg.AddProfile(new MappingProfile());
       });


        //public IConfiguration _configuration { get; }


        public ProgramControllerTest(
           //IMapper mapper,
           //IConfiguration configuration
           )
        {


            //_configuration =  configuration;
            IConfiguration _configuration = new ConfigurationBuilder().Build();

            var url = "https://localhost:8081";
            var primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
            var dbName = "ProgramDB";
            var pcontainerName = "PContainer2";
            var acontainerName = "AContainer";
            var wcontainerName = "WContainer";


            var cosmosClient = new CosmosClient(url, primaryKey);
            _programService = new ProgramService(cosmosClient, dbName, pcontainerName);
            _appService = new ApplicationService(cosmosClient, dbName, acontainerName);
            _workflowService = new WorkflowService(cosmosClient, dbName, wcontainerName);
            IMapper mapper = new Mapper(mapperConfig);
            _controller = new ProgramController(_programService, mapper, _appService, _workflowService);

        }

        [Fact]
        public async void List_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = await _controller.List();


            // Assert
            //var items = Assert.IsType<List<ProgramDto>>(okResult);
            //Assert.Equal(3, items.Count);

            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public async void Get_WhenCalled_ReturnsItemsById()
        {
            //Arrange
            var testGuid = "7a4c8271-2d7f-4250-a99f-6489d28efb2b";

            // Act
            var okResult = await _controller.Get(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public async void Create_WhenCalled_ReturnsCreatedAtActionResult()
        {
            //Arrange

            var skills = new List<Skills>()
                {
                    new Skills { Skill ="Testing Skill 1"},
                    new Skills {Skill ="Testing Skill 2"}
                }.ToList();

            var myData = new ProgramCreateDto
            {
                //Id = Guid.NewGuid().ToString(),
                ApplicationClose = DateTime.Now,
                ApplicationOpen = DateTime.Now,
                MaxApplication = 30,
                Benefits = "Testing purpose",
                Criteria = "Testing",
                Description = "This is just for testing",
                Duration = "3 Months",
                Location = "Testing Location",
                MinQualification = "Testing Qualification",
                ProgramStart = DateTime.Now,
                ProgramType = "Testing Type",
                Title = "Testing Title",
                Skills = skills,
                Summary = "Testing Summary"
                

            };

            // Act
            var createdResponse = await _controller.Create(myData);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);


        }


        [Fact]
        public async void Edit_WhenCalled_ReturnsNoContentResult()
        {
            //Arrange

            var skills = new List<Skills>()
                {
                    new Skills { Skill ="Testing Skill 1"},
                    new Skills {Skill ="Testing Skill 2"}
                }.ToList();

            var myData = new ProgramDto
            {
                Id = "7a4c8271-2d7f-4250-a99f-6489d28efb2b",
                ApplicationClose = DateTime.Now,
                ApplicationOpen = DateTime.Now,
                MaxApplication = 30,
                Benefits = "Testing purpose",
                Criteria = "Testing",
                Description = "This is just for testing",
                Duration = "3 Months",
                Location = "Testing Location",
                MinQualification = "Testing Qualification",
                ProgramStart = DateTime.Now,
                ProgramType = "Testing Type",
                Title = "Testing Title",
                Skills = skills

            };

            // Act
            var createdResponse = await _controller.Edit(myData);
            // Assert
            Assert.IsType<NoContentResult>(createdResponse);


        }
    }
}
