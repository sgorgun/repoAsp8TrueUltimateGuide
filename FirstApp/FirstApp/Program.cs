using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    System.IO.StreamReader reader = new System.IO.StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0];
        string age = queryDict["age"][0];

        foreach (var item in queryDict["age"])
        {
            await context.Response.WriteAsync($"{firstName} is {age} old");
        }
    }

});

app.Run();
