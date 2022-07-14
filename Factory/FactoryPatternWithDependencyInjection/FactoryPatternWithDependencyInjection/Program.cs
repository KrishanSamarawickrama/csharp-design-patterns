using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FactoryPatternWithDependencyInjection.Data;
using FactoryPatternWithDependencyInjection.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//builder.Services.AddTransient<IDateTimeSample1, DateTimeSample1>();
//builder.Services.AddTransient<Func<IDateTimeSample1>>(x => () => x.GetService<IDateTimeSample1>()!);
builder.Services.AddAbstractFactory<IDateTimeSample1,DateTimeSample1>();
builder.Services.AddAbstractFactory<IRandomNumSample,RandomNumSample>();
builder.Services.AddEmployeeFactory();
builder.Services.AddVehicleFactory();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();