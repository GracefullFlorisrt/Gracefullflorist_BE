using BusinessObj.Models;
using DataAccessObj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository
    {
        private readonly GRACEFULLFLORISTContext _context;

        public ProductRepository(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<string> CreateAsync(Product product)
        {
            try
            {
                var add = new Product();
                add.ProductId = Guid.NewGuid().ToString("N").Substring(0, 10);
                add.ProductName = product.ProductName;
                add.ProdutDesription = product.ProdutDesription;
                add.ProductQuantity = product.ProductQuantity;
                add.Price = product.Price;


                add.CreateBy = product.CreateBy;
                add.CreateAt = DateTime.Now;

                await this._context.Products.AddAsync(add);
                await this._context.SaveChangesAsync();
                return "SUCCESS";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> CreateCustomAsync(Product product)
        {
            try
            {
                var add = new Product();
                add.ProductId = Guid.NewGuid().ToString("N").Substring(0, 10);
                add.ProductName = product.ProductName;
                add.ProdutDesription = product.ProdutDesription;
                add.ProductQuantity = product.ProductQuantity;
                add.Price = product.Price;


                add.CustomBy = product.CustomBy;
                add.CustomAt = DateTime.Now;

                await this._context.Products.AddAsync(add);
                await this._context.SaveChangesAsync();
                return "SUCCESS";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> UpdateAsync(Product product)
        {
            try
            {
                var update = await this._context.Products.Where(x => x.ProductId.Equals(product.ProductId))
                                  .FirstOrDefaultAsync();
                if (update != null)
                {
                    update.ProductId = product.ProductId;
                    update.ProductName = product.ProductName;
                    update.ProdutDesription = product.ProdutDesription;
                    update.ProductQuantity = product.ProductQuantity;
                    update.Price = product.Price;

                    update.UpdateBy = product.UpdateBy;
                    update.UpdateAt = DateTime.Now;

                    this._context.Products.Update(update);
                    await this._context.SaveChangesAsync();
                    return "SUCCESS";

                }
                return "FAIL";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<string> DeleteAsync(string id)
        {
            try
            {
                var delete = await this._context.Products.Where(x => x.ProductId.Equals(id))
                                 .FirstOrDefaultAsync();
                if (delete != null)
                {
                    if (delete.Status == false)
                    {
                        throw new Exception("NotFound");
                    }
                    delete.Status = false;
                    this._context.Products.Update(delete);
                    await _context.SaveChangesAsync();
                    return "SUCCESS";
                }
                return "FAIL";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
