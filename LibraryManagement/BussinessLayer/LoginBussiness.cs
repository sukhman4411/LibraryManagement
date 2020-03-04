using LibraryManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.BussinessLayer
{
    public class LoginBussiness
    {
        LibraryManagementEntities db = new LibraryManagementEntities();

        public bool LoginUser(UserModel usrModel)
        {
            bool isLogin = false;
            try
            {
                var record = (from a in db.UserLogins
                              where a.UserName == usrModel.UserName && a.Password == usrModel.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isLogin = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isLogin;
        }
    }
}