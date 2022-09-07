using BLShop.Api.DTO;
using BLShop.Domain.IRepository;
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
            List<ProductGetDto> productsdto = new List<ProductGetDto>();
            var products = _ipublicProduct.GetAllProduct();

            foreach (var product in products)
            {
                var dto = new ProductGetDto();
                dto.Id = product.Id;
                dto.Name = product.Name;
                dto.Description = product.Description;
                dto.Price = product.Price;
                dto.Supplier = product.Supplier;
                dto.PhotoUrl = product.PhotoUrl;
                productsdto.Add(dto);
            }
            return Ok(productsdto);
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
            var productDto = new ProductGetDto();
            productDto.Id = product.Id;
            productDto.Name = product.Name;
            productDto.Description = product.Description;
            productDto.Price = product.Price;
            productDto.Supplier = product.Supplier;
            productDto.PhotoUrl = product.PhotoUrl;

            return Ok(productDto);
        }

        [HttpPost]
         public IActionResult CreatProducts([FromBody]ProductPutPostDto productDto)
        {
            if(ModelState.IsValid)
            {
                var product = new Product();
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Price = productDto.Price;
                product.Id = 3;
                product.Supplier = new Supplier();
                product.PhotoUrl = "https://twitch.tv/";

                var addProduct = _ipublicProduct.CreateProduct(product);
                if (!addProduct)
                    return BadRequest("Product wasn't created,try again!");

                return Created($"https://localhost:5001/api/Product/{product.Id}", product);
            }
            return BadRequest("Product Model is not valid");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct([FromBody] ProductPutPostDto updateProductDto, int id)
        {
            if(ModelState.IsValid)
            {
                var updateProduct = new Product();
                updateProduct.Name = updateProductDto.Name;
                updateProduct.Description = updateProductDto.Description;

                var updateResult = _ipublicProduct.UpdateProduct(updateProduct);

                if (updateResult)
                    return Ok("Product was updated successfully");

                return BadRequest("Couldn't update product.Please try again!");
            }
            return BadRequest("Product Model is not valid");
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
