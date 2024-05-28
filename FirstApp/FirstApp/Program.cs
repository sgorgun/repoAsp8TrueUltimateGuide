var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    string method = context.Request.Method;
    context.Response.Headers["MyKey"] = "my value";
    context.Response.Headers["Server"] = "My Server";
    context.Response.ContentType = "text/html";
    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        string id = context.Request.Query["id"];
        await context.Response.WriteAsync($"<p>Id: {id}</p>");
        string name = context.Request.Query["name"];
        await context.Response.WriteAsync($"<p>Name: {name}</p>");
        string userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<p>User-Agent: {userAgent}</p>");

    }
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{method}</p>");
    await context.Response.WriteAsync("<h1>Hello!</h1>");
    await context.Response.WriteAsync("<h3>World!</h3>");
});

app.Run();
