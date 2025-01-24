using Adaptit.Training.JobVacancy.Backend;
using Adaptit.Training.JobVacancy.Backend.Endpoints;
using Adaptit.Training.JobVacancy.Backend.Services;

using Microsoft.AspNetCore.Authentication.OpenIdConnect;

using Refit;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<OpenIdConnectOptions>();
builder.Services.AddTransient<OpenIdConnectOptions>();
builder.Services.AddScoped<OpenIdConnectOptions>();

builder.Services.AddRefitClient<IPamStillingFeed>()
  .ConfigureHttpClient(o => o.BaseAddress = new Uri("https://pam-stilling-api.azurewebsites.net"));

builder.Services.AddHostedService<TimedService>();

builder.Services.AddOptions<NaviktSettings>()
  .Bind(builder.Configuration.GetSection("NaviktSettings"))
  .ValidateDataAnnotations();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapFeedEndpoints();
app.MapFeedEntryEndpoints();
app.MapWeatherEndpoints();

app.Run();
