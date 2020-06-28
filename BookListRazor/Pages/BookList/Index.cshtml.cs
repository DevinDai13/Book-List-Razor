using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;  // read only since it's not a DB that we need to edit

        public IndexModel(ApplicationDBContext db) // this ApplicationDBContext db we are getting using dependency injection 
        {
            // this way you can extract the db context inside the dependecy injection container and inject it onto this page
            _db = db; 
        }

        public IEnumerable<Book> Books { get; set; }

        // get handler
        public async Task OnGet()
        {
            //going to the DB to get all the books as a list and storing that in the Books variable
            // async is a  C# thing that lets you run multitask while it is awaited
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            else
            {
                _db.Book.Remove(book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

        }
    }
}