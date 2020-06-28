using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


// This page will be used for both creating and editing page
namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDBContext _db;  // not readonly since it's a DB that we need to edit and repost back

        public UpsertModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id) // ? shows that Id could be null
        {
            Book = new Book();
            if (id == null)
            {
                // creating the page
                return Page();
            }
            else
            {
                // for the editing page
                var book = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Page();
                }
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    _db.Book.Add(Book);
                }
                else
                {
                    _db.Book.Update(Book); //this only used if you want to update every property of "Book"
                }
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }

    }
}