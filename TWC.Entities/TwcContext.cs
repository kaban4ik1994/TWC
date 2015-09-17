using Repository.Pattern.Ef6;
using System.Data.Entity;
using TWC.Entities.Models;


namespace TWC.Entities
{
	public partial class TwcContext : DataContext
	{
		static TwcContext()
		{
			Database.SetInitializer<TwcContext>(new TwcContextInitializer());
		}

		public TwcContext()
			: base("TwcContext")
		{
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }
	}
}
