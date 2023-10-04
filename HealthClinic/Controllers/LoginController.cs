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
    /// <summary>
    /// Controlador para operações relacionadas a autenticação e geração de tokens JWT.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Repositório de usuários.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de usuários.
        /// </summary>
        public LoginController()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// Realiza a autenticação do usuário e gera um token JWT se a autenticação for bem-sucedida.
        /// </summary>
        /// <param name="login">As credenciais de login do usuário.</param>
        /// <returns>Uma resposta HTTP contendo o token JWT se a autenticação for bem-sucedida.</returns>
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

                if (foundUser != null)
                {
                    // Define as informações do token (payload), como parâmetros estão as propriedades do usuário que serão inseridas no token
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, foundUser.UserId.ToString() ),
                        new Claim(JwtRegisteredClaimNames.Email, foundUser.Email),
                        new Claim(ClaimTypes.Role, foundUser.IsAdmin.ToString()),
                    };

                    // Define a chave de acesso ao token
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key-healthclinic.webapi.auth.dev-senai"));

                    // Define as credenciais do token
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Gera o token JWT
                    var token = new JwtSecurityToken(
                        // Emissor do token
                        issuer: "HealthClinic",
                        // Destinatário do token
                        audience: "HealthClinic",
                        // Informações do token
                        claims: claims,
                        // Duração do token
                        expires: DateTime.Now.AddMinutes(30),
                        // Credenciais que serão utilizadas
                        signingCredentials: creds
                    );

                    // Retorna um Ok e o token JWT
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
