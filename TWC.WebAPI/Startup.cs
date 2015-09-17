using System;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TWC.AuthProviders;
using TWC.Entities;
using TWC.Entities.Migrations;
using TWC.WebAPI;
using TWC.WebAPI.App_Start;

[assembly: OwinStartup(typeof(Startup))]

namespace TWC.WebAPI
{
	public class Startup
	{
		public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();

			ConfigureOAuth(app);

			WebApiConfig.Register(config);
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
			Database.SetInitializer<TwcContext>(new TwcContextInitializer());
			//Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwcContext, Configuration>());

		}
		public void ConfigureOAuth(IAppBuilder app)
		{
			//use a cookie to temporarily store information about a user logging in with a third party login provider
			app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
			OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{

				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
				Provider = new SimpleAuthorizationServerProvider(),
				RefreshTokenProvider = new SimpleRefreshTokenProvider()
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(OAuthBearerOptions);
		}

	}
}