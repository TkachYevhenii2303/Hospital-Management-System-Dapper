using System.Data;
using System.Reflection;
using Dapper_Data_Access_Layer.Entities_Repositories;
using Dapper_Data_Access_Layer.Entities_Repositories.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Services;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Services.Interfaces;
using Hospital_Management_System_API.Mapping;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add AutoMapper for working with Data-transfer-objects
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add services to the container.
builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Seth the configurations for the Swagger and uncluding xml comments to the actions
builder.Services.AddSwaggerGen(options =>
{
    // Swagger options and naming: 
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Hospital Management System Data Model in Swagger!",
        Description = "Visiting a hospital or a clinic is never pleasant, but it would be even worse if our health records were in chaos. Not so long ago, all medical documents were in paper form. This not only polluted the environment, it slowed down the whole process. Fortunately for us, technology has had a significant impact in the medical record field. Most health records are automated, which saves a lot of bother."
    });

    // Including xml comments for inserting commment in Swagger: 
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Set the connections to the database: 
builder.Services.AddScoped<SqlConnection>(configurations => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbTransaction>(configurations =>
{
    // Opening the connection:
    SqlConnection connection = configurations.GetRequiredService<SqlConnection>();
    connection.Open();
    return connection.BeginTransaction();
});

// Including all Dependenciens for the Container 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnit_of_Work, Unit_of_Work>();

builder.Services.AddScoped<IEmployees_Services, Employees_Services>();

var app = builder.Build();

// Set the configurations for the Swagger endpoints (routes) 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API Version");
        s.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
