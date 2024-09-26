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
    public class RefProductImgDAO
    {
        private readonly GRACEFULLFLORISTContext _context;

        public RefProductImgDAO(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<RefProductImg>> GetAllAsync()
        {
            return await _context.RefProductImgs
                .Include(r => r.En) 
                .Include(r => r.Product)
                .ToListAsync();
        }

        public async Task<RefProductImg> GetByIdAsync(string productId, string enId)
        {
            return await _context.RefProductImgs
                .Include(r => r.En) 
                .Include(r => r.Product) 
                .FirstOrDefaultAsync(r => r.ProductId == productId && r.EnId == enId);
        }

        public async Task CreateAsync(RefProductImg refProductImg)
        {
            await _context.RefProductImgs.AddAsync(refProductImg);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefProductImg refProductImg)
        {
            _context.RefProductImgs.Update(refProductImg);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string productId, string enId)
        {
            var refProductImg = await GetByIdAsync(productId, enId);
            if (refProductImg != null)
            {
                _context.RefProductImgs.Remove(refProductImg);
                await _context.SaveChangesAsync();
            }
        }
    }
}
