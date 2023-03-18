using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Category Name and Display Order cannot be the same.");
                TempData["error"] = "An error has occurred!";
            }
            if (!ModelState.IsValid)
            {
                TempData["error"] = "An error has occurred!";
                return Page();
            }

            _db.Categories.Update(Category);
            await _db.SaveChangesAsync();

            TempData["success"] = "Category updated successfully!";

            return RedirectToPage("Index");
        }
    }
}