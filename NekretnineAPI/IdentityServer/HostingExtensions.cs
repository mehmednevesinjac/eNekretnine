using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Services;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
        {
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly));
        });

        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AspNetIdentityDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "IdentityServer.Cookie";
            options.LoginPath = "/Auth/Login";
            options.LogoutPath = "/Auth/Logout";
        });

        builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.EmitStaticAudienceClaim = true;
        })
       .AddAspNetIdentity<IdentityUser>()
       .AddConfigurationStore(options =>
       {
           options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
               sql => sql.MigrationsAssembly(migrationsAssembly));
       })
       .AddOperationalStore(options =>
       {
           options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
               sql => sql.MigrationsAssembly(migrationsAssembly));
       })
       .AddDeveloperSigningCredential();
        builder.Services.AddSingleton<ICorsPolicyService>((container) => {
            var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
            return new DefaultCorsPolicyService(logger)
            {
                AllowAll = true
            };
        });
        builder.Services.AddControllersWithViews();
        return builder.Build();
    }



    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.UseRouting();


        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseIdentityServer().UseCors();
            
        //app.UseCors(x =>
        //{
        //    x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        //});
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
        return app;
    }
}
