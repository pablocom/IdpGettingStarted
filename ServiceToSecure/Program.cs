var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        const string nameOfApiResource = "api1";
        options.Audience = nameOfApiResource;
        options.Authority = "https://localhost:7075";
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/hello-world", () => "hello-world")
    .WithName("GetWeatherForecast")
    .RequireAuthorization();

app.Run();