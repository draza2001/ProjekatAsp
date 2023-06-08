using Api.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProjekatASP.Application;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.Emails;
using ProjekatASP.Application.Queries;
using ProjekatASP.Application.Queries.User;
using ProjekatASP.Application.Util;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Implementation;
using ProjekatASP.Implementation.Emails;
using ProjekatASP.Implementation.Log;
using ProjekatASP.Implementation.Queries;
using ProjekatASP.Implementation.Validators;
using ProjekatASP.Implementation.Validators.ArticleValidators;
using ProjekatASP.Implementation.Validators.BlogValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUsesCases(this IServiceCollection services)
        {
            
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IGetUserQuery,EfGetUsersQuery >();
            services.AddTransient<IEmailSender, SmtpEmailSender>();


            services.AddTransient<IUseCaseLogger,DatabaseUseCaseLogger >();

            
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateBlogValidator>();
            services.AddTransient<UpdateBlogValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<CreateCommentValidator>();


            services.AddTransient<IGetLogsQuery, EfGetLogsQuery>();

            services.AddTransient<JwtManager>();
            services.AddTransient<Context>();
            services.AddTransient<UseCaseExecutor>();
            services.AddHttpContextAccessor();
        }

        public static void AddAplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;
                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }
                var actorString = user.FindFirst("ActorData").Value;
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return (IApplicationActor)actor;
            });
        }
        public static void AddJwt(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime=true,
                    ClockSkew=TimeSpan.Zero
                    
                   
                        
                };
            });
        }
    }
}
