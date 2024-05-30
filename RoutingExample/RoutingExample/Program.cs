var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
    }
    await next(context);
});

// eneble routing
app.UseRouting();

app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
    }
    await next(context);
});

// creating endpoints
app.UseEndpoints(endploints =>
{
    // add your endpoints here
    endploints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync($"Request received at {context.Request.Path}");
    });

    endploints.MapPost("map2", async (context) =>
    {
        await context.Response.WriteAsync($"Request received at {context.Request.Path}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
