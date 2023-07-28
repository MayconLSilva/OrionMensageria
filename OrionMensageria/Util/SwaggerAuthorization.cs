namespace OrionMensageria.Util
{
    public static class SwaggerAuthorization
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerAuthenticationMiddleware>();
        }
    }
}
