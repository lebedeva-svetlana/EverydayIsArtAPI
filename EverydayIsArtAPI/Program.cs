using EverydayIsArtAPI.Services;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddSwaggerGen(oprions =>
{
    oprions.SwaggerDoc("v1", new OpenApiInfo { Title = "EverydayIsArt API", Version = "v1" });
});

var reactClient = "_reactClient";
builder.Services.AddCors(options => options.AddPolicy(name: reactClient,
    policy =>
    {
        policy.WithOrigins("https://everydayisart.ru/")
              .AllowAnyMethod()
              .AllowAnyHeader();
    }
));

builder.Services.AddScoped<IHTMLService, HTMLService>();

builder.Services.AddScoped<ITretyakovService, TretyakovService>();
builder.Services.AddScoped<IVamService, VamService>();
builder.Services.AddScoped<IMetmuseumService, MetmuseumService>();
builder.Services.AddScoped<IAllService, AllService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(reactClient);
//app.UseHttpsRedirection();

app.MapControllers();

app.Run();