using CatalogManagement.Application.Extensions;
using CatalogManagement.Domain.Repositories;
using CatalogManagement.Infrastructure.Extensions;
using CatalogManagement.Infrastructure.Seeders;
using CatalogManagementAPI.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom error handling middleware
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Allow angular to call APIs in here
//private readonly string corsPolicy = "defaultPolicy";
var df = builder.Configuration["CorsUrl"];
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.WithOrigins(df)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseCors(p => { p.AllowAnyHeader().AllowAnyMethod().WithOrigins(df).AllowCredentials(); });
app.Use((corsContext, next) =>
{
    corsContext.Response.Headers["Access-Control-Allow-Origin"] = "*";
    return next.Invoke();
});

// add seed data
var scope = app.Services.CreateAsyncScope();
var pSeeder = scope.ServiceProvider.GetRequiredService<IProductSeeder>();
var cSeeder = scope.ServiceProvider.GetRequiredService<ICategoryRepo>();
await pSeeder.ProductSeed();
cSeeder.CategorySeed();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapControllers();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "CatalogManagementAPI.Frontend";
    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
    }
});

app.Run();
