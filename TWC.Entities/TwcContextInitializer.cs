using System.Collections.Generic;
using System.Data.Entity;
using Repository.Pattern.Infrastructure;
using TWC.Entities.Models;
using TWC.Enums;
using TWC.Helpers;

namespace TWC.Entities
{
	public class TwcContextInitializer : CreateDatabaseIfNotExists<TwcContext>
	{
		protected override void Seed(TwcContext context)
		{
			context.Clients.AddRange(BuildClientsList());
			context.SaveChanges();
			base.Seed(context);
		}

		private static IEnumerable<Client> BuildClientsList()
		{
			var clientsList = new List<Client> 
            {
                new Client
                { Id = "ngAuthApp", 
                    Secret= PasswordHashHelper.GetHash("abc@123"), 
                    Name="AngularJS front-end Application", 
                    ApplicationType =  ApplicationTypes.JavaScript, 
                    Active = true, 
                    RefreshTokenLifeTime = 7200, 
                    AllowedOrigin = "http://ngauthenticationweb.azurewebsites.net",
										ObjectState = ObjectState.Added
                },
                new Client
                { Id = "consoleApp", 
                    Secret=PasswordHashHelper.GetHash("123@abc"), 
                    Name="Console Application", 
                    ApplicationType =ApplicationTypes.NativeConfidential, 
                    Active = true, 
                    RefreshTokenLifeTime = 14400, 
                    AllowedOrigin = "*",
										ObjectState = ObjectState.Added
                }
            };

			return clientsList;
		}
	}
}
