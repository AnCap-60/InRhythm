using InRhythmServer;
using InRhythmServer.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

bool useMocks = true; // use any logic

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddUtils();


if (useMocks)
    builder.Services.AddMockServices();
else
{
    builder.Services.AddServices();
    builder.Services.AddDbContext<Database>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.MapSwagger();

app.Run();