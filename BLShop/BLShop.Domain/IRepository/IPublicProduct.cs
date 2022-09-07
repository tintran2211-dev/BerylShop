
using BLShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLShop.Domain.IRepository
{
    public interface IPublicProduct
    {
        List<Product> GetAllProduct();
        bool CreateProduct(Product product);
        bool UpdateProduct(Product updateProduct);
        bool DeleteProduct(int id);
    }
}
