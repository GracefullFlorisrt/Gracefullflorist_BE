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
    public class RefFeedbackDAO
    {
        private readonly GRACEFULLFLORISTContext _context;

        public RefFeedbackDAO(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<RefFeedback>> GetAllAsync()
        {
            return await _context.RefFeedbacks.ToListAsync();
        }

        public async Task<RefFeedback> GetByIdAsync(string feedbackId)
        {
            return await _context.RefFeedbacks.FindAsync(feedbackId);
        }

        public async Task CreateAsync(RefFeedback refFeedback)
        {
            await _context.RefFeedbacks.AddAsync(refFeedback);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefFeedback refFeedback)
        {
            _context.RefFeedbacks.Update(refFeedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string feedbackId)
        {
            var refFeedback = await GetByIdAsync(feedbackId);
            if (refFeedback != null)
            {
                _context.RefFeedbacks.Remove(refFeedback);
                await _context.SaveChangesAsync();
            }
        }
    }

}
