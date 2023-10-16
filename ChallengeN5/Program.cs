using ChallengeN5.Business.Process;
using ChallengeN5.Data.ChallengeN5_DbContext;
using ChallengeN5.Data.Entities;
using ChallengeN5.Data.Repositories.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ChallengeN5DbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<UserProcess>();
builder.Services.AddScoped<PermissionProcess>();
builder.Services.AddScoped<UserRepository>();
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

    if(dbContext.PermissionTypes.Count() < 2) 
    {
        for (int i = 0; i < 2; i++) 
        {
            var permissionType = new PermissionType
            {
                Description = "Description " + i+1 
            };

            dbContext.PermissionTypes.Add(permissionType);
        }

        dbContext.SaveChanges();
    }

    if (dbContext.Permissions.Count() < 7)
    {

        var permissionType = dbContext.PermissionTypes.FirstOrDefault();

        if (permissionType != null)
        {            
            for (int i = 0; i < 10; i++)
            {
                var permissionObject = new Permission
                {
                    Name = "name" + i + 1,
                    Lastname = "test2" + i + 1,
                    PermissionType = permissionType,
                    PermissionTypeId = permissionType.Id,
                    Date = new DateTime()
                };

                dbContext.Permissions.Add(permissionObject);
            }

            dbContext.SaveChanges();
        }
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
