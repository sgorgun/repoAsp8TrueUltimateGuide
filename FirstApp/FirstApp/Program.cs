var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    string method = context.Request.Method;
    context.Response.Headers["MyKey"] = "my value";
    context.Response.Headers["Server"] = "My Server";
    context.Response.ContentType = "text/html";
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>Id: {id}</p>");
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync($"<p>Name: {name}</p>");
        }
    }
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{method}</p>");
    await context.Response.WriteAsync("<h1>Hello!</h1>");
    await context.Response.WriteAsync("<h3>World!</h3>");
});

app.Run();
