using Microsoft.AspNetCore.Authorization;

namespace SupermarketWEB.Models
{
	public class PayMode
	{
        [Authorize]
        public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; } 
	}
}
