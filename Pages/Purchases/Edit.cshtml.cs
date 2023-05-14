using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Purchases
{
    public class EditModel : PageModel
    {
		private readonly SupermarketContext _context;

		public EditModel(SupermarketContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Purchase Purchase { get; set; }
		public SelectList Provider { get; set; }
		public SelectList Product1 { get; set; }
		
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Purchase = await _context.Purchases.FirstOrDefaultAsync(m => m.Id == id);

			if (Purchase == null)
			{
				return NotFound();
			}

			Provider = new SelectList(_context.Provider
				.Where(c => !string.IsNullOrEmpty(c.Name))
				.Select(c => new SelectListItem
				{
					Value = c.Name,
					Text = c.Name
				}), "Value", "Text", Purchase.ProviderName);

			Product1 = new SelectList(_context.Products
				.Where(p => !string.IsNullOrEmpty(p.Name))
				.Select(p => new SelectListItem
				{
					Value = p.Name,
					Text = $"{p.Name} - {p.Price}"
				}), "Value", "Text", Purchase.ProductName);
			
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				Provider = new SelectList(_context.Provider
					.Where(c => !string.IsNullOrEmpty(c.Name))
					.Select(c => new SelectListItem
					{
						Value = c.Name,
						Text = c.Name
					}), "Value", "Text");

				Product1 = new SelectList(_context.Products
					.Where(p => !string.IsNullOrEmpty(p.Name))
					.Select(p => new SelectListItem
					{
						Value = p.Name,
						Text = $"{p.Name} - {p.Price}"
					}), "Value", "Text");

				return Page();
			}

			_context.Attach(Purchase).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SellExists(Purchase.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool SellExists(int id)
		{
			return _context.Purchases.Any(e => e.Id == id);
		}
	}
}
