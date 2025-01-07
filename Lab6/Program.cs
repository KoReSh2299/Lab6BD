using AutoMapper;
using Kursach.Application;
using Kursach.Application.Requests.Queries;
using Lab6.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.ConfigureCors();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureServices();

builder.Services.AddEndpointsApiExplorer();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetClientsQuery).Assembly));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = "swagger"; // Открывать по корневому пути
    });
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Для маршрутов API
    endpoints.MapFallbackToFile("clients.html"); // Для статических файлов
});

app.Run();

