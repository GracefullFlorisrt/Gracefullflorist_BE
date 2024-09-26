using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AttributeRepository
    {
        private readonly AttributeDAO _attributeDAO;

        public AttributeRepository(AttributeDAO attributeDAO)
        {
            _attributeDAO = attributeDAO;
        }

        public async Task<List<BusinessObj.Models.Attribute>> GetAllAsync()
        {
            return await _attributeDAO.GetAllAsync();
        }

        public async Task<BusinessObj.Models.Attribute> GetByIdAsync(string id)
        {
            return await _attributeDAO.GetByIdAsync(id);
        }

        public async Task CreateAsync(BusinessObj.Models.Attribute attribute)
        {
            await _attributeDAO.CreateAsync(attribute);
        }

        public async Task UpdateAsync(BusinessObj.Models.Attribute attribute)
        {
            await _attributeDAO.UpdateAsync(attribute);
        }

        public async Task DeleteAsync(string id)
        {
            await _attributeDAO.DeleteAsync(id);
        }
    }
}
