using Lab2_EstebanPacheco.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_EstebanPacheco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        static List<string> list = new List<string> { "Laptop", "Mouse", "Phone" };

        [HttpGet("ListAllProducts")]
        public IActionResult ListAllProducts()
        {
            return Ok(list);
        }

        [HttpGet("ListSelected/{id}")]
        public IActionResult ListSelected(int id)
        {
            if (id < 0 || id >= list.Count)
            {
                return NotFound("Product not found");
            }

            string selectedProduct = list[id];
            list.RemoveAt(id);
            return Ok($"Selected product: {selectedProduct}");
        }
    
        [HttpPost("Add")]
        public IActionResult Add([FromBody] ProductoDto product)
        {
            list.Add(product.Name);
            return Ok(new { mensaje = "Producto agregado", product });
        }
    }
}