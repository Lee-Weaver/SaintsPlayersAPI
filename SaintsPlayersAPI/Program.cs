using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaintsPlayersAPI.Data;
using SaintsPlayersAPI.Services.SaintsPlayerService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SaintsPlayerDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SaintsPlayerDataContext") ?? throw new InvalidOperationException("Connection string 'SaintsPlayerDataContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISaintsPlayerService, SaintsPlayerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
