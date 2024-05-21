using GraduateThesis.WEB.Configurations;
using GraduateThesis.WEB.Extensions;
using GraduateThesis.WEB.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();





var tokenOptions = new CustomTokenOption
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
    options.Audiences = tokenOptions.Audiences;
    options.Issuer = tokenOptions.Issuer;
    options.AccessTokenExpirationTime = tokenOptions.AccessTokenExpirationTime;
    options.RefreshTokenExpirationTime = tokenOptions.RefreshTokenExpirationTime;
    options.SecurityKey = tokenOptions.SecurityKey!;
});



builder.Services.AddCustomTokenAuthentication(tokenOptions);


builder.Services.AddHttpClient<UserApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["EndPoint"]);
});
builder.Services.AddHttpClient<UniversityApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["EndPoint"]);
});
builder.Services.AddHttpClient<ClubApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["EndPoint"]);
});

builder.Services.AddHttpClient<CategoryApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["EndPoint"]);
});








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
