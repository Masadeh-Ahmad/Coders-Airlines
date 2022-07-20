using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Coders_Airlines.Auth;
using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Auth.Model;
using Coders_Airlines.Data;
using Coders_Airlines.Models.Interfaces;
using Coders_Airlines.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Coders_Airlines
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<ApplicationUser, IdentityRole>(
               options =>
               {
                   //options.Password.RequireDigit = false; // Adding digits to the password is not mandatory
                   options.User.RequireUniqueEmail = true; // make sure the email is unique

               }).AddEntityFrameworkStores<AirlinesDbContext>();

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                // Needs fixing.
                options.Conventions.AddPageRoute("/Index/Index", "");
            });
            services.AddDbContext<AirlinesDbContext>(options =>
            {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IEmail, EmailService>();

            // Map the interface with the service
            services.AddTransient<IApartment, ApartmentService>();
            services.AddTransient<IUser, UserService>();

            // failed trials - accessing paths
            // new for Cookies auth
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/auth/NotAuthorized";
            });

            // Differences between JWT and cookies 
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("create", policy => policy.RequireClaim("persmissions", "create"));
                options.AddPolicy("update", policy => policy.RequireClaim("persmissions", "update"));
                options.AddPolicy("delete", policy => policy.RequireClaim("persmissions", "delete"));
            });
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:AzureBlob:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["ConnectionStrings:AzureBlob:queue"], preferMsi: true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Auth}/{action=Index}");
            });
        }
    }
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }
    }
}
