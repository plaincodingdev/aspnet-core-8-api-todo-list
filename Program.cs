using aspnet_core_8_todo_list_api.Services.ToDoService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IToDoService, ToDoService>(); // Register our custom service with the lifetime of the application

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
