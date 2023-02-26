using System.Data;
using System.Reflection;
using Dapper_Data_Access_Layer.Context;
using Dapper_Data_Access_Layer.Repository.Contracts;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Swagger Example-Dapper-Migration API",
        Description = "Base Swagger Description"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    s.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection connection = s.GetRequiredService<SqlConnection>();
    connection.Open();
    return connection.BeginTransaction();
});

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddControllers();

// Dependency Injections 
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSwagger();

app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API Version");
    s.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
