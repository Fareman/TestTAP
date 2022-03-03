using System.Reflection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Serilog;

using TestTAP.Data;
using TestTAP.Services;
using TestTAP.Services.Interfaces;

using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (ctx, lc) => lc
                 .WriteTo.Console()
                 .WriteTo.File("log.log"));

builder.Services.AddMvc()
       .ConfigureApiBehaviorOptions(
           options =>
           {
               options.InvalidModelStateResponseFactory = context =>
               {
                   // Get an instance of ILogger (see below) and log accordingly.
                   using var serviceProvider = builder.Services.BuildServiceProvider();

                   var logger = serviceProvider.GetRequiredService<ILogger>();

                   logger.Error("Insert the correct value.");

                   return new BadRequestObjectResult(context.ModelState);
               };
           });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

builder.Services.AddDbContext<PersonContext>(
    optionsBuilder => { optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("PersonDatabase")); });

builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

var log = new LoggerConfiguration().CreateLogger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "My API V1"); });
}

app.MapControllers();

app.Run();