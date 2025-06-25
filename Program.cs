using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedMango_API.Data;
using RedMango_API.Mappings;
using RedMango_API.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// configure the serilog 
var logger = new LoggerConfiguration()
             .WriteTo.Console()
             .MinimumLevel.Information()
             .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
             

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure the dbcontext
builder.Services.AddDbContext<RedMangoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RedMangoDBConnectionString"));
});

// configure the identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<RedMangoDbContext>();

// configure the DI
builder.Services.AddScoped<IMenuItemRepository, SQLMenuItemRepository>();


// configure the automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
