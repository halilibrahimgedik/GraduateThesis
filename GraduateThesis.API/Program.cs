using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using GraduateThesis.API.Filters;
using GraduateThesis.API.Middlewares;
using GraduateThesis.API.Modules;
using GraduateThesis.Core.Configuration;
using GraduateThesis.Repository;
using GraduateThesis.Service.Mapping;
using GraduateThesis.Service.Validators.CategoryDtosValidators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
builder.Services.AddSwaggerGen();



// ! options Pattern ile Environment'dan deðer alma
builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOptions"));



// Environment deðiþkenlerinden deðerleri al
var customTokenOptions = new CustomTokenOption
{
    Audiences = Environment.GetEnvironmentVariable("Audiences")?.Split(",").ToList(),
    Issuer = Environment.GetEnvironmentVariable("Issuer")!,
    AccessTokenExpirationTime = Convert.ToInt32(Environment.GetEnvironmentVariable("AccessTokenExpirationTime")),
    RefreshTokenExpirationTime = Convert.ToInt32(Environment.GetEnvironmentVariable("RefreshTokenExpirationTime")),
    SecurityKey = Environment.GetEnvironmentVariable("SecurityKey")!
};


builder.Services.Configure<CustomTokenOption>(options =>
{
    options.Audiences = customTokenOptions.Audiences;
    options.Issuer = customTokenOptions.Issuer;
    options.AccessTokenExpirationTime = customTokenOptions.AccessTokenExpirationTime;
    options.RefreshTokenExpirationTime = customTokenOptions.RefreshTokenExpirationTime;
    options.SecurityKey = customTokenOptions.SecurityKey!;
});











// ! AppDbContext yapýlandýrmasý
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //!LOCAL SERVER
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });

    //!REMOTE SERVER
    //options.UseSqlServer(builder.Configuration.GetConnectionString("RemoteSqlServer"), option =>
    //{
    //    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    //});
});


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

// CustomException Middleware
app.UseCustomException(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
