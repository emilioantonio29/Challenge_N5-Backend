using ChallengeN5.Data.ChallengeN5_DbContext;
using ChallengeN5.Data.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ChallengeN5DbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ONLY FOR THIS CHALLENGE PURPOSE
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ChallengeN5DbContext>();

    dbContext.Database.EnsureCreated();

    if (dbContext.Users.FirstOrDefault(u => u.Username == "admin") == null)
    {
        var adminUser = new User
        {
            Username = "admin",
            Password = "admin"
        };

        dbContext.Users.Add(adminUser);
        dbContext.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
