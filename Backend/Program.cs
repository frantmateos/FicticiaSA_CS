using Microsoft.EntityFrameworkCore;
using users.Models;
using users.Repo;
using users.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<userContext>(options =>
    options.UseMySql("Server=localhost;Database=users;User=root;Password=Tomas1927;Port=3306;",
                     new MySqlServerVersion(new Version(8, 0, 33))));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()  
                .AllowAnyMethod()   
                .AllowAnyHeader();  
        });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
