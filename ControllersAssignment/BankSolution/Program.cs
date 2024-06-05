var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // for controllers 

var app = builder.Build();

app.UseStaticFiles(); // For the wwwroot folder
app.UseRouting(); // For routing
app.MapControllers(); // For controllers routing

app.Run(); 
