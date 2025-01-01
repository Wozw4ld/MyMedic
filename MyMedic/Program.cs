using Microsoft.EntityFrameworkCore;
using MyMedic.DataAccess;
using MyMedic.DataAccess.Repositories.Interfaces;
using MyMedic.DataAccess.Repositories.Repositories;
using MyMedic.Services.Implementations;
using MyMedic.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyMedicDbContext>(
	options =>
	{
		options.UseSqlServer(builder.Configuration.GetConnectionString("MyMedicDbContext"));
	}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage(); // Для удобной отладки
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyMedic API V1");
		c.RoutePrefix = "swagger"; // Swagger будет доступен по URL корня (localhost:5000)
	});
}
else
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
