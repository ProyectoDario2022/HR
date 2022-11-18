using HR.API.Data;
using HR.API.Data.Entities;
using HR.API.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
//Mio
var ConnectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddTransient<SeedDb>();

builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    x.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
    x.SignIn.RequireConfirmedEmail = true;
    x.User.RequireUniqueEmail = true;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase= false;
    //x.Password.RequiredLength = 6;

}).AddDefaultTokenProviders()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/NotAuthorized";
    options.AccessDeniedPath = "/Account/NotAuthorized";
});


//Inyeccion por dependencia

builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddScoped<ICombosHelper, CombosHelper>();
//builder.Services.AddScoped<IBlodHelper, BlobHelper>();
builder.Services.AddScoped<IConverterHelper, ConverterHelper>();
builder.Services.AddScoped<IConverterReclamoHelper, ConverterReclamoHelper>();

builder.Services.AddScoped<IMailHelper, MailHelper>();


WebApplication? app = builder.Build();

SeedData();



async void SeedData()
{
    IServiceScopeFactory? scopeFactory=app.Services.GetService<IServiceScopeFactory>(); 
    using (IServiceScope? scope = scopeFactory.CreateScope())
    {
        SeedDb? service=scope.ServiceProvider.GetService<SeedDb>();
        await service.SeedAsync();
    }
}

//Inyeccion por dependencia

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();//agregado por mi
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
