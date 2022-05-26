using YAMI.Common.Colleration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseColleration();

app.MapGet("/", (HttpContext httpContext) =>
{
    var collerationId = httpContext.GetCollerationId();
    return Results.Ok($"Hello world with {collerationId}");
});

app.Run();
