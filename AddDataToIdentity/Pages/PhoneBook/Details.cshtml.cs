using AddDataToIdentity.Areas.Identity.Data;
using AddDataToIdentity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AddDataToIdentity.Pages.PhoneBook
{
    public class DetailsModel : PageModel
    {
        private readonly AddDataToIdentityContext _context;

        public DetailsModel(AddDataToIdentityContext context)
        {
            _context = context;
        }

        public Phone? Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
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
    }
}
