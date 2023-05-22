
using CommentWHUCS.Models.DAO;
using CommentWHUCS.Models.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connnectionString = builder.Configuration.GetConnectionString("cwcDB");
builder.Services.AddDbContext<CWCDbContext>(opt =>
    opt.UseMySQL(connnectionString));

builder.Services.AddScoped<LogOnService>();
builder.Services.AddScoped<RTypeSearchService>();
builder.Services.AddScoped<RSRCHInfoService>();
builder.Services.AddScoped<CompInfoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
