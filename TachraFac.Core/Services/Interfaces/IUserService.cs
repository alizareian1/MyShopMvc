using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TachraFac.Core.DTOs;
using TachraFac.Datalayer.Entities.User;

namespace TachraFac.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUserNameExist(string userName);
        bool IsEmailExist(string email);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        bool ActiceAccount(string activeCode);
        User GetUserByUserName(string username);
        User GetUserByActiveCode(string activeCode);
        void UpdateUser(User user);
    }
}
