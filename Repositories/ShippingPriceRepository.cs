using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   

    public class ShippingPriceRepository
    {
        private readonly ShippingPriceDao _shippingPriceDao;

        public ShippingPriceRepository(ShippingPriceDao shippingPriceDao)
        {
            _shippingPriceDao = shippingPriceDao;
        }

        public async Task<List<ShippingPrice>> GetAllAsync()
        {
            return await _shippingPriceDao.GetAllAsync();
        }

        public async Task<ShippingPrice> GetByIdAsync(int shippingId)
        {
            return await _shippingPriceDao.GetByIdAsync(shippingId);
        }

        public async Task AddAsync(ShippingPrice shippingPrice)
        {
            await _shippingPriceDao.AddAsync(shippingPrice);
        }

        public async Task UpdateAsync(ShippingPrice shippingPrice)
        {
            await _shippingPriceDao.UpdateAsync(shippingPrice);
        }

        public async Task DeleteAsync(int shippingId)
        {
            await _shippingPriceDao.DeleteAsync(shippingId);
        }
    }
}
