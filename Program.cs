using Microsoft.EntityFrameworkCore;
using PhoneApp.Abstractions;
using PhoneApp.Data;
using PhoneApp.Services;
using Serilog;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Services

// Dependency Injection
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();

// DbContext (MySQL) - connection string appsettings.json-dan oxunur
builder.Services.AddDbContext<PhoneDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 3))
    );
});

// Controllers + JSON Config
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver =
        new CamelCasePropertyNamesContractResolver();
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Serilog

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

#endregion

var app = builder.Build();

#region Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

#endregion

app.Run();
