//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WorkShop.BL.Services.Interfaces;
//using WorkShop.DAL.Models;

//namespace WorkShop.BL.Services.Implements
//{
//    public class UserService : IUserService
//    {
//        private List<User> _users = new List<User>();
//        //{
//        //    new User {Id="6804d38c-a7d0-42d3-bb37-b7acb77a08d6" ,  UserName = "admin", Role = "Admin" },
//        //    new User {   UserName = "user", Role = "Patient" },
//        //    new User {   UserName = "user", Role = "Doctor" }
//        //    //new User{Role = "Admin"},
//        //    //new User{Role = "Patient"},
//        //    //new User{Role = "Doctor"}
//        //};

//        public User GetUser(string userName)
//        {
//            return _users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
//        }
//    }
//}
