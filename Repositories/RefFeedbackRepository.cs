using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RefFeedbackRepository
    {
        private readonly RefFeedbackDAO _refFeedbackDao;

        public RefFeedbackRepository(RefFeedbackDAO refFeedbackDao)
        {
            _refFeedbackDao = refFeedbackDao;
        }

        public async Task<List<RefFeedback>> GetAllAsync()
        {
            return await _refFeedbackDao.GetAllAsync();
        }

        public async Task<RefFeedback> GetByIdAsync(string feedbackId)
        {
            return await _refFeedbackDao.GetByIdAsync(feedbackId);
        }

        public async Task AddAsync(RefFeedback refFeedback)
        {
            await _refFeedbackDao.CreateAsync(refFeedback);
        }

        public async Task UpdateAsync(RefFeedback refFeedback)
        {
            await _refFeedbackDao.UpdateAsync(refFeedback);
        }

        public async Task DeleteAsync(string feedbackId)
        {
            await _refFeedbackDao.DeleteAsync(feedbackId);
        }
    }
}
