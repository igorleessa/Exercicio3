var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Ambiente de Desenvolvimento");
}else if (app.Environment.IsStaging())
{
    Console.WriteLine("Ambiente de Homologação");
}else if (app.Environment.IsProduction())
{
    Console.WriteLine("Ambiente de Produção");
    
}

Console.WriteLine($"Ambiente appsSettings.json:  {builder.Configuration.GetValue<string>("Ambiente")}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
