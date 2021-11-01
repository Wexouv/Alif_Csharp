using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class PrintController : Controller
    {

        public readonly ProductContext db;

        public PrintController(ProductContext context) { db = context; }

        public async Task<IActionResult> IndexAsync()
        {
            var allData = await GetAllDatabaseAsync();
            return View(allData);
        }

        private async Task<List<Product>> GetAllDatabaseAsync()
        {
            return await db.Products.ToListAsync();
        }
    }
}
