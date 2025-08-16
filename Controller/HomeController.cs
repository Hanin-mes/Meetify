using Microsoft.AspNetCore.Mvc;
using Meetify.Business.IRepository;
using System.Threading.Tasks;
using Meetify.Models;
using Meetify.DTOs;
using AutoMapper;
namespace Meetify.Controllers
{
    public class HomeController : Controller
    {
        // GET: /
        public IActionResult Index()
        {
            return View();
        }
    }
}
