using CuriousCatClone.Api.Middlewares;
using CuriousCatClone.Application;
using CuriousCatClone.Infrastructure;
using CuriousCatClone.Presistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// layer dependency injection
string connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureLayerServices();
builder.Services.AddPersistenceLayerServices(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
