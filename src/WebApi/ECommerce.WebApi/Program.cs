using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using ECommerce.Application;
using ECommerce.Infrastructure;
using ECommerce.Persistance;
using ECommerce.WebApi.Middlewares;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;

builder.Services.AddPersistanceRegistration(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationRegistration();
builder.Services.AddInfrastructureRegistration(configuration);
builder.Services.AddHealthChecks();

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn("UserName",System.Data.SqlDbType.VarChar)
    }
};

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), "Logs",
        autoCreateSqlTable: true, columnOptions: columnOptions)
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseSerilogRequestLogging();
app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseCustomException<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var userName = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : "Guest";

    LogContext.PushProperty("user_name", userName);

    await next();
});

app.MapControllers();

app.Run();
