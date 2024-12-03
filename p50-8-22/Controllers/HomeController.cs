using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using p50_8_22.Models;


namespace p50_8_22.Controllers
{
    public class HomeController : Controller
    {
        private readonly SamokatDbContext _context;

        public HomeController(SamokatDbContext context)
        {
            _context = context;
        }

       

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        
    }
}
