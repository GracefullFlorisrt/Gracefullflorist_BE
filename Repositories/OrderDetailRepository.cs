using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepository
    {
        private readonly OrderDetailDAO _orderDetailDAO;

        public OrderDetailRepository(OrderDetailDAO orderDetailDAO)
        {
            _orderDetailDAO = orderDetailDAO;
        }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _orderDetailDAO.GetAllAsync();
        }

        public async Task<OrderDetail> GetByIdAsync(string orderId, string productId)
        {
            return await _orderDetailDAO.GetByIdAsync(orderId, productId);
        }

        public async Task CreateAsync(OrderDetail orderDetail)
        {
            await _orderDetailDAO.CreateAsync(orderDetail);
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            await _orderDetailDAO.UpdateAsync(orderDetail);
        }

        public async Task DeleteAsync(string orderId, string productId)
        {
            await _orderDetailDAO.DeleteAsync(orderId, productId);
        }
    }
}
