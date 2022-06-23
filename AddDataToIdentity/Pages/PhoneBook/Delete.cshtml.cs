using AddDataToIdentity.Areas.Identity.Data;
using AddDataToIdentity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AddDataToIdentity.Pages.PhoneBook
{
    public class DeleteModel : PageModel
    {
        private readonly AddDataToIdentityContext _context;

        public DeleteModel(AddDataToIdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Phone? Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.FirstOrDefaultAsync(m => m.ID == id);

            if (Phone == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.FindAsync(id);

            if (Phone != null)
            {
                _context.Phone.Remove(Phone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
