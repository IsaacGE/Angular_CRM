using Angular_CRM.DataServices.DBContext;
using Angular_CRM.DataServices.Statics;
using log4net.Config;
using log4net;
using Microsoft.EntityFrameworkCore;
using Angular_CRM.Server.Helpers;


var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;
var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo(Path.Combine(AppContext.BaseDirectory, $"log4net.{env}.config")));

var log = new Logger();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

Values.DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";


if (string.IsNullOrEmpty(Values.DefaultConnection))
{
    log.Error("Default Connection was not found in the appsettings file or has no value.");
    throw new NullReferenceException("There was an error on start the application, see the logs for more information.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(Values.DefaultConnection)
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

log.Info("API Server Started successfully");

app.Run();
