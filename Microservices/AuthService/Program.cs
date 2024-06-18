using AuthService.Authentication;
using AuthService.Connectors;
using AuthService.OptionsSetup;
using AuthService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.ConfigureOptions<AppSettingsSetup>();

builder.Services.AddScoped<IDatabaseConnector, DatabaseConnector>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddScoped<AuthenticationService, AuthenticationService>();

builder.Services.AddHttpClient();

string[] allowedOrigin = ["http://localhost"];

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		// policy.WithOrigins(allowedOrigin)
		// 	.AllowAnyHeader()
		// 	.AllowAnyMethod();

		policy
			.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

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

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
