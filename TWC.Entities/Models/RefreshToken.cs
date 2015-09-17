using System;
using Repository.Pattern.Ef6;

namespace TWC.Entities.Models
{
	public class RefreshToken : Entity
	{
		public string Id { get; set; }
		public string Subject { get; set; }
		public string ClientId { get; set; }
		public DateTime IssuedUtc { get; set; }
		public DateTime ExpiresUtc { get; set; }
		public string ProtectedTicket { get; set; }

		public Client Client { get; set; }
	}
}
