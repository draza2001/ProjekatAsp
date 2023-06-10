using Api.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProjekatASP.Application;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.Commands.Blogcommands;
using ProjekatASP.Application.Commands.CategoryCommands;
using ProjekatASP.Application.Commands.CommentCommands;
using ProjekatASP.Application.Commands.Usercommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Emails;
using ProjekatASP.Application.Queries;
using ProjekatASP.Application.Queries.BlogQuery;
using ProjekatASP.Application.Queries.CategoryQuery;
using ProjekatASP.Application.Queries.CommentQuery;
using ProjekatASP.Application.Queries.User;
using ProjekatASP.Application.Util;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Implementation;
using ProjekatASP.Implementation.Commands;
using ProjekatASP.Implementation.Commands.EfBlogCommands;
using ProjekatASP.Implementation.Commands.EfCategoryCommand;
using ProjekatASP.Implementation.Commands.EfCommentCommads;
using ProjekatASP.Implementation.Commands.EfUserCommands;
using ProjekatASP.Implementation.Emails;
using ProjekatASP.Implementation.Log;
using ProjekatASP.Implementation.Queries;
using ProjekatASP.Implementation.Queries.EfBlogQueries;
using ProjekatASP.Implementation.Queries.EfCommentQueries;
using ProjekatASP.Implementation.Queries.User;
using ProjekatASP.Implementation.Validators;
using ProjekatASP.Implementation.Validators.ArticleValidators;
using ProjekatASP.Implementation.Validators.BlogValidators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
			services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
			services.AddTransient<IGetUserQuery,EfGetUsersQuery>();
			services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
			services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
			services.AddTransient<IEmailSender, SmtpEmailSender>();

			services.AddTransient<ICreateBlogCommand, EfCreateBlogCommand>();
			services.AddTransient<IGetBlogsQuery, EfGetBlogsQuery>();
			services.AddTransient<IGetBlogQuery, EfGetBlogQuery>();
			services.AddTransient<IUpdateBlogCommand, EfUpdateBlogCommand>();
			services.AddTransient<IDeleteBlogCommand, EfDeleteBlogCommand>();

			services.AddTransient<IGetCommentsQuery, EfGetCommentsQuery>();
			services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
			services.AddTransient<IUpdateCommentCommand,EfUpdateCommentCommand>();
			services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();

			services.AddTransient<IRateBlog, EfRateBlogCommand>();

			services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
			services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
			services.AddTransient<IGetCategoryQuery,EfGetCategoryQuery >();
			services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
			services.AddTransient<IDeleteCategoryCommand,EfDeleteCategoryCommand>();

            services.AddTransient<IUseCaseLogger,DatabaseUseCaseLogger >();

            
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateBlogValidator>();
            services.AddTransient<UpdateBlogValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<CreateCommentValidator>();
            


            services.AddTransient<IGetLogsQuery, EfGetLogsQuery>();

			//services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

			services.AddTransient<JwtManager>();
			services.AddTransient<Context>();
            services.AddTransient<UseCaseExecutor>();
            services.AddHttpContextAccessor();

         
        }

		public static void AddApplicationActor(this IServiceCollection services)
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

				return actor;
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
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				};
			});
		}
	}
}
