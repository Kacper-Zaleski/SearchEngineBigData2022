using Microsoft.EntityFrameworkCore;
using SearchEngineRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SearchEngineDbContext>(options => options.UseSqlServer());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
