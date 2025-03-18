using AutoMapper;
using BooksAndAuthors.Controllers;
using BooksAndAuthors.Controllers.Services;
using BooksAndAuthors.Database;
using Microsoft.EntityFrameworkCore;
using Mapper = BooksAndAuthors.Common.Mappings.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Mapper));

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