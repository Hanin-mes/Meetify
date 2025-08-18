using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Meetify.Business.IRepository;
using Meetify.DTOs.Users;
using Meetify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Meetify.Controllers.Api;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // <-- NEW: protect whole controller with JWT
[ApiController]
[Route("api/users")] // JSON endpoints live here
public class UsersApiController : ControllerBase
{
    private readonly IUsersRepository _repo;
    private readonly IMapper _mapper;

    public UsersApiController(IUsersRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    // GET: /api/users
    [AllowAnonymous] // <-- stays public; delete this attribute if you want it protected too
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UsersDTO>), 200)]
    public async Task<ActionResult<IEnumerable<UsersDTO>>> GetAll()
    {
        var users = await _repo.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<UsersDTO>>(users));
    }

    // GET: /api/users/5
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(UsersDTO), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<UsersDTO>> GetById(long id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user is null) return NotFound();
        return Ok(_mapper.Map<UsersDTO>(user));
    }

    // POST: /api/users
    [HttpPost]
    [ProducesResponseType(typeof(UsersDTO), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<UsersDTO>> Create(CreateUsersDTO dto)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        if (await _repo.EmailExistsAsync(dto.Email))
        {
            ModelState.AddModelError(nameof(dto.Email), "Email already exists.");
            return ValidationProblem(ModelState);
        }

        var entity = _mapper.Map<Users>(dto);
        entity.CreatedAt = DateTime.UtcNow;

        entity = await _repo.CreateAsync(entity);
        var read = _mapper.Map<UsersDTO>(entity);

        return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
    }

    // PUT: /api/users/5
    [HttpPut("{id:long}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(long id, UpdateUsersDTO dto)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return NotFound();

        if (await _repo.EmailExistsAsync(dto.Email, excludeId: id))
        {
            ModelState.AddModelError(nameof(dto.Email), "Email already exists.");
            return ValidationProblem(ModelState);
        }

        _mapper.Map(dto, existing);
        var ok = await _repo.UpdateAsync(existing);
        if (!ok) return Problem("Update failed.");

        return NoContent();
    }

    // DELETE: /api/users/5
    [HttpDelete("{id:long}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
