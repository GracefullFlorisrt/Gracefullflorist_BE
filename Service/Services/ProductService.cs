using BusinessObj.Models;
using Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _repo;

        public ProductService(ProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> AddProduct(Product product)
        {
            return await _repo.CreateAsync(product);
        }

        public async Task<string> DeleteProduct(string id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAllProduct()
        {
            try
            {
                return await _repo.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching all attributes: {ex.Message}", ex);
            }
        }

        public async Task<Product> GetProductByID(string id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<string> UpdateProduct(Product product)
        {
            return await _repo.UpdateAsync(product);
        }
    }
}
