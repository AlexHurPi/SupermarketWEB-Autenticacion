using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Purchases
{
    public class CreateModel : PageModel
    {
		private readonly SupermarketContext _context;

		public CreateModel(SupermarketContext context)
		{
			_context = context;
		}
		
		public List<SelectListItem> Provider { get; set; }
		public List<SelectListItem> Product1 { get; set; }
		
		//public List<Product> Product3 { get; set; }
		
		public void OnGet()
		{
			Purchase = new Purchase();

			Provider = _context.Provider
	.Where(c => !string.IsNullOrEmpty(c.Name))
	.Select(c => new SelectListItem
	{
		Value = c.Name, // Asignar el nombre en lugar del ID
		Text = c.Name
	})
	.ToList();

			Product1 = _context.Products
			.Where(p => !string.IsNullOrEmpty(p.Name))
			.Select(p => new SelectListItem
			{
				Value = p.Name, // Asignar el nombre en lugar del ID
				Text = $"{p.Name} - {p.Price}" // Mostrar el nombre y el precio del producto
			})
			.ToList();
		}

		[BindProperty]
		public Purchase Purchase { get; set; }
				
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				// Si hay errores de validación, establece la lista desplegable de categorías y vuelve a la página
				ViewData["Provider"] = new SelectList(await _context.Provider.ToListAsync(), "Name");
				ViewData["Products"] = new SelectList(await _context.Products.ToListAsync(), "Name", "Price");
				return Page();
			}

			// Recupera la categoría seleccionada
			var provider = await _context.Provider.FirstOrDefaultAsync(c => c.Name == Purchase.ProviderName);
			var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == Purchase.ProductName);
			

			if (provider == null || product == null)
			{
				// Si algún valor seleccionado no existe, establece las listas desplegables y muestra un mensaje de error
				ModelState.AddModelError("", "Invalid Provider or Product selected.");
				ViewData["Provider"] = new SelectList(await _context.Provider.ToListAsync(), "Id", "Name");
				ViewData["Products"] = new SelectList(await _context.Products.ToListAsync(), "Name");
				ViewData["Products"] = new SelectList(await _context.Products.ToListAsync(), "Price");
				return Page();
			}

			// Asigna el precio del producto seleccionado a ProductPrice
			Purchase.ProductPrice = product.Price;

			// Calcula el total de la venta
			Purchase.TotalPurchase = Purchase.ProductPrice * Purchase.Quantity;

			// Añade la nueva venta a la base de datos y guarda los cambios
			_context.Purchases.Add(Purchase);
			await _context.SaveChangesAsync();

			// Establece las listas desplegables y vuelve a la página Index
			return RedirectToPage("./Index");
		}
	}
}
