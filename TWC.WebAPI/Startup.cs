﻿using System;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TWC.AuthProviders;
using TWC.Entities;
using TWC.Entities.Migrations;
using TWC.WebAPI;

[assembly: OwinStartup(typeof(Startup))]
namespace TWC.WebAPI
{
	public class Startup
	{
		public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
		public static GoogleOAuth2AuthenticationOptions GoogleAuthOptions { get; private set; }
		public static FacebookAuthenticationOptions FacebookAuthOptions { get; private set; }

		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();

			ConfigureOAuth(app);

			WebApiConfig.Register(config);
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
			Database.SetInitializer(new TwcContextInitializer());
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

			//Configure Google External Login
			GoogleAuthOptions = new GoogleOAuth2AuthenticationOptions()
			{
				ClientId = "xxxxxx",
				ClientSecret = "xxxxxx",
				Provider = new GoogleAuthProvider()
			};
			app.UseGoogleAuthentication(GoogleAuthOptions);

			//Configure Facebook External Login
			FacebookAuthOptions = new FacebookAuthenticationOptions()
			{
				AppId = "xxxxxx",
				AppSecret = "xxxxxx",
				Provider = new FacebookAuthProvider()
			};
			app.UseFacebookAuthentication(FacebookAuthOptions);

		}
	}
}