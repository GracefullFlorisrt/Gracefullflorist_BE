using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RefProductImgRepository
    {
        private readonly RefProductImgDAO _refProductImgDao;

        public RefProductImgRepository(RefProductImgDAO refProductImgDao)
        {
            _refProductImgDao = refProductImgDao;
        }

        public async Task<List<RefProductImg>> GetAllAsync()
        {
            return await _refProductImgDao.GetAllAsync();
        }

        public async Task<RefProductImg> GetByIdAsync(string productId, string enId)
        {
            return await _refProductImgDao.GetByIdAsync(productId, enId);
        }

        public async Task AddAsync(RefProductImg refProductImg)
        {
            await _refProductImgDao.CreateAsync(refProductImg);
        }

        public async Task UpdateAsync(RefProductImg refProductImg)
        {
            await _refProductImgDao.UpdateAsync(refProductImg);
        }

        public async Task DeleteAsync(string productId, string enId)
        {
            await _refProductImgDao.DeleteAsync(productId, enId);
        }
    }
}
