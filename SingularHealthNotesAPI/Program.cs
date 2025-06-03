using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using SingularHealthNotesAPI;
using SingularHealthNotesAPI.Helpers;
using SingularHealthNotesAPI.Repository;
using SingularHealthNotesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddSingleton<ScanDataSeeder>();
builder.Services.AddSingleton<ScanRepository>();
builder.Services.AddSingleton<IScanService, ScanService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Serving some static files for our mock data.
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Assets")),
    RequestPath = "/assets"
});

//Seeding our initial mock data for this prototype
using (var scope = app.Services.CreateScope())
{
    var seeder = app.Services.GetRequiredService<ScanDataSeeder>();
    seeder.SeedScans(scope.ServiceProvider.GetRequiredService<ScanRepository>());
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
