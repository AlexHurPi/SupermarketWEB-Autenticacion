﻿using Microsoft.AspNetCore.Authorization;

namespace SupermarketWEB.Models
{
    [Authorize]
    public class Category
    {
        public int Id { get; set; } //sera la llave primaria
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; } = default!;//Propiedad de navegacion
    }
}