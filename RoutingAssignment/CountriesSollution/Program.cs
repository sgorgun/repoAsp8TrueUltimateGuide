var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

// list with countries
Dictionary<int, string> countries = new Dictionary<int, string>()
{
    { 1, "United States" },
    { 2, "Canada" },
    { 3, "United Kingdom" },
    { 4, "India" },
    { 5, "Japan" }
};

// endpoint to get all countries
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/countries", async context =>
    {
        // show all countries
        foreach (var country in countries)
        {
            await context.Response.WriteAsync($"{country.Key}, {country.Value}\n");
        }
    });

    endpoints.MapGet("/countries/{countryID:range(1,100)}", async context =>
    {
        // get country by id
        if (context.Request.RouteValues.ContainsKey("countryID") == false)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Country ID should be between 1 and 100");
            return;
        }

        int countryID = Convert.ToInt32(context.Request.RouteValues["countryID"]);

        if (countries.ContainsKey(countryID))
        {
            string countryName = countries[countryID];
            await context.Response.WriteAsync($"Country ID: {countryID}, Country Name: {countryName}");
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Country not found");
        }
    });

    endpoints.MapGet("/countries/{countryID:min(101)}", async context =>
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Country ID should be between 1 and 100");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("No response");
});
app.Run();
