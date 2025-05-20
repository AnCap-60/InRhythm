using System.Text;
using InRhythmServer;
using InRhythmServer.Models;
using InRhythmServer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

bool useMocks = false; // use any logic

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

const string secretKey = "123456789"; // TODO: to secrets

builder.Services.AddSingleton(new TokenService(secretKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

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