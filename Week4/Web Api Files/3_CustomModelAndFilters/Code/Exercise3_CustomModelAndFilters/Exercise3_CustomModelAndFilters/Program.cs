using Exercise3_CustomModelAndFilters.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Register CustomAuthFilter
builder.Services.AddScoped<CustomAuthFilter>();

// 2. Add controllers with global filter
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomAuthFilter>();
});

// 3. Swagger & Security setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Exercise3 API with Filters",
        Version = "v1"
    });
    // --- add this block to enable an Authorize button ---
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter `Bearer <token>`",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id   = "Bearer"
                }
            },
            new string[]{}
        }
    });
    // ---------------------------------------------------
});

var app = builder.Build();

// 4. Serve Swagger UI at root
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exercise3 API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
