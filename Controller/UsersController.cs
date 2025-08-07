using Microsoft.AspNetCore.Mvc;
using Meetify.Business.IRepository;
using System.Threading.Tasks;
using Meetify.Models;
using Meetify.DTOs;
using AutoMapper;

namespace Meetify.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _usersRepository.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDTO>>(users);
            return View(userDtos);
        }

        public async Task<IActionResult> Details(long id)
        {
            var user = await _usersRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var userDto = _mapper.Map<UserDTO>(user);
            return View(userDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO userDto)
        {
            if (!ModelState.IsValid) return View(userDto);

            var user = _mapper.Map<Users>(userDto);
            user.CreatedAt = DateTime.Now;
            await _usersRepository.AddAsync(user);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long id)
        {
            var user = await _usersRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var editDto = _mapper.Map<UpdateUserDTO>(user);
            return View(editDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserDTO userDto)
        {
            if (!ModelState.IsValid) return View(userDto);

            var user = _mapper.Map<Users>(userDto);
            await _usersRepository.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var user = await _usersRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var userDto = _mapper.Map<UserDTO>(user);
            return View(userDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _usersRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
