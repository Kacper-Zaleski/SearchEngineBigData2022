using Microsoft.EntityFrameworkCore;
using SearchEngine.Repository;
using SearchEngine.UseCase.SearchBooksUseCase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SearchEngineDbContext>(options =>
{
    options.UseSqlServer();
});

builder.Services.AddTransient<ISearchBooksUseSace, SearchBooksUseSace>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
