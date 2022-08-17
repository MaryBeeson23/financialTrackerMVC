using Microsoft.EntityFrameworkCore;
using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Services.UsersService;
using FinancialTrackerMVC.Services.BillsService;
using FinancialTrackerMVC.Services.SavingsService;
using FinancialTrackerMVC.Services.SubscriptionsService;
using FinancialTrackerMVC.Services.CreditCardsService;
using FinancialTrackerMVC.Services.MedicalAndInsuranceService;
using FinancialTrackerMVC.Services.RentAndUtilitiesService;
using FinancialTrackerMVC.Services.MiscService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FinancialTrackerDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IUsers, Users>();
builder.Services.AddScoped<IBills, Bills>();
builder.Services.AddScoped<ISavings, Savings>();
builder.Services.AddScoped<ISubscriptions, Subscriptions>();
builder.Services.AddScoped<ICreditCards, CreditCards>();
//builder.Services.AddScoped<IMedicalAndInsurance, MedicalAndInsurance>();
//builder.Services.AddScoped<IRentAndUtilities, RentAndUtilities>();
//builder.Services.AddScoped<IMisc, Misc>();



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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
