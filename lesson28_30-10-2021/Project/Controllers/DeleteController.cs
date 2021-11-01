using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class DeleteController : Controller {  
        public readonly ProductContext db;
        public DeleteController(ProductContext context) { db = context; }

        public async Task<IActionResult> IndexAsync(int id = 0)
        {
            var obj = await db.Products.FindAsync(id);

            if (obj == null)
                return NotFound();

            db.Products.Remove(obj);
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Print");
        }

    }

}
