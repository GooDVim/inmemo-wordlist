using Inmemo.Wordlist.Models;
using Inmemo.Wordlist.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Inmemo.Wordlist.Middlewares;
using Inmemo.Wordlist.Options;

namespace Inmemo.Wordlist
{
    public class Startup
    {
        public MapperConfiguration MapperConfiguration { get; }
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddEnvironmentVariables();
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }
            Configuration = builder.Build();

            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.Configure<SecretKeyOptions>(Configuration);
            services.AddDbContext<WordlistDbContext>(options => options.UseSqlServer(Configuration["ConnectionString"])
            );
            services.AddSingleton<IMapper>(sp => MapperConfiguration.CreateMapper());
            services.AddScoped<IWordRepository, WordRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseAuthorizationMiddleware();
            }
            app.UseMvc();
        }
    }
}