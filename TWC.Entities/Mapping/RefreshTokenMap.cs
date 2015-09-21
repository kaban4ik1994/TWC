using System.Data.Entity.ModelConfiguration;
using TWC.Entities.Models;

namespace TWC.Entities.Mapping
{
	public class RefreshTokenMap : EntityTypeConfiguration<RefreshToken>
	{
		public RefreshTokenMap()
		{
			HasKey(token => token.Id);

			Property(token => token.Subject).IsRequired().HasMaxLength(50);
			Property(token => token.ClientId).IsRequired().HasMaxLength(50);
			Property(token => token.IssuedUtc);
			Property(token => token.ExpiresUtc);
			Property(token => token.ProtectedTicket).IsRequired();

			ToTable("Tokens");
		}
	}
}
