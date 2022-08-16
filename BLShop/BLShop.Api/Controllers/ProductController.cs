using BLShop.Application.IRepository;
using BLShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProduct _ipublicProduct;
        public ProductController(IPublicProduct ipublicProduct)
        {
            _ipublicProduct = ipublicProduct;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_ipublicProduct.GetAllProduct());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _ipublicProduct.GetAllProduct().FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
         public IActionResult CreatProducts([FromBody]Product product)
        {
            var addProduct = _ipublicProduct.CreateProduct(product);
            if (!addProduct)
                return BadRequest("Product wasn't created,try again!");

            return Created("https://localhost:5001/api/Product/{product.Id}", product);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct([FromBody] Product updateProduct, int id)
        {
            var updateResult = _ipublicProduct.UpdateProduct(id, updateProduct);

            if (updateResult)
                return Ok("Product was updated successfully");
           
            return BadRequest("Couldn't update product.Please try again!");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleteproduct = _ipublicProduct.DeleteProduct(id);

            if (deleteproduct)
                return Ok("Product was deleted!");

            return BadRequest("Can't delete product.Try again!");
        }
    }
}
