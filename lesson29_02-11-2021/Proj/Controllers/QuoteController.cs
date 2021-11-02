using Microsoft.AspNetCore.Mvc;

namespace Proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class QuoteController : ControllerBase
    {
        private readonly AppContext db;
        public QuoteController(AppContext _db) { db = _db; }

        [HttpGet]
        [Route("[controller]")]
        public int Get()
        {
            return 1;
        }
    }
}
