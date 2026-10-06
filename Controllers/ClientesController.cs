using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    // Lista em memória (static para persistir entre as requisições)
    internal static readonly List<Cliente> Clientes = new();
    private static int _proximoId = 1;

    // GET /api/clientes
    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> Get()
    {
        return Ok(Clientes);
    }

    // POST /api/clientes
    [HttpPost]
    public ActionResult<Cliente> Post([FromBody] Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome) ||
            string.IsNullOrWhiteSpace(cliente.Cpf) ||
            string.IsNullOrWhiteSpace(cliente.Email))
        {
            return BadRequest("Nome, Cpf e Email são obrigatórios.");
        }

        cliente.Id = _proximoId++;
        Clientes.Add(cliente);

        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }
}
