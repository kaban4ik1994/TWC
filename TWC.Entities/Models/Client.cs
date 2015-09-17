using System.Collections.Generic;
using Repository.Pattern.Ef6;
using TWC.Enums;

namespace TWC.Entities.Models
{
	public class Client : Entity
	{
		public string Id { get; set; }
		public string Secret { get; set; }
		public string Name { get; set; }
		public ApplicationTypes ApplicationType { get; set; }
		public bool Active { get; set; }
		public int RefreshTokenLifeTime { get; set; }
		public string AllowedOrigin { get; set; }

		public List<RefreshToken> Tokens { get; set; }
	}
}
