using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Experiment.BL;
using Experiment.DataAccess;
using Experiment.DataBase;
using Experiment.Domain.Interfaces.BisinessLogic;
using Experiment.Domain.Interfaces.DataAccess;

namespace Experiment.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Вызывается средой выполнения. Используется для добавления служб в контейнер.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DataBaseMock>();
            services.AddTransient<IUsersRepository, UserRepositoryMock>();
            services.AddTransient<IUsersService, UserService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Experiment.API", Version = "v1" });
            });
        }

        // Вызывается средой выполнения. Используется для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Experiment.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseMiddleware<MyMiddlewareComponent>();

            //app.Use((httpContext, next) =>
            //{
            //    var task = next();

            //    return task;
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
