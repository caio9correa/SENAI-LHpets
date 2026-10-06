using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    // Lista em memória (static para persistir entre as requisições)
    private static readonly List<Pet> Pets = new();
    private static int _proximoId = 1;

    // GET /api/pets
    [HttpGet]
    public ActionResult<IEnumerable<Pet>> Get()
    {
        return Ok(Pets);
    }

    // POST /api/pets
    [HttpPost]
    public ActionResult<Pet> Post([FromBody] Pet pet)
    {
        if (string.IsNullOrWhiteSpace(pet.Nome) ||
            string.IsNullOrWhiteSpace(pet.Especie))
        {
            return BadRequest("Nome e Espécie são obrigatórios.");
        }

        var clienteExiste = ClientesController.Clientes.Any(c => c.Id == pet.ClienteId);
        if (!clienteExiste)
        {
            return BadRequest($"Cliente com Id {pet.ClienteId} não encontrado.");
        }

        pet.Id = _proximoId++;
        Pets.Add(pet);

        return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
    }

    // GET /api/pets/cliente/{clienteId}
    [HttpGet("cliente/{clienteId}")]
    public ActionResult<IEnumerable<Pet>> GetPorCliente(int clienteId)
    {
        var pets = Pets.Where(p => p.ClienteId == clienteId).ToList();
        return Ok(pets);
    }
}
