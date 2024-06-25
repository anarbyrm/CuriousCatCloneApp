using CuriousCatClone.Presistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// layer dependency injection
string connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddPersistenceLayerServices(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
