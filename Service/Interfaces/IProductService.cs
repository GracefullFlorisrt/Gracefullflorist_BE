using BusinessObj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProduct();
        public Task<Product> GetProductByID(string id);
        public Task<string> AddProduct(Product product);
        public Task<string> UpdateProduct(Product product);
        public Task<string> DeleteProduct(string id);
    }
}
