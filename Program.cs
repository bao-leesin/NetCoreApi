using Serilog;
var builder = WebApplication.CreateBuilder(args);


//Add logger
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(
    "Logs/testlog.txt",
    outputTemplate: "[{Timestamp:HH:mm:ss dd:MM:yy} {Level:u3}] {Message:lj}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Month
    ).CreateLogger();
builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
