
using Microsoft.EntityFrameworkCore;
using CommentWHUCS.Models.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<CWCDbContext>(opt =>
//    opt.UseInMemoryDatabase("server=localhost;uid=root;password=lpWZ38sql;database=evaldb"));
builder.Services.AddDbContext<CWCDbContext>(opt => opt.UseMySQL("server=localhost;uid=root;password=lpWZ38sql;database=evaldb")) ;  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
