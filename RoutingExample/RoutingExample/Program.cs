var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routing
app.UseRouting();

// creating endpoints
app.UseEndpoints(endpoints =>
{
    // add your endpoints here
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files: {fileName}.{extension}");
    });

    endpoints.Map("employee/profile/{employeeName}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
        await context.Response.WriteAsync($"In files: {employeeName}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
