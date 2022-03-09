using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.ApplicationCore;
using Store.Infrastructure;
using FluentValidation.AspNetCore;
using FluentValidation;
using Store.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationCore();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPagination(builder.Configuration);
//builder.Services.AddControllers();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
})
            .ConfigureApiBehaviorOptions(options =>
            {
                //options.SuppressModelStateInvalidFilter = true;
            });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureFluentValidation();

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
