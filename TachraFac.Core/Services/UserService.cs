using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TachraFac.Core.DTOs;
using TachraFac.Core.Genrator;
using TachraFac.Core.Security;
using TachraFac.Core.Services.Interfaces;
using TachraFac.Datalayer.Context;
using TachraFac.Datalayer.Entities.User;

namespace TachraFac.Core.Services
{
    public class UserService : IUserService
    {
        private TachraContext _context;
        public UserService(TachraContext context)
        {
            _context = context;
        }

        public bool ActiceAccount(string activeCode)
        {
            var user = _context.tblUser.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
            {
                return false;
            }
            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUnicCode();
            _context.SaveChanges();
            return true;
        }

        public int AddUser(User user)
        {
            _context.tblUser.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.tblUser.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public User GetUserByUserName(string username)
        {
            return _context.tblUser.SingleOrDefault(u => u.UserName == username);
        }

        public bool IsEmailExist(string email)
        {
            return _context.tblUser.Any(u => u.Email == email);
        }

        public bool IsUserNameExist(string userName)
        {
            return _context.tblUser.Any(u => u.UserName == userName);
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string username = login.UserName;
            return _context.tblUser.SingleOrDefault(u => u.UserName == username && u.Password == hashPassword);

        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
