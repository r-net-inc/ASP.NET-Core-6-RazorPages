using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public Category Category { get; set; }

        public void OnGet()
        {
        }
    }
}
