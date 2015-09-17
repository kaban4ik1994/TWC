using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security;
using TWC.Repositories;

namespace TWC.WebAPI.Controllers
{
	public class AccountController : ApiController
	{
		private AuthRepository _repo = null;

		private IAuthenticationManager Authentication
		{
			get { return Request.GetOwinContext().Authentication; }
		}

		public AccountController()
		{
			_repo = new AuthRepository();
		}
	}
}