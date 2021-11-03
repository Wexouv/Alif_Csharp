using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj.Models;

namespace Proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class QuoteController : ControllerBase
    {
        private readonly AppContext db; public QuoteController(AppContext _db) { db = _db; }
        // GET Quote/get/all
        // Returns all the quotes in the database
        [HttpGet("get/all")]
        public async Task<ActionResult<List<Quote>>> GetAllAsync()
        {
            var res = await db.Quotes.ToListAsync();
            // 200 OK
            return Ok(res);
        }

        // GET Quote/get/id
        // Returns specific Quote with the provided index
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Quote>> GetAsync(int id)
        {
            var res = await db.Quotes.FindAsync(id);
            // Return 404 if not found
            if (res == null) return NotFound();
            // 200 OK
            return Ok(res);
        }

        // POST Quote/add
        // NOTE: gets the quote from the body
        [HttpPost("add")]
        public async Task<ActionResult<Quote>> PostAsync([FromBody] Quote quote)
        {
            await db.Quotes.AddAsync(quote);
            await db.SaveChangesAsync();
            return Ok(quote);
        }

        // PUT Quote/update
        // NOTE: Gets the quote from the body
        [HttpPut("update")]
        public async Task<ActionResult<Quote>> UpdateAsync([FromBody] Quote quote)
        {
            if (quote == null) return BadRequest();
            if (!db.Quotes.Any(x => x.Id == quote.Id)) return NotFound();

            db.Quotes.Update(quote);
            await db.SaveChangesAsync();
            return Ok(quote);
        }

        // DELETE Quote/delte/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Quote>> Delete(int id)
        {
            var res = await db.Quotes.FindAsync(id);
            // Return 404 if not found
            if (res == null) return NotFound();

            db.Quotes.Remove(res);
            await db.SaveChangesAsync();
            // 200 OK 
            return Ok(res);
        }

        // DELETE Quote/clean
        [HttpDelete("clean")]
        public async Task<ActionResult<List<Quote>>> Clean()
        {
            var quotes = await db.Quotes.ToListAsync();
            var dateNow = DateTime.Now;

            var deletedQuotes = new List<Quote>();
            foreach (var quote in quotes)
            {
                var ageOfTheQuote = Math.Abs((quote.InsertDate - dateNow).TotalDays);

                if (ageOfTheQuote > 30) {
                    deletedQuotes.Add(quote); // Add to the result
                    db.Quotes.Remove(quote); // remove from the database
                }
            }
            await db.SaveChangesAsync();
            return Ok(deletedQuotes);
        }
    }
}
