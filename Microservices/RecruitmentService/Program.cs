using RecruitmentService.Connectors;
using RecruitmentService.OptionsSetup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<AppSettingsSetup>();

builder.Services.AddScoped<IDatabaseConnector, DatabaseConnector>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
else
{
	builder.WebHost.UseUrls("http://*:80");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
