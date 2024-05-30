var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// eneble routing
app.UseRouting();

// creating endpoints
app.UseEndpoints(endploints => {
    // add your endpoints here

});

app.Run();
