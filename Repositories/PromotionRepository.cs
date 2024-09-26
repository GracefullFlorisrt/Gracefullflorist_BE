using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   
    public class PromotionRepository
    {
        private readonly PromotionDao _promotionDao;

        public PromotionRepository(PromotionDao promotionDao)
        {
            _promotionDao = promotionDao;
        }

        public async Task<List<Promotion>> GetAllAsync()
        {
            return await _promotionDao.GetAllAsync();
        }

        public async Task<Promotion> GetByIdAsync(string promotionId)
        {
            return await _promotionDao.GetByIdAsync(promotionId);
        }

        public async Task AddAsync(Promotion promotion)
        {
            await _promotionDao.AddAsync(promotion);
        }

        public async Task UpdateAsync(Promotion promotion)
        {
            await _promotionDao.UpdateAsync(promotion);
        }

        public async Task DeleteAsync(string promotionId)
        {
            await _promotionDao.DeleteAsync(promotionId);
        }
    }
}
