using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace YAMI.Common.Colleration;

public static class CollerationExtensions
{
    private const string COLLERATION_ID_KEY = "colleration-id";

    public static IApplicationBuilder UseColleration(this IApplicationBuilder app)
        => app.Use(async (context, next) =>
        {
            if (!context.Request.Headers.TryGetValue(COLLERATION_ID_KEY, out var collerationId))
                collerationId = Guid.NewGuid().ToString("N");

            context.Items[COLLERATION_ID_KEY] = collerationId.ToString();

            await next();
        });

    public static string? GetCollerationId(this HttpContext context)
        => context.Items.TryGetValue(COLLERATION_ID_KEY, out var collerationId) ? collerationId as string : null;

    public static void AddCollerationId(this HttpRequestHeaders headers, string collerationId)
        => headers.TryAddWithoutValidation(COLLERATION_ID_KEY, collerationId);

    public static void AddCollerationId(this HttpRequestHeaders headers, Guid collerationId)
        => headers.AddCollerationId(collerationId.ToString("N"));
}
