using DatabaseService.Data;
using DatabaseService.Model;
using DatabaseService.Repositories;
using DatabaseService.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositiories
builder.Services.AddScoped<IRepository<Candidate>, CandidateRepository>();
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Meeting>, MeetingRepository>();
builder.Services.AddScoped<IRepository<Recruitment>, RecruitmentRepository>();
builder.Services.AddScoped<IRepository<Salary>, SalaryRepository>();
builder.Services.AddScoped<IRepository<TimeOff>, TimeOffRepository>();

// Services
builder.Services.AddScoped<CandidateCRUDService>();
builder.Services.AddScoped<CourseCRUDService>();
builder.Services.AddScoped<EmployeeCRUDService>();
builder.Services.AddScoped<MeetingCRUDService>();
builder.Services.AddScoped<RecruitmentCRUDService>();
builder.Services.AddScoped<SalaryCRUDService>();
builder.Services.AddScoped<TimeOffCRUDService>();

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//database
var connection_string = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<HrDBContext>((options) =>
	options.UseNpgsql(connection_string));

//string[] allowedOrigin = ["http://localhost"];
var allowedOrigin = builder.Configuration["AllowedHosts"]!;

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		//policy.WithOrigins(allowedOrigin)
		//	.AllowAnyHeader()
		//	.AllowAnyMethod();

		policy
			.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

// Identity
//builder.Services.AddIdentity<User, IdentityRole>();

var app = builder.Build();

CreateDbIfNotExists(app);

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

app.UseAuthorization();

app.MapControllers();

app.Run();

void CreateDbIfNotExists(IHost host)
{
	using (var scope = host.Services.CreateScope())
	{
		var services = scope.ServiceProvider;
		try
		{
			var context = services.GetRequiredService<HrDBContext>();
			DbInitializer.Initialize(context);
		}
		catch (Exception ex)
		{
			var logger = services.GetRequiredService<ILogger<Program>>();
			logger.LogError(ex, "An error occurred creating the DB.");
		}
	}
}
