using System;
using Model;
using DAL;
using BLL.Interfaces;
using DAL.Interfaces;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public partial class StaffBusiness : IStaffBusiness
    {
        private IStaffRepository _res;
        private string Secret;
        public StaffBusiness(IStaffRepository staffRepository, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = staffRepository;
        }
        public StaffModel Authenticate(string username, string password)
        {
            var user = _res.GetTaiKhoan(username, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.userName.ToString())
                    //new Claim(ClaimTypes.Role, user.role)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user;

        }
        public StaffModel GetStaffbyID(int id)
        {
            return _res.GetStaffbyID(id);
        }
        public List<StaffModel> GetStaff()
        {
            return _res.GetStaff();
        }
        public bool Create(StaffModel model)
        {
            return _res.Create(model);
        }
        public bool Update(StaffModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public List<StaffModel> Search(int pageIndex, int pageSize, out long total, string staffName)
        {
            return _res.Search(pageIndex, pageSize, out total, staffName);
        }
    }
}
