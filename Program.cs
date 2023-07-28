

using ComparerBasic.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// read connection string section
var db = builder.Configuration.GetConnectionString("postgres");

if (db == null || db.Equals(""))
{
    throw new Exception("db string is empty");
}
builder.Services.AddDbContext<IComparerContext, ComparerContext>(opt => opt.UseNpgsql(db));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(config 
    => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();

var app = builder.Build();
using var scope = app.Services.CreateScope();
(scope.ServiceProvider.GetService<ComparerContext>() 
 ?? throw new Exception(message: "Can't migrate database"))
    .Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
