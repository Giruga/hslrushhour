using Microsoft.EntityFrameworkCore;
using HSLRushHour.Backend.Models;
using Microsoft.OpenApi.Models;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using HSLRushHour.Backend.Clients.DigiTransitClient;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<HSLRushHourDbContext>(opt => opt.UseInMemoryDatabase("HSLRushHourDb"));
builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(Configuration["DigiTransitGraphiQLURL"], new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<IDigiTransitClient, DigiTransitClient>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HSLRushHourApi",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
