using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace MyApp.Modules.Notifications.Api.API;

public static class NotificationsApi
{
    public static void UseNotificationsApi(this IEndpointRouteBuilder builder)
        => builder.MapGet("/notifications", () =>  "Notifications API");
}