using Microsoft.AspNetCore.Mvc;
using System;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.MapGet("/home", () =>
{
    return "[GET] Running home ...";
});

app.MapPost("/home", () =>
{
    return "[POST] Running home ...";
});


app.MapGet("/", () =>
{
    return "[GET] Running ...";
});

app.MapPost("/", () =>
{
    return "[POST] Running ...";
});


app.MapGet("/help", () =>
{
    return "[GET] Running help ...";
});

app.MapPost("/help", () =>
{
    return "[POST] Running help ...";
});


app.MapGet("/ping/{id}", ([FromQuery] string id) =>
{
    return $"[GET] Running ping id: {id}...";
});

app.MapPost("/ping", async ([FromBody] Person person) =>
{
    return $"[POST] Running ping name: {person.Name}...";
});

app.Run();


record Person(string Name, int Age);


