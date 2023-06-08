using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public class JwtManager
    {
        private readonly Context _context;

        public JwtManager(Context context)
        {
            _context = context;
        }
        public string MakeToken(string username,string password)
        {
            var user = _context.Users.Include(x => x.UserUseCases)
                .FirstOrDefault(y => y.UserName == username && y.Password == password);
            if (user == null)
            {
                return null;
            }
            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.UserUseCases.Select(x => x.UserUseCaseId),
                Identity = user.UserName
            };
            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString(),ClaimValueTypes.String,issuer),
                new Claim(JwtRegisteredClaimNames.Iss,"asp_api",ClaimValueTypes.String,issuer),
                new Claim(JwtRegisteredClaimNames.Iat,DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer64,issuer),
                new Claim("UserId",actor.Id.ToString(),ClaimValueTypes.String,issuer),
                new Claim("ActorData",JsonConvert.SerializeObject(actor),ClaimValueTypes.String,issuer)
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credemntials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(300),
                signingCredentials: credemntials

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
