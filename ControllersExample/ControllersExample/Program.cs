using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // Add all controllers to the service collection
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
