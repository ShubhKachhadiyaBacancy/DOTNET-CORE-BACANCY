using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DAY5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JWTAuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public JWTAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost(Name ="JWTAuthController")]
        public IActionResult Post([FromQuery]string id,string username,string password)
        {
            var adminUsername = _configuration.GetSection("Admin:Username").Value;
            var adminId = _configuration.GetSection("Admin:Id").Value;
            var adminPassword = _configuration.GetSection("Admin:Password").Value;

            if (id == adminId && username == adminUsername && password == adminPassword)
            {
                var token = GenerateJwtToken(id,username,password);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string id,string username,string password)
        {
            var expiration = Convert.ToDouble(_configuration.GetSection("JWT:Expiration").Value);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("AdminId", id),
                new Claim("AdminUsername", username),
                new Claim("AdminPassword", password),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiration),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
