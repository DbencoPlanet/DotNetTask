using AutoMapper;
using DotNetTask.Application;
using DotNetTask.Application.Services;
using DotNetTask.Models.Programs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using Xunit;

namespace DotNetTask.UnitTest
{
    public class AllTests
    {
        private ServiceProvider _serviceProvider;

        //private string url = "https://localhost:8081";
        //private string primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        //private string dbName = "ProgramDB";

        //public ServiceProvider ServiceProvider { get; private set; }

       

       

        [Fact]
        public async Task MyProgramCreateAsync()
        {
           
            var serviceCollection = new ServiceCollection();
           
            serviceCollection.AddScoped<ProgramService>();

            _serviceProvider = serviceCollection.BuildServiceProvider();

            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var skills = new List<Skills>()
                {
                    new Skills { Skill ="Testing Skill 1"},
                    new Skills {Skill ="Testing Skill 2"}
                }.ToList();

                var myData = new ProgramModel
                {
                    Id = Guid.NewGuid().ToString(),
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

                var myDataService = scope.ServiceProvider.GetService<ProgramService>();
                await myDataService.AddAsync(myData);

                // Act

                var first = await myDataService.GetAsync(myData.Id);

                // Arrange
                Assert.Equal(myData.Id, first.Id);
            }
        }

    }
}