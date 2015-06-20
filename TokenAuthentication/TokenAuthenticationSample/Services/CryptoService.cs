// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Security.Cryptography;
using System.Text;

namespace RestSample.Server.Services
{

    public class CryptoService : ICryptoService
    {
        private IApplicationSettings settings;

        public CryptoService(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public void CreateHash(byte[] data, out byte[] hash, out byte[] salt)
        {
            salt = CreateSalt();
            hash = ComputeHash(data, salt);
        }

        public byte[] ComputeHash(byte[] data, byte[] salt)
        {
            byte[] saltedData = Concatenate(data, salt);
            byte[] hashBytes = SHA256.Create().ComputeHash(saltedData);

            return hashBytes;
        }

        private byte[] CreateSalt()
        {
            byte[] randomBytes = new byte[settings.SaltSize];
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                randomGenerator.GetBytes(randomBytes);
                return randomBytes;
            }
        }

        private byte[] Concatenate(byte[] a, byte[] b)
        {
            byte[] result = new byte[a.Length + b.Length];

            System.Buffer.BlockCopy(a, 0, result, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, result, a.Length, b.Length);

            return result;
        }
    }

    public static class CryptoServiceExtensions
    {
        public static void CreateHash(this ICryptoService cryptoService, string data, out string hash, out string salt)
        {
            byte[] hashBytes;
            byte[] saltBytes;
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            cryptoService.CreateHash(dataBytes, out hashBytes, out saltBytes);

            hash = Convert.ToBase64String(hashBytes);
            salt = Convert.ToBase64String(saltBytes);
        }

        public static string ComputeHash(this ICryptoService cryptoService, string data, string salt)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] hashBytes = cryptoService.ComputeHash(dataBytes, saltBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}