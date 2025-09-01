using Authorization.Service;
using Microsoft.EntityFrameworkCore;
using MyWebApi.BI.Mapping;
using MyWebApi.Core.Contract;
using MyWebApi.Data.DAL.AppDB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserMapping>();
builder.Services.AddScoped<IDeptRepo, DeptRepository>();
builder.Services.AddScoped<IDeptService, DeptService>();
builder.Services.AddScoped<Deptmapping>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


