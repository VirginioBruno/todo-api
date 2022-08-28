using Microsoft.EntityFrameworkCore;
using Todo.Api.Models;
using Todo.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();

var connection = configuration.GetValue<string>("ConnectionStrings:Todo");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();

app.Run();


public partial class Program
{
}
