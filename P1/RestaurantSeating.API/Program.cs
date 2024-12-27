using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Data;
using RestaurantSeating.API.Repository;
using RestaurantSeating.API.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestaurantContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantSeating")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IServerService, ServerService>();


builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<IServerRepository, ServerRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();