using RegisterAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLogin.Services
{
    public class SercurityService
    {
        UsersDAO usersDAO = new UsersDAO();

        public SercurityService()
        {
        }

        /**
         * Return True is user is found in the list
         */
        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }
}
