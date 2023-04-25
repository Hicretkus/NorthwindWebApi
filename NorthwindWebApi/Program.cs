using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Northwind.Api.Helpers;
using Northwind.Application.Repository;
using Northwind.Infrastructure.Persistence;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ConnectionHelper>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<EmployeeRepository>();
//builder.Services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer(builder.Configuration.
//	GetConnectionString("SqlConnection")));
builder.Services.AddDbContext<NorthwindDbContext>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
	{
		option.MigrationsAssembly(Assembly.GetAssembly(typeof(NorthwindDbContext)).GetName().Name);
	});
});
//builder.Services.AddSwaggerGen(c =>
//{
//	c.IncludeXmlComments(string.Format(@"{0}\Dapper.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
//	c.SwaggerDoc("v1", new OpenApiInfo
//	{
//		Version = "v1",
//		Title = "Dapper - WebApi",
//	});
//});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dapper.WebApi");
	});
	//app.UseSwagger();
	//app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
