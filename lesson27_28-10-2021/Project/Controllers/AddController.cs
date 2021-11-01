using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class AddController : Controller
    {
        public readonly ProductContext db;

        public AddController(ProductContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Product product, CancellationToken token)
        {
            db.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Print");
        }
    }
}
