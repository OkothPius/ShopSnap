using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSnap.Data;
using System.Diagnostics;

namespace ShopSnap.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return _context.Items != null ?
                View(await _context.Items.ToListAsync()) :
                Problem("Entity set 'DatabaseContext.Items'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}