using Microsoft.AspNetCore.HttpOverrides;
using WebApplication1.Extensions;
using NLog;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using ActionFilters;
using Shared.Dtos;
using Service.DataShaping;
using WebApplication1.Utility;
using AspNetCoreRateLimit;

namespace WebApplication1
{
    public class Program
    {
        static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
            new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
                .Services.BuildServiceProvider()
                .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>().First();

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
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
            builder.Services.AddScoped<IEmployeeLinks, EmployeeLinks>();

            builder.Services.ConfigureVersioning();

            builder.Services.ConfigureResponseCaching();
            builder.Services.ConfigureHttpCacheHeaders();

            builder.Services.AddMemoryCache();
            builder.Services.ConfigureRateLimitingOptions();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.AddJwtConfiguration(builder.Configuration);

            builder.Services.ConfigureSwagger();

            builder.Services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
                {
                    Duration = 120
                });
            })
                .AddXmlDataContractSerializerFormatters()
                .AddCustomCsvFormatter()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            builder.Services.AddCustomMediaTypes();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddScoped<ValidationFilterAttribute>();
            builder.Services.AddScoped<ValidateMediaTypeAttribute>();

            builder.Services.AddControllers().AddApplicationPart(typeof(
                WebApplication1.Presentation.AssemblyReference).Assembly);
            
            var app = builder.Build();

            var logger = app.Services.GetRequiredService<ILoggerManager>();
            app.ConfigureExceptionHandler(logger);

            if (app.Environment.IsProduction())
                app.UseHsts();

            // Configure the HTTP request pipeline.

            //if (app.Environment.IsDevelopment())
            //    app.UseDeveloperExceptionPage();
            //else
            //    app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseCors("CorsPolicy");
            app.UseResponseCaching();
            app.UseHttpCacheHeaders();

            app.UseIpRateLimiting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Code Maze API v1");
                s.SwaggerEndpoint("/swagger/v2/swagger.json", "Code Maze API v2");
            });

            /*
             * Pipeline middleware examples
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
            //});*/

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllers();

            app.Run();
        }
    }
}
