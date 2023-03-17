using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(/*Category category*/)
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The Category Name and Display Order cannot be the same.");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}