﻿using System;
using System.Security.Cryptography;

namespace TWC.Helpers
{
	public static class PasswordHashHelper
	{
		public static string GetHash(string input)
		{
			var hashAlgorithm = new SHA256CryptoServiceProvider();

			var byteValue = System.Text.Encoding.UTF8.GetBytes(input);

			var byteHash = hashAlgorithm.ComputeHash(byteValue);

			return Convert.ToBase64String(byteHash);
		}
	}
}
