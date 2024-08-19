using Microsoft.AspNetCore.Builder;

namespace WebApplication1.Extensions
{
    public static class ServiceExtensions
    {

        /// <summary>
        ///     Cross-Origin Resource Sharing (CORS) - mechanism to give orrestrict
        ///         access to application from different domains.
        /// </summary>
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });
    }
}
