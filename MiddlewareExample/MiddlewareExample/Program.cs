using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();


//middleware1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello1");
    await next(context);
});

//middleware2
app.UseMiddleware<MyCustomMiddleware>();
//middleware3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("\nHello3");
});

app.Run();
