using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrapper.Api.AppSettings;
using Scrapper.Api.SearchService;
using Scrapper.Api.HtmlService;
namespace Scrapper.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SearchSetting>(Configuration.GetSection("SearchSetting"));
            services.AddTransient<IHtmlProcessor, HtmlProcessor>();
            //services.AddScoped<IGoogleSearchService>(s => new GoogleSearchService("https://www.google.com.au"));
            services.AddScoped<IGoogleSearchService>(s => new GoogleSearchService(Configuration.GetSection("SearchSetting")["BaseUrl"]));
            services.AddMediatR();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
