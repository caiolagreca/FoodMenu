using FoodMenu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodMenu.Controllers
{
    public class MenuController : Controller
    {
        private readonly FoodContext _context;

        public MenuController(FoodContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var plates = from p in _context.Plates select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                plates = plates.Where(p => p.Name.Contains(searchString));
                return View(await plates.ToListAsync());
            }
            return View(await _context.Plates.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var plate = await _context.Plates.Include(pi => pi.PlateIngredients).ThenInclude(i => i.Ingredient).FirstOrDefaultAsync(x => x.Id == id);

            if (plate == null)
            {
                return NotFound();
            }

            return View(plate);
        }
    }
}
