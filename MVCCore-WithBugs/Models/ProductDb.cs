using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore_WithBugs.Models
{
    public static class ProductDb
    {
        public static async Task<List<Product>> GetAllProducts(ProductContext _context)
        {
            List<Product> listOfProducts = await _context.Product.
                                                OrderBy(p => p.ProductName)
                                                .ToListAsync();
            return listOfProducts;
        }

        public static async Task<Product> AddProduct(ProductContext context, Product prod)
        {
            await context.Product.AddAsync(prod);
            await context.SaveChangesAsync();
            return prod;
        }
    }
}
