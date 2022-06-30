﻿using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.EntityFramework.Storage;
using IdentityModel;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<AspNetIdentityDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AspNetIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddOperationalDbContext(
                options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
                }
                );
            services.AddConfigurationDbContext
                (options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
                }
           );
            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

            var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
            context.Database.Migrate();
            EnsureSeedData(context);

            var ctx = scope.ServiceProvider.GetService<AspNetIdentityDbContext>();
            ctx.Database.Migrate();
            EnsureUsers(scope);

        }

        private static void EnsureUsers(IServiceScope scope)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var testUser = userMgr.FindByNameAsync("test").Result;

            if (testUser == null)
            {
                testUser = new IdentityUser
                {
                    UserName = "test",
                    Email = "test@hotmail.com",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(testUser, "Pass123.").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                result = userMgr.AddClaimsAsync(testUser,
                    new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, "test test"),
                    new Claim(JwtClaimTypes.GivenName,"test"),
                    new Claim(JwtClaimTypes.FamilyName,"test"),
                    new Claim(JwtClaimTypes.WebSite,"https://google.com"),
                    new Claim("location","somewhere")
                }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
            }


        }

        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if(!context.Clients.Any())
            {
                foreach(var client in Config.Clients.ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources.ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.ApiResources.ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var scope in Config.ApiScopes.ToList())
                {
                    context.ApiScopes.Add(scope.ToEntity());
                }
                context.SaveChanges();
            }
        }

    }
}
