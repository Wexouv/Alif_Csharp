using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class EditController : Controller {  
        public readonly ProductContext db;
        public EditController(ProductContext context) { db = context; }

        [HttpGet]
        public async Task<IActionResult> Index(int id = 0)
        {
            var obj = await db.Products.FindAsync(id);
            
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Product productModel)
        {
            var prod = await db.Products.FindAsync(productModel.Id);

            if (prod == null)
                return NotFound();

            prod.Name = productModel.Name;
            prod.Cost = productModel.Cost;
            prod.Category = productModel.Category;

            await db.SaveChangesAsync();
            
            return RedirectToAction("Index", "Print");
        }
    }
}

