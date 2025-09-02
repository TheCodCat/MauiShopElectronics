using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using WebApi.Repositories;
using WebApiDatabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApiDatabaseContext>();
builder.Services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiDatabaseContext>();
    db.Database.Migrate();
}

    app.Run();
