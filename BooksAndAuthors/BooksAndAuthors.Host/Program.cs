using System.Text;
using AutoMapper;
using BooksAndAuthors.Auth;
using BooksAndAuthors.Auth.Services;
using BooksAndAuthors.Controllers;
using BooksAndAuthors.Controllers.Services;
using BooksAndAuthors.Controllers.Services.Interfaces;
using BooksAndAuthors.Database;
using BooksAndAuthors.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mapper = BooksAndAuthors.Common.Mappings.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<PasswordHasher>();   
builder.Services.AddScoped<JwtTokenHandler>();
builder.Services.AddScoped<JwtOptions>();
builder.Services.AddSwagger();
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var signingCredentials =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SecurityKey));
        
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidIssuer = JwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = JwtOptions.Audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingCredentials
        };
    });
builder.Services.AddAuthorization();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();

app.Run();