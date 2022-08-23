using BLShop.Application.IRepository;
using BLShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLShop.Application.Repository
{
    public class PublicProduct : IPublicProduct
    {
        private List<Product> _products = new List<Product>();

        public bool CreateProduct(Product product)
        {
            _products.Add(product);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var deleteproduct = _products.FirstOrDefault(p => p.Id == id);
            if (deleteproduct == null)
                return false;
            _products.Remove(deleteproduct);
            return true;
        }

        public List<Product> GetAllProduct()
        {
            var product = new Product
            {
                Id = 1,
                Name = "IPhone 14 ProMax",
                Description = "Apple",
                Price = 35.5,
            };
            _products.Add(product);

            var product2 = new Product
            {
                Id = 2,
                Name = "IPhone 13 ProMax",
                Description = "Apple",
                Price = 27.5,
            };
            _products.Add(product2);

            var product3 = new Product
            {
                Id = 3,
                Name = "IPhone 12 ProMax",
                Description = "Apple",
                Price = 21.5,
            };
            _products.Add(product3);

            return _products;
        }

        public bool UpdateProduct(Product updateProduct)
        {
            var udproduct = _products.FirstOrDefault(p => p.Id == updateProduct.Id);

            if(udproduct != null)
            {
                _products.Remove(udproduct);
                _products.Add(updateProduct);
                return true;
            }
            return false;
        }
    }
}
