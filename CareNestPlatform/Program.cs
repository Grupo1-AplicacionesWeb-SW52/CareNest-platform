using CarNest.CaregiverPaymentMethod.Application.Internal.CommandServices;
using CarNest.CaregiverPaymentMethod.Application.Internal.QueryServices;
using CarNest.CaregiverPaymentMethod.Domain.Repositories;
using CarNest.CaregiverPaymentMethod.Domain.Services;
using CarNest.CaregiverPaymentMethod.Infrastructure.Persistence.EFC.Repositories;
using CarNest.TutorPaymentMethod.Application.Internal.CommandServices;
using CarNest.TutorPaymentMethod.Application.Internal.QueryServices;
using CarNest.TutorPaymentMethod.Domain.Repositories;
using CarNest.TutorPaymentMethod.Domain.Services;
using CarNest.TutorPaymentMethod.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;
using WebApplication3.Caregivers.Domain.Repositories;
using WebApplication3.Caregivers.Infrastructure.Persistence.EFC.Repositories;
using WebApplication3.Caregivers.Application.Internal.CommandServices;
using WebApplication3.Caregivers.Application.Internal.QueryServices;
using WebApplication3.Services.Application.CommandServices;
using WebApplication3.Services.Application.QueryServices;
using WebApplication3.Services.Domain.Repositories;
using WebApplication3.Services.Infrastructure.Persistence.EFC.Repositories;
using WebApplication3.Shared.Interfaces.ASP.Configuration;
using WebApplication3.Tutors.Application.Internal.CommandServices;
using WebApplication3.Tutors.Application.Internal.QueryServices;
using WebApplication3.Tutors.Domain.Repositories;
using WebApplication3.Tutors.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
    {
        if (builder.Environment.IsDevelopment())
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        else if (builder.Environment.IsProduction())
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        }
    }
});

// Learn more about configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CareNestPlatform API",
        Version = "v1",
        Description = "API for CareNestPlatform Project",
        Contact = new OpenApiContact
        {
            Name = "Edu Nest",
            Email = "contact@edunest.com"
        }
    });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICaregiverRepository, CaregiverRepository>();
builder.Services.AddScoped<CaregiverCommandService>();
builder.Services.AddScoped<CaregiverQueryService>();

builder.Services.AddScoped<ITutorRepository, TutorRepository>();
builder.Services.AddScoped<TutorQueryService>();  
builder.Services.AddScoped<TutorCommandService>();

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ServiceQueryService>();
builder.Services.AddScoped<ServiceCommandService>();


builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ScheduleQueryService>();
builder.Services.AddScoped<ScheduleCommandService>();

builder.Services.AddScoped<IWorkaroundRepository, WorkaroundRepository>();
builder.Services.AddScoped<WorkaroundCommandService>();

// Register Tutor Payment Methods Repositories and Services
builder.Services.AddScoped<ITutorPaymentMethodRepository, TutorPaymentMethodRepository>();
builder.Services.AddScoped<TutorPaymentMethodQueryService>();
builder.Services.AddScoped<TutorPaymentMethodCommandService>();
builder.Services.AddScoped<ITutorPaymentMethodCommandService, TutorPaymentMethodCommandService>();
builder.Services.AddScoped<ITutorPaymentMethodQueryService, TutorPaymentMethodQueryService>();


// Register Caregiver Repositories and Services
builder.Services.AddScoped<ICaregiverPaymentMethodRepository, CaregiverPaymentMethodRepository>();
builder.Services.AddScoped<CaregiverPaymentMethodQueryService>();
builder.Services.AddScoped<CaregiverPaymentMethodCommandService>();
builder.Services.AddScoped<ICaregiverPaymentMethodCommandService, CaregiverPaymentMethodCommandService>();
builder.Services.AddScoped<ICaregiverPaymentMethodQueryService, CaregiverPaymentMethodQueryService>();


builder.Services.AddControllers();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Ensure tables and schema are created
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
