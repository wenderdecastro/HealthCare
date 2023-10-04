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
    /// Controlador para operações relacionadas a registros médicos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordsRepository _medicalRecordsRepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de registros médicos.
        /// </summary>
        public MedicalRecordsController()
        {
            _medicalRecordsRepository = new MedicalRecordsRepository();
        }

        /// <summary>
        /// Cria um novo registro médico.
        /// </summary>
        /// <param name="medicalRecord">O registro médico a ser criado.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da criação.</returns>
        [HttpPost]
        [Authorize(Roles = "True")]
        public IActionResult Create(MedicalRecords medicalRecord)
        {
            try
            {
                _medicalRecordsRepository.Create(medicalRecord);
                return Created("MedicalRecords created.", medicalRecord);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de registros médicos.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de registros médicos.</returns>
        [HttpGet]
        [Authorize(Roles = "True")]
        public IActionResult List()
        {
            try
            {
                return Ok(_medicalRecordsRepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um registro médico por ID.
        /// </summary>
        /// <param name="medicalRecordId">O ID do registro médico a ser atualizado.</param>
        /// <param name="medicalRecord">O registro médico atualizado.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da atualização.</returns>
        [HttpPatch]
        [Authorize(Roles = "True")]
        public IActionResult Update(Guid medicalRecordId, MedicalRecords medicalRecord)
        {
            try
            {
                _medicalRecordsRepository.Update(medicalRecordId, medicalRecord);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de registros médicos por ID de paciente.
        /// </summary>
        /// <param name="patientId">O ID do paciente para o qual buscar os registros médicos.</param>
        /// <returns>Uma resposta HTTP contendo a lista de registros médicos do paciente.</returns>
        [HttpGet("{patientId}")]
        [Authorize(Roles = "True, False")]
        public IActionResult SearchByPatient(Guid patientId)
        {
            try
            {
                return Ok(_medicalRecordsRepository.SearchByPatient(patientId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }
    }
}
