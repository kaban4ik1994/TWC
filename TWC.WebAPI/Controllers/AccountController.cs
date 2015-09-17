using System.Data.Entity.Core.Metadata.Edm;
using System.Threading.Tasks;
using System.Web.ApplicationServices;
using System.Web.Http;
using System.Web.Http.Results;
using Repository.Pattern.Ef6;
using Service.Pattern;
using TWC.Entities;
using TWC.Entities.Models;
using TWC.Repositories;

namespace TWC.WebAPI.Controllers
{
	public class AccountController : ApiController
	{
		public Task<IHttpActionResult> Get()
		{
			AuthRepository auth = new AuthRepository();
			var test = new Repository<Client>(new TwcContext(), new UnitOfWork(new TwcContext()));
			test.Insert(new Client());
			auth.RegisterUser("test", "testsadsadsa");
			return null;
		}
	}
}