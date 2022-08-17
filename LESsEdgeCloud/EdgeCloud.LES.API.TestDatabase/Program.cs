using Microsoft.EntityFrameworkCore;
using EdgeCloud.LES.API.TestDatabase.Data;
var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("EdgeCloudLESAPITestDatabaseConnectionString");

builder.Services.AddDbContext<EdgeCloudLESAPITestDatabaseContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.Create(
            new Version(10, 7),
            Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb),
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(60), null);
        })
);

// Add services to the container.

builder.Services.AddControllers();
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
