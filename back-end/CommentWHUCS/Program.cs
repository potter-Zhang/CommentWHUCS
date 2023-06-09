using CommentWHUCS.DAO;
using CommentWHUCS.Models;
using CommentWHUCS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//启用内存缓存(该步骤需在AddSession()调用前使用)
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(2000);        //设置session的过期时间
    options.Cookie.Name = "Session";
});



string? connnectionString = builder.Configuration.GetConnectionString("cwcDB");
builder.Services.AddDbContext<CWCDbContext>(opt =>
    opt.UseMySQL(connnectionString));

builder.Services.AddScoped<LogOnService>();
builder.Services.AddScoped<ResearchTypeSearchService>();
builder.Services.AddScoped<ResearchInfoService>();
builder.Services.AddScoped<CompetitionInfoService>();
builder.Services.AddScoped<CompetitionSearchService>();
builder.Services.AddScoped<StarService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<TeacherService>();
//builder.Services.AddScoped<SessionService>();   //存疑
builder.Services.AddCors(policy =>

{

    policy.AddPolicy("CorsPolicy", opt => opt

    .AllowAnyOrigin()

    .AllowAnyHeader()

    .AllowAnyMethod()

    .WithExposedHeaders("X-Pagination"));

});


var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseCors("CorsPolicy");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();       //添加会话中间件
app.UseRouting();       //路由中间件

app.UseAuthorization();

app.MapControllers();

app.Run();
