using Adaptit.Training.JobVacancy.Backend;
using Adaptit.Training.JobVacancy.Backend.Endpoints;
using Adaptit.Training.JobVacancy.Backend.Services;
using Adaptit.Training.JobVacancy.Persistence;

using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Refit;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<OpenIdConnectOptions>();
builder.Services.AddTransient<OpenIdConnectOptions>();
builder.Services.AddScoped<OpenIdConnectOptions>();

builder.Services.AddSingleton(services =>
{
  var apiKey = services.GetRequiredService<IOptions<NaviktSettings>>().Value.ApiKey;
  return new RefitSettings()
  {
    AuthorizationHeaderValueGetter = (_,_) => Task.FromResult(apiKey)
  };
});

builder.Services.AddRefitClient<IPamStillingFeed>(services => services.GetRequiredService<RefitSettings>())
  .ConfigureHttpClient(o => o.BaseAddress = new Uri("https://pam-stilling-feed.nav.no"));

builder.Services.AddHostedService<TimedService>();

builder.Services.AddOptions<NaviktSettings>()
  .Bind(builder.Configuration.GetSection("NaviktSettings"))
  .ValidateDataAnnotations();

builder.Services.AddDbContext<JobVacancyDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("JobVacancyDb")));

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

app.MapGet("api/vi/trigger", ([FromServices] IEnumerable<IHostedService> services) =>
{
  var service = services.OfType<TimedService>().FirstOrDefault();
  service?.Trigger();
  return Results.Ok();
});

app.Run();
