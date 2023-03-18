using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
            //Category = _db.Categories.First(c => c.Id == id);
            //Category = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Category = _db.Categories.SingleOrDefault(c => c.Id == id);
            //Category = _db.Categories.Where(c => c.Id == id).FirstOrDefault();

        }

        public async Task<IActionResult> OnPost()
        {
            if (Category != null)
            {
                _db.Categories.Remove(Category);
                await _db.SaveChangesAsync();

                TempData["success"] = "Category deleted successfully!";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}