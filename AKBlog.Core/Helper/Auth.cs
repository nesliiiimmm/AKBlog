using AKBlog.Core.Interfaces;
using AKBlog.Core.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AKBlog.Core.Helper
{
    public class Auth : IJwtAuth
    {
        private readonly string key;
        public Auth(string key)
        {
            this.key = key;
        }
        public string Authentication(User user)
        {
            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);
            SymmetricSecurityKey sk = new SymmetricSecurityKey(tokenKey);
            SigningCredentials sgn = new SigningCredentials(sk, SecurityAlgorithms.HmacSha256Signature);
            
            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                   new List<Claim> { new Claim(ClaimTypes.Name, user.Name) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = sgn
            };

            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
