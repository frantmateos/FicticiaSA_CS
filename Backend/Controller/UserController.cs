using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using users.Models;
using users.Services;

namespace users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _service.GetById(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound("Usuario no encontrado.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                _service.Save(user);
                return Ok("Usuario ingresado con éxito.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] User user)
        {
            try
            {
                _service.Update(id, user);
                return Ok("Usuario actualizado.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }      
    }
}
