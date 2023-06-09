using CommentWHUCS.DAO;
using CommentWHUCS.Models;
using CommentWHUCS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//�����ڴ滺��(�ò�������AddSession()����ǰʹ��)
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(2000);        //����session�Ĺ���ʱ��
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
//builder.Services.AddScoped<SessionService>();   //����
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
app.UseSession();       //��ӻỰ�м��
app.UseRouting();       //·���м��

app.UseAuthorization();

app.MapControllers();

app.Run();
