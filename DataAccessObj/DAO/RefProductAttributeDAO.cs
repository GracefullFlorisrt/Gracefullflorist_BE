using BusinessObj.Models;
using DataAccessObj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObj.DAO
{
    public class RefProductAttributeDAO
    {
        private readonly GRACEFULLFLORISTContext _context;

        public RefProductAttributeDAO(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<RefProductAttribute>> GetAllAsync()
        {
            return await _context.RefProductAttributes.ToListAsync();
        }

        public async Task<RefProductAttribute> GetByIdAsync(string productId, string attributeId)
        {
            return await _context.RefProductAttributes
                .FirstOrDefaultAsync(r => r.ProductId == productId && r.AttributeId == attributeId);
        }

        public async Task CreateAsync(RefProductAttribute refProductAttribute)
        {
            await _context.RefProductAttributes.AddAsync(refProductAttribute);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefProductAttribute refProductAttribute)
        {
            _context.RefProductAttributes.Update(refProductAttribute);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string productId, string attributeId)
        {
            var refProductAttribute = await GetByIdAsync(productId, attributeId);
            if (refProductAttribute != null)
            {
                _context.RefProductAttributes.Remove(refProductAttribute);
                await _context.SaveChangesAsync();
            }
        }
    }

}
