using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore_WithBugs.Models;

namespace MVCCore_WithBugs.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<ActionResult> Index()
        {
            List<Product> allProducts = await ProductDb.GetAllProducts(_context);
            return View(allProducts);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await ProductDb.AddProduct(_context, product);
                return RedirectToAction("Index");
            }

            //return model back to view with errors
            return View();
        }
    }
}
