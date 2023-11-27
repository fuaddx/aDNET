
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using AdoNet.Helpers;
using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace AdoNet.Services

{
    internal class UserService:IBaseService<User>
    {

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
       


        public int Register(User data)
        {
            string query = $"INSERT INTO User VALUES(N'{data.Name}',N'{data.Surname}',N'{data.Password}')";
            return SqlHelper.Exec(query);
        }
    }
}
