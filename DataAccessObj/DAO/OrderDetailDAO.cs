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
    public class OrderDetailDAO
    {
        private readonly GRACEFULLFLORISTContext _context;

        public OrderDetailDAO(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetByIdAsync(string orderId, string productId)
        {
            return await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }

        public async Task CreateAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string orderId, string productId)
        {
            var orderDetail = await GetByIdAsync(orderId, productId);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }

}
