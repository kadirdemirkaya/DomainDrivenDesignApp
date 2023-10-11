using FlavorWorld.Api;
using FlavorWorld.Api.Registrations;
using FlavorWorld.Application;
using FlavorWorld.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPresentation(builder.Configuration)
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

builder.Host.UseSerilog();

builder.OptionsRegistration();

builder.AddInfrastructureBuilder();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // !!!
}

app.AddPresentationApp()
    .AddInfrastructureApp(builder.Configuration);

app.LogRegistrationApp();

app.AddApplicationApp();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
