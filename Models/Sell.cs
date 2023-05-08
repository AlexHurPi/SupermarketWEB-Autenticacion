using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
	public class Sell
	{		
		public int Id { get; set; }
		public string? Date { get; set; }
		public string? CustomerId { get; set; }
		public string? ProductName { get; set; }
		public int? Quantity { get; set; }
		[Column(TypeName = "decimal(6,2)")]
		public decimal? ProductPrice { get; set; }
		public decimal? TotalSale { get; set; }
		public string? PayModeName { get; set; }
		public string? Observation { get; set; }
	}
}
