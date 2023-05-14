using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Infra.Context;
using Todo.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados em memória
//builder.Services.AddDbContext<TodoContext>(options => options.UseInMemoryDatabase("Database"));
builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDb")));

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/todos-bae6f";
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer= true, // Valida quem tá mandando o token 
                        ValidIssuer = "https://securetoken.google.com/todos-bae6f", // Como eu valido esse token? No servidor do google
                        ValidateAudience= true, // Quero validar o app?
                        ValidAudience = "todos-bae6f", // Valida o APP
                        ValidateLifetime= true // Valida o tempo de vida do token 
                    };
                });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
