using PrsTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsTestClassLibrary.Controllers
{
    public class UsersController
    {
        private readonly PRSContext _context;

        public UsersController(PRSContext context)
        {
            this._context = context;
        }

        public IEnumerable<User> GetAll()
        {
           return _context.Users.ToList();
        }

        public User GetByPK(int id)
        {
            return _context.Users.Find(id);
        }

        public User Create(User user)
        {
           if(user is null)
            {
                throw new ArgumentNullException("user");
            }
           if(user.Id != 0)
            {
                throw new ArgumentException("Id must be zero!");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Change(User user)
        {
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var user = GetByPK(id);
            if(user is null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
