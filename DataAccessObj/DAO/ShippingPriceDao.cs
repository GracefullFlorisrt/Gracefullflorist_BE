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
    public class ShippingPriceDao
    {
        private readonly GRACEFULLFLORISTContext _context;

        public ShippingPriceDao(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<ShippingPrice>> GetAllAsync()
        {
            return await _context.ShippingPrices
                .Include(sp => sp.Orders)
                .ToListAsync();
        }

        public async Task<ShippingPrice> GetByIdAsync(int shippingId)
        {
            return await _context.ShippingPrices
                .Include(sp => sp.Orders)
                .FirstOrDefaultAsync(sp => sp.ShippingId == shippingId);
        }

        public async Task AddAsync(ShippingPrice shippingPrice)
        {
            await _context.ShippingPrices.AddAsync(shippingPrice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ShippingPrice shippingPrice)
        {
            _context.ShippingPrices.Update(shippingPrice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int shippingId)
        {
            var shippingPrice = await GetByIdAsync(shippingId);
            if (shippingPrice != null)
            {
                _context.ShippingPrices.Remove(shippingPrice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
