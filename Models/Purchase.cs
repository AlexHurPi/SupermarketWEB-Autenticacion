using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
	public class Purchase
	{
		public int Id { get; set; }
		public string ProviderName  { get; set; }
		public string ProductName { get; set; }
		[Column(TypeName = "decimal(15,2)")]
		public decimal ProductPrice { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPurchase { get; set; }
		public string Observation { get; set; }
	}
}
