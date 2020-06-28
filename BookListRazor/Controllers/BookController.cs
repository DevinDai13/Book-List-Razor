using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BookListRazor.Controllers
{

    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDBContext _db;

        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }

        // http get request to get all the book list using API for the datatable plugin
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (book == null)
            {
                return Json(new { success = false, Message = "Error while deleting" });
            }
            else
            {
                _db.Book.Remove(book);
                await _db.SaveChangesAsync();
                return Json(new { success = true, Message = "Deleted successfully" });
            }
        }
    }
        
}
