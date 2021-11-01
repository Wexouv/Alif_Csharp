using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class CategoryController : Controller {
        public readonly ProductContext db;
        public CategoryController(ProductContext context) { db = context; }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string category)
        {
            var found = await db.Products.Where(p => p.Category == category).ToListAsync();

            return View(found);
        }
    }
}
