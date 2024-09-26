using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FeedbackRepository
    {
        private readonly FeedbackDAO _feedbackDAO;

        public FeedbackRepository(FeedbackDAO feedbackDAO)
        {
            _feedbackDAO = feedbackDAO;
        }

        public async Task<List<Feedback>> GetAllAsync()
        {
            return await _feedbackDAO.GetAllAsync();
        }

        public async Task<Feedback> GetByIdAsync(string id)
        {
            return await _feedbackDAO.GetByIdAsync(id);
        }

        public async Task CreateAsync(Feedback feedback)
        {
            await _feedbackDAO.CreateAsync(feedback);
        }

        public async Task UpdateAsync(Feedback feedback)
        {
            await _feedbackDAO.UpdateAsync(feedback);
        }

        public async Task DeleteAsync(string id)
        {
            await _feedbackDAO.DeleteAsync(id);
        }
    }
}
