using Microsoft.EntityFrameworkCore;
using TaskManagment.Infrastructure.Persistance;
using TaskManagment.Application.Interfaces;
using TaskManagment.Infrastructure.Repositories;
using TaskManagment.Application.Features.Projects.CreateProject;
using TaskManagment.Application.Validation;
using TaskManagment.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<CreateProjectHandler>();
builder.Services.AddScoped<CreateProjectValidator>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();