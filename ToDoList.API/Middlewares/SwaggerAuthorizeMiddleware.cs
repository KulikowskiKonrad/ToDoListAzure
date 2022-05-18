using Microsoft.AspNetCore.Builder;

namespace ToDoList.API.Middlewares
{
    public static class SwaggerAuthorizeMiddleware
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerBasicAuthMiddleware>();
        }
    }
}