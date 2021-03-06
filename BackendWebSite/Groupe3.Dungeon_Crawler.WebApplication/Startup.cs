using Groupe3.Dungeon_Crawler.EntitiesContext;
using Groupe3.Dungeon_Crawler.Entity.Game;
using Groupe3.Dungeon_Crawler.UnitOfWork;
using Groupe3.Dungeon_Crawler.UnitOfWork.Contract;
using Groupe3.Dungeon_Crawler.WebApplication.Filter;
using Groupe3.Dungeon_Crrawler.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json.Serialization;

namespace Groupe3.Dungeon_Crawler.WebApplication
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

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Groupe3.Dungeon_Crawler.WebApplication", Version = "v1" });
            });
            services.AddDbContext<DungeonCrawlerDbContextSql>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("CONNEXION_STRING_ENVIRONEMENT"), b => b.MigrationsAssembly("Groupe3.Dungeon_Crawler.WebApplication"));
            });
            services.AddDbContext<DbContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("CONNEXION_STRING_ENVIRONEMENT"), b => b.MigrationsAssembly("Groupe3.Dungeon_Crawler.WebApplication"));
                options.UseOpenIddict();
            });
            services.AddOpenIddict()
                // Register the OpenIddict core services.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the EF Core stores/models.
                    options.UseEntityFrameworkCore()
                               .UseDbContext<DbContext>();
                })
                // Register the OpenIddict server handler.
                .AddServer(options =>
                {
                    // Register the ASP.NET Core MVC services used by OpenIddict.
                    // Note: if you don't call this method, you won't be able to
                    // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                    options.UseMvc();
                    // Enable the token endpoint.
                    options.EnableTokenEndpoint("/Auth/Login");
                    // Enable the password flow.
                    options.AllowPasswordFlow();
                    // Accept anonymous clients (i.e clients that don't send a client_id).
                    options.AcceptAnonymousClients();
                    // During development, you can disable the HTTPS requirement.
                    options.DisableHttpsRequirement();
                })
                // Register the OpenIddict validation handler.
                // Note: the OpenIddict validation handler is only compatible with the
                // default token format or with reference tokens and cannot be used with
                // JWT tokens. For JWT tokens, use the Microsoft JWT bearer handler.
                .AddValidation();
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = "ServerCookie";
            });

            services.AddScoped<IUnitOfWork<DungeonCrawlerDbContextSql, GameService>, UnitOfWork<DungeonCrawlerDbContextSql>>();
            services.AddControllers(options => { options.Filters.Add(typeof(ActionFilter)); })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });
            services.Configure<DungeonsCrawlerMongoDbSettings>(
                Configuration.GetSection(nameof(DungeonsCrawlerMongoDbSettings)));
            services.AddSingleton<IDungeonsCrawlerMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<DungeonsCrawlerMongoDbSettings>>().Value);
            services.AddSingleton<GameService>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.WithOrigins(Environment.GetEnvironmentVariable("IP_FRONT_ENVIRONEMENT"))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });
            services.AddSignalR();
        }

        //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Groupe3.Dungeon_Crawler.WebApplication v1"));
            }

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
