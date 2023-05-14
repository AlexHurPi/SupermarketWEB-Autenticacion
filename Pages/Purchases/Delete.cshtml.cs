using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Purchases
{
    public class DeleteModel : PageModel
    {
		private readonly SupermarketContext _context;

		public DeleteModel(SupermarketContext context)
		{
			_context = context;
		}

		[BindProperty]

		public Purchase Purchase { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Purchases == null)
			{
				return NotFound();
			}

			var purchase = await _context.Purchases.FirstOrDefaultAsync(m => m.Id == id);

			if (purchase == null)
			{
				return NotFound();
			}
			else
			{
				Purchase = purchase;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Purchases == null)
			{
				return NotFound();
			}
			var purchase = await _context.Purchases.FindAsync(id);

			if (purchase != null)
			{
				Purchase = purchase;
				_context.Purchases.Remove(Purchase);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
