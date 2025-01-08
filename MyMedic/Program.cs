using Microsoft.EntityFrameworkCore;
using MyMedic.DataAccess;
using MyMedic.DataAccess.Repositories.Interfaces;
using MyMedic.DataAccess.Repositories.Repositories;
using MyMedic.Services.Implementations;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using MyMedic.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyMedic.DTO.PasswordHasherService;
using MyMedic.DTO.Mappers;
using Helpers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<UsersMapper>();
builder.Services.AddScoped<ProductsMapper>();
builder.Services.AddScoped<OrdersMapper>();
builder.Services.AddScoped<CategoryMappers>();
builder.Services.AddScoped<CookiesService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
	{
		options.TokenValidationParameters = new()
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("justsecretfortestnotmoresdsds111"))
		};
		options.Events = new JwtBearerEvents
		{
			OnMessageReceived = context =>
			{
				context.Token = context.Request.Cookies["jwt"];
				return Task.CompletedTask;
			}
		};
	});
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
