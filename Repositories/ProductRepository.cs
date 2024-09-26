using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository
    {
        private readonly ProductDAO _productDAO;

        public ProductRepository(ProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productDAO.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _productDAO.GetByIdAsync(id);
        }

        public async Task CreateAsync(Product product)
        {
            await _productDAO.CreateAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productDAO.UpdateAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _productDAO.DeleteAsync(id);
        }
    }
}
