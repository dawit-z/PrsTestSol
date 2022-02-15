using Microsoft.EntityFrameworkCore;
using PrsTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsTestClassLibrary.Controllers
{
    public class RequestsController
    {
        private readonly PRSContext _context;

        public RequestsController(PRSContext context)
        {
            _context = context;
        }

        public IEnumerable<Request> GetAll()
        {
            return _context.Requests.Include(x => x.User).ToList();
        }

        public Request GetByPk(int id)
        {
            return _context.Requests.Include(x => x.User).SingleOrDefault(x => x.Id == id);
        }

        public void Change(Request request)
        {
            _context.SaveChanges();
        }

        public Request Create(Request request)
        {
            if (request is null)
            {
                throw new ArgumentNullException("You cannot leave values empty!");
            }
            if (request.Id != 0)
            {
                throw new ArgumentException("The Id must be zero!");
            }
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request;
        }

        public void Remove(int id)
        {
            var request = GetByPk(id);
            if (request is null)
            {
                throw new Exception("Request not found");
            }
            _context.Requests.Remove(request);
            _context.SaveChanges();
        }
    }
}
