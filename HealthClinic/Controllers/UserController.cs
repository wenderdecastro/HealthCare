using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HealthClinic.Controllers
{
    /// <summary>
    /// Controlador para operações relacionadas a usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de usuários.
        /// </summary>
        public UserController()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">O usuário a ser criado.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da criação.</returns>
        [HttpPost]
        [Authorize(Roles = "True")]
        public IActionResult Create(User user)
        {
            try
            {
                _userRepository.Create(user);

                return Created("User created.", user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de usuários.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de usuários.</returns>
        [HttpGet]
        [Authorize(Roles = "True")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_userRepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um usuário por ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser atualizado.</param>
        /// <param name="user">Os dados atualizados do usuário.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da atualização.</returns>
        [HttpPatch]
        [Authorize(Roles = "True")]
        public IActionResult Update(Guid id, User user)
        {
            try
            {
                _userRepository.Update(id, user);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Exclui um usuário por ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser excluído.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da exclusão.</returns>
        [HttpDelete]
        [Authorize(Roles = "True")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _userRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém um usuário por ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser obtido.</param>
        /// <returns>Uma resposta HTTP contendo o usuário encontrado ou NotFound se não encontrado.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "True")]
        public IActionResult Get(Guid id)
        {
            try
            {
                User foundUser = _userRepository.SearchById(id);

                if (foundUser != null)
                {
                    return Ok(foundUser);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Realiza uma pesquisa de login de usuário com base no email e senha.
        /// </summary>
        /// <param name="user">Os dados de login do usuário.</param>
        /// <returns>Uma resposta HTTP contendo o usuário encontrado ou NotFound se não encontrado.</returns>
        [HttpPost("UserLogin")]
        [Authorize(Roles = "True")]
        public IActionResult SearchByLogin(User user)
        {
            try
            {
                User foundUser = _userRepository.SearchByEmailAndPassword(user);

                if (foundUser != null)
                {
                    return Ok(foundUser);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }
    }
}
