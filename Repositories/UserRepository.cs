using BusinessObj.Models;
using DataAccessObj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly GRACEFULLFLORISTContext _context;
        public UserRepository(IConfiguration configuration, GRACEFULLFLORISTContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<List<User>> GetAll()
        {
            try
            {
                var list = await this._context.Users.Include(x => x.Role).ToListAsync();
                if (list != null)
                {
                    return list;
                }
                throw new Exception("There are no USER");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task<User> GetUserInformation(string user)
        {
            try
            {
                var search = await this._context.Users.Where(x => x.UserId.Equals(user))
                                                     .FirstOrDefaultAsync();
                return search;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<User>> SearchByName(string FullName)
        {
            try
            {
                var list = await this._context.Users.Where(x => x.Fullname.Contains(FullName)).ToListAsync();
                if (list != null) return list;
                throw new Exception("Not Found");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<User> Update(User user)
        {
            try
            {
                var r = await this._context.Users.Where(x => user.UserId.Equals(x.UserId))
                                                .FirstOrDefaultAsync();
                var userS = await this._context.Users.Where(x => x.Equals(user.Username)).FirstOrDefaultAsync();
                if (userS != null)
                    throw new Exception("Duplicate UserName please try another one.");
                if (user != null && r != null)
                {
                    r.UserName = user.Username ?? r.UserName;
                    r.FullName = user.fullName ?? r.FullName;
                    r.Address = user.address ?? r.Address;
                    r.Email = user.Email ?? r.Email;
                    r.Gender = user.gender ?? r.Gender;
                    r.PhoneNumber = user.Phone ?? r.PhoneNumber;
                    r.RoleId = user.RoleID ?? r.RoleId;
                    r.ImageUrl = user.imgURL ?? r.ImageUrl;
                    r.DateOfBird = user.dateOfBird ?? r.DateOfBird;
                    this._context.User.Update(r);
                    await this._context.SaveChangesAsync();
                    return r;
                }
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> Remove(RemoveDTO userID)
        {
            if (userID != null)
            {
                var obj = await this._context.User.Where(x => x.UserId.Equals(userID.UserID)).FirstOrDefaultAsync();
                this._context.User.Remove(obj);
                await this._context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        private string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, user.Role.RoleId.ToString()),
                new Claim("userid", user.UserId),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }

        public async Task<User> Registration(RegisterDTO request)
        {
            try
            {
                var r = new User();
                if (request != null)
                {
                    foreach (var x in this._context.User)
                    {
                        if (request.Username.Equals(x.UserName))
                        {
                            throw new Exception("Duplicate UserName");
                        }
                    }
                    r.UserId = "US" + Guid.NewGuid().ToString().Substring(0, 7);
                    r.UserName = request.Username;
                    r.PassWord = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    r.Email = request.Email;
                    r.RoleId = "4";
                    r.Status = true;
                    await this._context.User.AddAsync(r);
                    await this._context.SaveChangesAsync();
                    return r;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<string> Login(LoginDTO request)
        {
            try
            {
                var user = await this._context.User.Where(x => x.UserName.Equals(request.UserName))
                                                   .Include(y => y.Role)
                                                   .FirstOrDefaultAsync();
                if (user == null)
                    throw new Exception("USER IS NOT FOUND");
                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PassWord))
                    throw new Exception("INVALID PASSWORD");
                if (!user.Status)
                    throw new Exception("ACCOUNT WAS BANNED OR DELETED");
                var token = CreateToken(user);
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<User> CreateUser(CreateUser user)
        {
            try
            {
                var userS = await this._context.User.Where(x => x.Equals(user.Username)).FirstOrDefaultAsync();
                if (userS != null)
                    throw new Exception("Duplicate Username Please try another onr.");
                var create = new User();
                create.UserId = "US" + Guid.NewGuid().ToString().Substring(0, 7);
                create.RoleId = user.RoleId;
                create.UserName = user.Username;
                create.PassWord = BCrypt.Net.BCrypt.HashPassword(user.Password);
                create.FullName = user.Fullname;
                create.Gender = user.Gender;
                create.DateOfBird = user.DateOfBirth;
                create.Address = user.Address;
                create.PhoneNumber = user.Phonenumber;
                create.Status = true;
                await this._context.AddAsync(create);
                await this._context.SaveChangesAsync();
                return create;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Int32> countCustomers()
        {
            try
            {
                var list = await this._context.User.Where(x => x.RoleId.Equals("4")).ToListAsync();
                return list.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
