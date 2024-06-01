using RoutingExample.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

// Add custom constraints services to the container.
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("month", typeof(MonthsCustomConstraint));
});

var app = builder.Build();

// enable routing
app.UseRouting();

// creating endpoints
app.UseEndpoints(async endpoints =>
{
    // add your endpoints here
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files: {fileName}.{extension}");
    });

    endpoints.Map("employee/profile/{employeeName:minlength(3):alpha=newUser}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
        await context.Response.WriteAsync($"Name: {employeeName}");
    });

    // Eg: /products/details/
    endpoints.Map("products/details/{id:int:range(1,1000)?}", async context =>
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

    // Eg: sales-report/2024/jan
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:month}", async context => // month is a custom constraint
    {
        int? year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Year: {year}, Month: {month}");
    });

//    // Eg: sales-report/2024/jan
//    endpoints.Map("sales-report/2024/jan", async context => // has more weight than previous
//    {
//        await context.Response.WriteAsync("Year: 2024, Month: Jan");
//    });
//});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
