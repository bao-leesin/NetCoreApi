using Serilog;
using Service.DependencyInjection;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLogging(builder => builder.AddSerilog(dispose: true));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
WebAPI.DependencyInjection.DIConfig.ConfigureServices(builder.Services, builder.Configuration);
Data.DependencyInjection.DIConfig.ConfigureServices(builder.Services, builder.Configuration);
Service.DependencyInjection.ServiceCollectionExtension.AddCustomServices(builder.Services);
Data.DependencyInjection.ServiceCollectionExtension.AddCustomServices(builder.Services);
builder.Services.AddCustomServices();
var app = builder.Build();

app.UseExceptionHandler("/Error");
app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
