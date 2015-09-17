using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TWC.Entities.Models;

namespace TWC.Repositories.Interfaces
{
	public interface IAuthRepository
	{
		Task<IdentityResult> RegisterUser(string userName, string password);
		Task<IdentityUser> FindUser(string userName, string password);
		Client FindClient(string clientId);
		Task<bool> AddRefreshToken(RefreshToken token);
		Task<bool> RemoveRefreshToken(string refreshTokenId);
		Task<bool> RemoveRefreshToken(RefreshToken refreshToken);
		Task<RefreshToken> FindRefreshToken(string refreshTokenId);
		List<RefreshToken> GetAllRefreshTokens();
		Task<IdentityUser> FindAsync(UserLoginInfo loginInfo);
		Task<IdentityResult> CreateAsync(IdentityUser user);
		Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
		void Dispose();
	}
}
