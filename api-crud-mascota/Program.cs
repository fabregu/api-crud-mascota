using api_crud_mascota.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

//Agregar Cors
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        app => app.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});*/

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});

//context
builder.Services.AddDbContext<MascotaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseCors("CorsPolicy");
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();