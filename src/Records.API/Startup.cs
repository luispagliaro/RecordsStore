using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Records.API.Entities;
using Microsoft.EntityFrameworkCore;
using Records.API.Services;
using Records.API.Models;

namespace Records.API
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    // Adds XML formatting to the API data when sending a request asking for XML data type.
                    new XmlDataContractSerializerOutputFormatter()
                    ));

            services.AddDbContext<RecordsStoreContext>(o => o.UseSqlServer(Configuration["ConnectionStrings:RecordsStoreContextConnection"]));

            services.AddScoped<IRecordsStoreRepository, RecordsStoreRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, RecordsStoreContext RecordsStoreContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler();
            }

            RecordsStoreContext.EnsureSeedDataForContext();

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(config => {
                config.CreateMap<Band, BandDto>().ReverseMap();
                config.CreateMap<Band, BandUpdateDto>().ReverseMap();
                config.CreateMap<Record, RecordDto>().ReverseMap();
                config.CreateMap<Record, RecordUpdateDto>().ReverseMap();
            });

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseMvc();
        }
    }
}
