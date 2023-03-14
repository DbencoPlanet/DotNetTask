using AutoMapper;
using DotNetTask.Application.MapProfile;
using DotNetTask.Application.Services;
using DotNetTask.Models.DTO.Applications;
using DotNetTask.Models.DTO.Programs;
using DotNetTask.Models.DTO.Workflows;
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
    public class PreviewControllerTest
    {
        private readonly PreviewController _controller;
        private readonly IProgramService _programService;
        MapperConfiguration mapperConfig = new MapperConfiguration(
       cfg =>
       {
           cfg.AddProfile(new MappingProfile());
       });

        public PreviewControllerTest(

           )
        {

            var url = "https://localhost:8081";
            var primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
            var dbName = "ProgramDB";
            var wcontainerName = "PContainer";


            var cosmosClient = new CosmosClient(url, primaryKey);
            _programService = new ProgramService(cosmosClient, dbName, wcontainerName);
            IMapper mapper = new Mapper(mapperConfig);
            _controller = new PreviewController(mapper, _programService);

        }

        [Fact]
        public async void Get_WhenCalled_ReturnsItemsById()
        {
            //Arrange
            var testGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";

            // Act
            var okResult = await _controller.Get(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

    }
}
