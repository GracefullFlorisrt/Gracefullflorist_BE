using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RefProductAttributeRepository
    {
        private readonly RefProductAttributeDAO _refProductAttributeDao;

        public RefProductAttributeRepository(RefProductAttributeDAO refProductAttributeDao)
        {
            _refProductAttributeDao = refProductAttributeDao;
        }

        public async Task<List<RefProductAttribute>> GetAllAsync()
        {
            return await _refProductAttributeDao.GetAllAsync();
        }

        public async Task<RefProductAttribute> GetByIdAsync(string productId, string attributeId)
        {
            return await _refProductAttributeDao.GetByIdAsync(productId, attributeId);
        }

        public async Task AddAsync(RefProductAttribute refProductAttribute)
        {
            await _refProductAttributeDao.CreateAsync(refProductAttribute);
        }

        public async Task UpdateAsync(RefProductAttribute refProductAttribute)
        {
            await _refProductAttributeDao.UpdateAsync(refProductAttribute);
        }

        public async Task DeleteAsync(string productId, string attributeId)
        {
            await _refProductAttributeDao.DeleteAsync(productId, attributeId);
        }
    }
}
