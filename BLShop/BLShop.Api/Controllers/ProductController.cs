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
        public ProductController()
        {

        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var product = new Product();
            product.Id = 1;
            product.Name = "IPhone13 XSMax";
            product.Price = 30.5f;

            return Ok(product);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = new Product();
            product.Id = id;
            product.Name = "IPhone13 XSMax";
            product.Price = 30.5f;

            return Ok(product);
        }
    }
}
