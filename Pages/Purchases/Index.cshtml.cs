using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Purchases
{
    public class IndexModel : PageModel
    {
		private readonly SupermarketContext _context;

		public IndexModel(SupermarketContext context)
		{
			_context = context;
		}

		public IList<Purchase?> Purchases { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.Purchases != null)
			{
				Purchases = await _context.Purchases.ToListAsync();
			}

		}
	}
}
    

