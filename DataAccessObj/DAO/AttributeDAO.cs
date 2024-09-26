using DataAccessObj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObj.DAO
{
    public class AttributeDAO
    {
        private readonly GRACEFULLFLORISTContext _context;

        public AttributeDAO(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<BusinessObj.Models.Attribute>> GetAllAsync()
        {
            return await _context.Attributes.ToListAsync();
        }

        public async Task<BusinessObj.Models.Attribute> GetByIdAsync(string id)
        {
            return await _context.Attributes.FindAsync(id);
        }

        public async Task CreateAsync(BusinessObj.Models.Attribute attribute)
        {
            await _context.Attributes.AddAsync(attribute);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BusinessObj.Models.Attribute attribute)
        {
            _context.Attributes.Update(attribute);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var attribute = await GetByIdAsync(id);
            if (attribute != null)
            {
                _context.Attributes.Remove(attribute);
                await _context.SaveChangesAsync();
            }
        }
    }

}
