using Globomantics.Interfaces.Services;
using Globomantics.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Globomantics.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        //Explicitly add a constructor and "ask for" a configuration
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        // Called First
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //You can add only what U need (without overkilling)

            //MVC application 
            //before .Net Core 2 we used to write AddMvc() to add everything MVC offers but this is an overkill
            services.AddControllersWithViews();

            //Enough for API only
            //services.AddControllers();

            //Enough for Razor pages
            //services.AddRazorPages();

            //My own "Services"
            //"Services" stands for interfaces and implementations
            services.AddSingleton<IConferenceService, ConferenceMemoryService>();
            services.AddSingleton<IProposalService, ProposaMemorylService>();


            //Make the Globomantics section strongly typed and available for injection everywhere
            services.Configure<GlobomanticsOptions>(configuration.GetSection("Globomantics"));
        }

        // Called Second
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The pipeline components are called middleware, for ex. we can add
        // Authentication -> MVC -> Serve static files
        // The ORDER OF THE MIDDLEWARE IS IMPORTANT! 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //True if environment variable ASPNETCORE_ENVIRONMENT is equal to DEVELOPMENT
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Checks whatever environment variable ASPNETCORE_ENVIRONMENT name U want: for ex. QAI
            if (env.IsEnvironment("QAI")) { }

            //Before UseRouting(), because it doesn't need routing information
            //js and css files
            app.UseStaticFiles();


            //Should be called before UseEndpoints()
            //app.UseAuthentication();


            // From moment on,  all the middleware THAT FOLLOWES
            // knows about the selected endpoint and use this info
            // if needed
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});


                //For MVC conventional routing with routing table
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Conference}/{action=Index}/{id?}");


                //For Attribute routing
                //endpoints.MapControllers();
            });
        }

        //If present, gets called for the specific ENVIRONMENT
        //and takes precedence over Configure method
        //The Configure method can be used as a fallback method
        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //}


        //If present, gets called for the specific ENVIRONMENT
        //and takes precedence over Configure method
        //The Configure method can be used as a fallback method
        //public void ConfigureQAI(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //}
    }
}

