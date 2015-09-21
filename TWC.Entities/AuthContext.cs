using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TWC.Entities.Models;

namespace TWC.Entities
{
	public class AuthContext : IdentityDbContext<IdentityUser>
	{

		static AuthContext()
		{
			Database.SetInitializer<AuthContext>(new AuthContextInitializer());
		}


		public AuthContext()
			: base("AuthContext")
		{
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }
	}
}
