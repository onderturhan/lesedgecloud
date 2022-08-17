using EdgeCloud.LES.ClassLibrary.Core.DTOs.Request;
using EdgeCloud.LES.ClassLibrary.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/oops", () => "Oops! An error happened.");

app.MapPost("/file", ([FromBody] List<FileTransferDto> requestData) =>
{
    return FileConverterHelper.WriteFile(requestData);
})
.WithName("file");


app.Run();



