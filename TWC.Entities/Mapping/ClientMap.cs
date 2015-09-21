using System.Data.Entity.ModelConfiguration;
using TWC.Entities.Models;

namespace TWC.Entities.Mapping
{
	public class ClientMap : EntityTypeConfiguration<Client>
	{
		public ClientMap()
		{
			HasKey(client => client.Id);

			Property(client => client.Secret).IsRequired();
			Property(client => client.Name).IsRequired().HasMaxLength(100);
			Property(client => client.ApplicationType);
			Property(client => client.Active);
			Property(client => client.RefreshTokenLifeTime);
			Property(client => client.AllowedOrigin).HasMaxLength(100);

			ToTable("Clients");
		}
	}
}
