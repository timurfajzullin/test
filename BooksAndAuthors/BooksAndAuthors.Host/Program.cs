using AutoMapper;
using BooksAndAuthors.Common.Mappings;
using BooksAndAuthors.Controllers;
using BooksAndAuthors.Controllers.Services;
using BooksAndAuthors.Database;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddDbContext<IBookContext, BookContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BookContext"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();