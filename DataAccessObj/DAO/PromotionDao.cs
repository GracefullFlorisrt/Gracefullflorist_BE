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
   
    public class PromotionDao
    {
        private readonly GRACEFULLFLORISTContext _context;

        public PromotionDao(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<Promotion>> GetAllAsync()
        {
            return await _context.Promotions
                .Include(p => p.Orders) 
                .ToListAsync();
        }

        public async Task<Promotion> GetByIdAsync(string promotionId)
        {
            return await _context.Promotions
                .Include(p => p.Orders)
                .FirstOrDefaultAsync(p => p.PromotionId == promotionId);
        }

        public async Task AddAsync(Promotion promotion)
        {
            await _context.Promotions.AddAsync(promotion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Promotion promotion)
        {
            _context.Promotions.Update(promotion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string promotionId)
        {
            var promotion = await GetByIdAsync(promotionId);
            if (promotion != null)
            {
                _context.Promotions.Remove(promotion);
                await _context.SaveChangesAsync();
            }
        }
    }

}
