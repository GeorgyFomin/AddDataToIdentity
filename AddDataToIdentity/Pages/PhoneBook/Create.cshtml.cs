using AddDataToIdentity.Areas.Identity.Data;
using AddDataToIdentity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddDataToIdentity.Pages.PhoneBook
{
    public class CreateModel : PageModel
    {
        private readonly AddDataToIdentityContext _context;

        public CreateModel(AddDataToIdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Phone? Phone { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_context == null || Phone == null)
            {
                return NotFound();
            }
            _context.Phone.Add(Phone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
