using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BazarUniversalAPI.Data;
using BazarUniversalAPI.Models;

namespace BazarUniversalAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        private readonly BazarContext _context;

        public ProductsController(BazarContext context)
        {
            _context = context;
        }

        [HttpGet("items")]
        public async Task<IActionResult> SearchItems([FromQuery] string? q)
        {
            _context.ChangeTracker.Clear();

            var query = _context.Products
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                q = q.ToLower();

                query = query.Where(p =>
                    p.Title.ToLower().Contains(q) ||
                    p.Description.ToLower().Contains(q) ||
                    p.Category.ToLower().Contains(q)
                );
            }

            var products = await query.ToListAsync();

            return Ok(products);
        }

        [HttpGet("items/{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(product);
        }

        [HttpPost("addSale")]
        public async Task<IActionResult> AddSale([FromBody] Sale sale)
        {
            if (sale == null)
                return BadRequest(new { message = "Datos de venta inválidos" });

            var product = await _context.Products.FindAsync(sale.ProductId);
            if (product == null)
                return BadRequest(new { message = "El producto no existe" });

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Venta registrada correctamente" });
        }

        [HttpGet("sales")]
        public async Task<IActionResult> GetSales()
        {
            var sales = await _context.Sales
                .Include(s => s.Product)
                .Select(s => new
                {
                    s.Id,
                    ProductTitle = s.Product != null ? s.Product.Title : "Producto eliminado",
                    ProductPrice = s.Product != null ? s.Product.Price : 0,
                    ProductBrand = s.Product != null ? s.Product.Brand : "N/A",
                    s.Date
                })
                .ToListAsync();

            return Ok(sales);
        }
    }
}
