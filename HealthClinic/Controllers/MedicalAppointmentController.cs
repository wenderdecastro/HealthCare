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
    /// Controlador para operações relacionadas a consultas médicas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de consultas médicas.
        /// </summary>
        public MedicalAppointmentController()
        {
            _medicalAppointmentRepository = new MedicalAppointmentRepository();
        }

        /// <summary>
        /// Cria uma nova consulta médica.
        /// </summary>
        /// <param name="medicalAppointment">A consulta médica a ser criada.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da criação.</returns>
        [HttpPost]
        [Authorize(Roles = "True")]
        public IActionResult Create(MedicalAppointment medicalAppointment)
        {
            try
            {
                _medicalAppointmentRepository.Create(medicalAppointment);
                return Created("MedicalAppointment created.", medicalAppointment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de consultas médicas.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de consultas médicas.</returns>
        [HttpGet]
        [Authorize(Roles = "True")]
        public IActionResult List()
        {
            try
            {
                return Ok(_medicalAppointmentRepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cancela uma consulta médica por ID.
        /// </summary>
        /// <param name="medAppointmentId">O ID da consulta médica a ser cancelada.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso do cancelamento.</returns>
        [HttpPatch("{medAppointmentId}")]
        [Authorize(Roles = "True")]
        public IActionResult Cancel(Guid medAppointmentId)
        {
            try
            {
                _medicalAppointmentRepository.Cancel(medAppointmentId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma consulta médica por ID.
        /// </summary>
        /// <param name="id">O ID da consulta médica a ser obtida.</param>
        /// <returns>Uma resposta HTTP contendo a consulta médica encontrada.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "True")]
        public IActionResult SearchById(Guid id)
        {
            try
            {
                MedicalAppointment foundMedAppoint = _medicalAppointmentRepository.SearchById(id);
                return Ok(foundMedAppoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de consultas médicas de um paciente por ID de paciente.
        /// </summary>
        /// <param name="patientId">O ID do paciente para o qual buscar as consultas médicas.</param>
        /// <returns>Uma resposta HTTP contendo a lista de consultas médicas do paciente.</returns>
        [HttpGet("Patient/{patientId}")]
        [Authorize(Roles = "True, False")]
        public IActionResult SearchByPatient(Guid patientId)
        {
            try
            {
                return Ok(_medicalAppointmentRepository.SearchByPatient(patientId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de consultas médicas de um médico por ID de médico.
        /// </summary>
        /// <param name="medicId">O ID do médico para o qual buscar as consultas médicas.</param>
        /// <returns>Uma resposta HTTP contendo a lista de consultas médicas do médico.</returns>
        [HttpGet("Medic/{medicId}")]
        [Authorize(Roles = "True")]
        public IActionResult SearchByMedic(Guid medicId)
        {
            try
            {
                return Ok(_medicalAppointmentRepository.SearchByMedic(medicId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }
    }
}
