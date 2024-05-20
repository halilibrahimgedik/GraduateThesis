using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using GraduateThesis.API.Extensions;
using GraduateThesis.API.Filters;
using GraduateThesis.API.Middlewares;
using GraduateThesis.API.Modules;
using GraduateThesis.Core.Configuration;
using GraduateThesis.Core.Models;
using GraduateThesis.Repository;
using GraduateThesis.Service.Mapping;
using GraduateThesis.Service.Services;
using GraduateThesis.Service.Validators.CategoryDtosValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// ! ValidateModelsFilterAttribute Tum Controller'lara merkezi olarak ekleyelim
builder.Services.AddControllers(options => options.Filters.Add(new ValidateModelsFilterAttribute()));

// ! Default Donen ModelState Hata Filter'ini kapatalim
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//  Authorization via Swagger
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});






var customTokenOptions = new CustomTokenOption
{
    Audiences = builder.Configuration.GetSection("CustomTokenOption:Audiences").Get<List<string>>(),
    Issuer = builder.Configuration.GetValue<string>("CustomTokenOption:Issuer"),
    AccessTokenExpirationTime = builder.Configuration.GetValue<int>("CustomTokenOption:AccessTokenExpirationTime"),
    RefreshTokenExpirationTime = builder.Configuration.GetValue<int>("CustomTokenOption:RefreshTokenExpirationTime"),
    SecurityKey = builder.Configuration.GetValue<string>("CustomTokenOption:SecurityKey"),
};

// ! Options Pattern
builder.Services.Configure<CustomTokenOption>(options =>
{
    options.Audiences = customTokenOptions.Audiences;
    options.Issuer = customTokenOptions.Issuer;
    options.AccessTokenExpirationTime = customTokenOptions.AccessTokenExpirationTime;
    options.RefreshTokenExpirationTime = customTokenOptions.RefreshTokenExpirationTime;
    options.SecurityKey = customTokenOptions.SecurityKey!;
});



// ! AppDbContext Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{

    if (builder.Environment.IsDevelopment())
    {

        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))!.GetName().Name);
        });
    }

    if(builder.Environment.IsProduction())
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("RemoteSqlServer"), option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))!.GetName().Name);
        });
    }

    //options.UseSqlServer(Environment.GetEnvironmentVariable(RemoteSqlServer), option =>
    //{
    //    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))!.GetName().Name);
    //});

});



builder.Services.AddIdentity<AppUser, IdentityRole>(IdentityOptions =>
{
    IdentityOptions.Password.RequireNonAlphanumeric = false;
    IdentityOptions.Password.RequiredLength = 6;
    IdentityOptions.Password.RequireUppercase = true;
    IdentityOptions.Password.RequireLowercase = true;
    IdentityOptions.Password.RequireDigit = true;

    IdentityOptions.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


// ! Validating Access Token with custom Extension method
builder.Services.AddCustomTokenAuthentication(customTokenOptions);



// ! FluentValidation
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<CreateCategoryDtoValidator>();


// ! NotFoundFilter
builder.Services.AddScoped(typeof(NotFoundFilter<,>));
builder.Services.AddScoped(typeof(ValidateCategoryIdsFilter));


// ! AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ServiceModule());
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ! CustomException Middleware
app.UseCustomException();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
