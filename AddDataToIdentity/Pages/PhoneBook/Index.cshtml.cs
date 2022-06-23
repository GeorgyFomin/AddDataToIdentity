using AddDataToIdentity.Areas.Identity.Data;
using AddDataToIdentity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AddDataToIdentity.Pages.PhoneBook
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AddDataToIdentityContext _context;

        public IndexModel(AddDataToIdentityContext context)
        {
            _context = context;
        }

        public IList<Phone>? Phone { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        //public SelectList Names { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string PhoneName { get; set; }
        public async Task OnGetAsync()
        {
            var phones = from m in _context.Phone
                         select m;
            if (!string.IsNullOrEmpty(SearchString) && !string.IsNullOrEmpty(SearchString.Trim()))
            {
                phones = phones.Where(s => s.Name.Contains(SearchString));
            }

            Phone = await phones.ToListAsync();
            //            Phone = await _context.Phone.ToListAsync();
        }
    }
}
