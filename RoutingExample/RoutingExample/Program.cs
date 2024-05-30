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

    endpoints.Map("employee/profile/{employeeName?}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
        await context.Response.WriteAsync($"In files: {employeeName}");
    });

    // Eg: /products/details/
    endpoints.Map("products/details/{id:int?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"ID: {id}");
        }
        else
        {
            await context.Response.WriteAsync("No ID found");
        }
    });

    //Eg: daily-digest-report/{reportdate}
    endpoints.Map("daily-digest-report/{reportDate:datetime?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("reportDate"))
        {
            DateTime? reportDate = Convert.ToDateTime(context.Request.RouteValues["reportDate"]);
            await context.Response.WriteAsync($"Report Date: {reportDate?.ToShortDateString()}");
        }
        else
        {
            await context.Response.WriteAsync("No date");
        }
    });

    // Eg: cities/{cityId}
    endpoints.Map("cities/{cityId:guid?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("cityId"))
        {
            Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityId"])!);
            await context.Response.WriteAsync($"City ID: {cityId}"); 
        }
        else
        {
            await context.Response.WriteAsync("No city ID found");
        }
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
