<<<<<<< HEAD
using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.Domain;
using FoodDeliveryAPI.Domain.Service;
=======
using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.Service;
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FoodDeliveryAPIContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("FoodDeliveryAPI")));

// scoped service classes 

builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IRestaurantService,RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDeliveryPersonService, DeliveryPersonService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAdminService, AdminService>();
<<<<<<< HEAD

// to exclude null from every json body

=======
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var secretKey = builder.Configuration["Jwt:Key"];
var issuer = builder.Configuration["Jwt:Issuer"];
var audience = builder.Configuration["Jwt:Audience"];

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
}));

<<<<<<< HEAD
// to add jwtbearer as authentication scheme 

=======
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey ?? "")),
        ValidateAudience = true,
        ValidateLifetime = true,
    };
});

<<<<<<< HEAD
// swagger authentication defination 

=======
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655
builder.Services.AddSwaggerGen(options =>
{
    options
    .AddSecurityDefinition(
        name: JwtBearerDefaults.AuthenticationScheme,
        securityScheme: new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "Enter Bearer Authorization: `Bearer Generated-JWT-Token`",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        }
     );

    options
        .AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                },
                new String[]{}
            }
        });
});

<<<<<<< HEAD
// added assembly to configure automapper 

builder.Services.AddAutoMapper(typeof(Program).Assembly);

=======
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

<<<<<<< HEAD
// applying cors policy 

=======
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655
app.UseCors("corspolicy");

app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
