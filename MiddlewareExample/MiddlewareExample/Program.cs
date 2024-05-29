var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//middleware1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello1");
    await next(context);
});

//middleware2
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("\nHello2");
    await next(context);
});

//middleware3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("\nHello3");
});

app.Run();
