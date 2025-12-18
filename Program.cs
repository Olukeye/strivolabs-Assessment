using Microsoft.EntityFrameworkCore;
using strivolabs_Assessment.Data;
using strivolabs_Assessment.Middlewares;
using strivolabs_Assessment.Repository;
using strivolabs_Assessment.ServiceImplementation;
using strivolabs_Assessment.ServiceRepositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    ));

builder.Services.AddControllers();

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceTokenRepository, ServiceTokenRepository>();
builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
}

app.UseRouting();

//app.UseMiddleware<ServiceTokenMiddleware>();

app.MapControllers();

//app.UseHttpsRedirection();
app.UseAuthentication();
//app.UseAuthorization();

app.Run();