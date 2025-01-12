global using Microsoft.EntityFrameworkCore;
global using aspnet_core_8_todo_list_api.Services.ToDoService;
global using aspnet_core_8_todo_list_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the DataContext with postgresql
builder.Services.AddDbContext<DataContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register our custom service with the lifetime of the request
builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Allow any origin, method, and header
app.UseCors(builder =>
{
  builder.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
});

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
