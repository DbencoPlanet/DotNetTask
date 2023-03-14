
using DotNetTask.Application.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var url = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("URL");
var primaryKey = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("PrimaryKey");
var dbName = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("DatabaseName");


var cosmosClient = new CosmosClient(
    url,
    primaryKey
);


builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IProgramService>(options =>
{
    var containerName = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("ProgramContainerName");
    return new ProgramService(cosmosClient, dbName, containerName);
});

builder.Services.AddSingleton<IApplicationService>(options =>
{
    var containerName = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("ApplicationContainerName");
    return new ApplicationService(cosmosClient, dbName, containerName);
});

builder.Services.AddSingleton<IWorkflowService>(options =>
{
    var containerName = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("WorkflowContainerName");
    return new WorkflowService(cosmosClient, dbName, containerName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "files")),
    RequestPath = "/files",
    EnableDefaultFiles = false,
    EnableDirectoryBrowsing = false
});

app.MapControllers();

app.Run();
