using Microsoft.EntityFrameworkCore;
using CommentWHUCS.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
string? connnectionString = builder.Configuration.GetConnectionString("cwcDB");
builder.Services.AddDbContext<CWCDbContext>(opt =>
    opt.UseMySQL(connnectionString));
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


// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

/*
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
*/