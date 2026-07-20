using Microsoft.EntityFrameworkCore;
using Data;

var builder = WebApplication.CreateBuilder(args);

var DefaultConnectionSQLiteConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlite<AppDbContext>(DefaultConnectionSQLiteConnectionString);
builder.Services.AddCors(options =>
{
    options.AddPolicy("All", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("http://localhost:5000/swagger");
Console.WriteLine("click to swagger");



var app = builder.Build();

string wwwRoot = app.Environment.WebRootPath;
string contentRoot = app.Environment.ContentRootPath;

// เปิดใช้งาน Default Files (เช่น index.html)
app.UseDefaultFiles();

// เปิดใช้งาน Static Files ใน wwwroot
app.UseStaticFiles();

Console.WriteLine(wwwRoot);
Console.WriteLine(contentRoot);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // เปิดใช้งาน UI ของ Swagger
}

app.UseHttpsRedirection();
app.UseCors("All");
app.UseAuthorization();
app.MapControllers();

app.Run();
