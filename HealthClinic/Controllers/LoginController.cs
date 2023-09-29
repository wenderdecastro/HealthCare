using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Repositories;
using HealthClinic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public LoginController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                User userLogin = new User()
                {
                    Email = login.Email,
                    Password = login.Password
                };


                User foundUser = _userRepository.SearchByEmailAndPassword(userLogin);
                
                if(foundUser != null)
                {
                    //1º, define as informações do token (payload), como parametro estão as propriedades do usuário que serão inseridas no token

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, foundUser.UserId.ToString() ),
                        new Claim(JwtRegisteredClaimNames.Email, foundUser.Email),
                        new Claim(ClaimTypes.Role, foundUser.IsAdmin.ToString()),

                    };

                    //2º define chave de acesso ao token
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key-healthclinic.webapi.auth.dev-senai"));

                    //3º define as credenciais do token
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //4º Gera o token JWT
                    var token = new JwtSecurityToken(
                        // emissor do token
                        issuer: "HealthClinic",
                        // destinatario do token
                        audience: "HealthClinic",
                        // informações do token
                        claims: claims,
                        // duração do token
                        expires: DateTime.Now.AddMinutes(30),
                        // credenciais que serão utilizadas
                        signingCredentials: creds
                        );

                    //retorna um ok e o token JWT
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });

                }

                return BadRequest("Email or password invalid.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }
    }
}
