using BookTracker.BusinessLogic.Extensions;
using BookTracker.Persistence.Extensions;
using BookTracker.Private.Api.Middlewares.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddBusinessLogic();
builder.Services.AddPersistence(connectionString);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();

app.Run();
