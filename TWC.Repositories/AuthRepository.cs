﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TWC.Entities;
using TWC.Entities.Models;
using TWC.Repositories.Interfaces;

namespace TWC.Repositories
{
	public class AuthRepository : IDisposable, IAuthRepository
	{
		private AuthContext _context;
		private UserManager<IdentityUser> _userManager;

		public AuthRepository()
		{
			_context = new AuthContext();
			_userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
		}

		public async Task<IdentityResult> RegisterUser(string userName, string password)
		{
			var user = new IdentityUser
			{
				UserName = userName
			};

			var result = await _userManager.CreateAsync(user, password);

			return result;
		}

		public async Task<IdentityUser> FindUser(string userName, string password)
		{
			var user = await _userManager.FindAsync(userName, password);

			return user;
		}

		public Client FindClient(string clientId)
		{
			var client = _context.Clients.Find(clientId);

			return client;
		}

		public async Task<bool> AddRefreshToken(RefreshToken token)
		{
			var existingToken = _context.RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

			if (existingToken != null)
			{
				await RemoveRefreshToken(existingToken);
			}

			_context.RefreshTokens.Add(token);

			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> RemoveRefreshToken(string refreshTokenId)
		{
			var refreshToken = await _context.RefreshTokens.FindAsync(refreshTokenId);

			if (refreshToken != null)
			{
				_context.RefreshTokens.Remove(refreshToken);
				return await _context.SaveChangesAsync() > 0;
			}

			return false;
		}

		public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
		{
			_context.RefreshTokens.Remove(refreshToken);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
		{
			var refreshToken = await _context.RefreshTokens.FindAsync(refreshTokenId);

			return refreshToken;
		}

		public List<RefreshToken> GetAllRefreshTokens()
		{
			return _context.RefreshTokens.ToList();
		}

		public async Task<IdentityUser> FindAsync(UserLoginInfo loginInfo)
		{
			var user = await _userManager.FindAsync(loginInfo);

			return user;
		}

		public async Task<IdentityResult> CreateAsync(IdentityUser user)
		{
			var result = await _userManager.CreateAsync(user);

			return result;
		}

		public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
		{
			var result = await _userManager.AddLoginAsync(userId, login);

			return result;
		}

		public void Dispose()
		{
			_context.Dispose();
			_userManager.Dispose();
		}
	}
}
