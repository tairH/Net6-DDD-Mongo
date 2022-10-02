

using Microsoft.Extensions.Options;
using Net6ApiExmple.Application.utils;
using Net6ApiExmple.Infrastructure;
using Net6ApiExmple.Infrastructure.contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region mongo dependencies

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

//builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
  //  serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();

#endregion

builder.Services.AddScoped<ILockRepository, LockRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.Converters.Add(new JsonObjectIdConverterBySystemTextJson());
}
                ); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

