var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// eneble routing
app.UseRouting();

// creating endpoints
app.UseEndpoints(endploints =>
{
    // add your endpoints here
    endploints.Map("map1", async (context) =>
    {
        await context.Response.WriteAsync($"Request received at {context.Request.Path}");
    });

    endploints.Map("map2", async (context) =>
    {
        await context.Response.WriteAsync($"Request received at {context.Request.Path}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
