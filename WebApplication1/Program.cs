using Microsoft.AspNetCore.HttpOverrides;
using WebApplication1.Extensions;
using NLog;

namespace WebApplication1
{
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
                 "/nlog.config"));

            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Logic before executing the next delegate in the Use method.");
            //    await next.Invoke();
            //    Console.WriteLine("Logic after exicuting the next dalagate in the Use method");
            //});

            //app.Map("/usingmapbranch", builder =>
            //{
            //    builder.Use(async (context, next) =>
            //    {
            //        Console.WriteLine("Map branch logic in the Use method before the next delegate");
            //        await next.Invoke();
            //        Console.WriteLine("Map branch logic in the Use method after the next delegate");
            //    });

            //    builder.Run(async context =>
            //    {
            //        Console.WriteLine("Map branch response to the client in the Run method");
            //        await context.Response.WriteAsync("Hello from the map branch");
            //    });
            //});

            //app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"),
            //     builder =>
            //     {
            //         builder.Run(async context =>
            //         {
            //             await context.Response.WriteAsync("Hello from the MapWhen branch.");
            //         });
            //     });

            //app.Run(async context =>
            //{
            //    Console.WriteLine("Writing the response to the client");
            //    context.Response.StatusCode = 200;
            //    await context.Response.WriteAsync("Hello from the middleware component.");
            //});

            app.MapControllers();

            app.Run();
        }
    }
}
