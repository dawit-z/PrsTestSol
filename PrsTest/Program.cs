using PrsTestClassLibrary.Controllers;
using PrsTestClassLibrary.Models;
using System;
using System.Collections.Generic;

namespace PrsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PRSContext();

            var userCtrl = new UsersController(context);

            var newUser = new User()
            {
                Id = 0,
                Username = "zz",
                Password = "zz",
                Firstname = "User",
                Lastname = "ZZ",
                Phone = "221",
                Email = "zz@user.com",
                IsAdmin = false,
                IsReviewer = false
            };

            userCtrl.Create(newUser);


            var user3 = userCtrl.GetByPK(3);

            if (user3 is null)
            {
                Console.WriteLine("User not Found!");
            }
            else
            {
                Console.WriteLine($"User3: {user3.Firstname} {user3.Lastname}");
            }


            user3.Lastname = "User3";
            userCtrl.Change(user3);

            var users = userCtrl.GetAll();

            foreach(var user in users)
            {
                Console.WriteLine($"{user.Firstname} {user.Lastname}");
            }
            
        }
    }
}
