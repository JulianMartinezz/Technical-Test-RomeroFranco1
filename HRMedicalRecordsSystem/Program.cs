using AutoMapper;
using FluentValidation.AspNetCore;
using HRMedicalRecordsSystem.Context;
using HRMedicalRecordsSystem.Repositories.implementaciones;
using HRMedicalRecordsSystem.Repositories.interfaces;
using HRMedicalRecordsSystem.Services.Implementaciones;
using HRMedicalRecordsSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HRMedicalContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IHRMedicalRecordRepository,HRMedicalRecordRepository>();
builder.Services.AddScoped<IServiceHRMedicalRecords, ServiceHRMedicalRecords>();
builder.Services.AddFluentValidation((opt) =>
{
    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
