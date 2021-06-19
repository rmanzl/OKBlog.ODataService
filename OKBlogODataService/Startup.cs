using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OKBlogODataService.Model;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using OKBlogODataService.Base;

namespace OKBlogODataService
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<HttpBasicAuthorizeFilter>();

            services.AddDbContext<EventTicketDbContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("EventTicket"));
            });

            services.AddControllers();
            services.AddOData();

            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(builder =>
            {
                builder.Select()
                    .OrderBy()
                    .Filter()
                    .Count()
                    .MaxTop(null);

                builder.MapODataRoute("odata", "odata", GetEdmModel());
            });
        }

        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Ticket>("Tickets");
            return odataBuilder.GetEdmModel();
        }
    }
}
