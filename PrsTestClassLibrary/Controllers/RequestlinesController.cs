using Microsoft.EntityFrameworkCore;
using PrsTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsTestClassLibrary.Controllers
{
    public class RequestlinesController
    {
        private readonly PRSContext _context;

        public RequestlinesController(PRSContext context)
        {
            _context = context;
        }

        public IEnumerable<RequestLine> GetAll()
        {
            return _context.RequestLines.Include(x => x.Product).Include(x => x.Request).ToList();
        }

        public RequestLine GetByPk(int id)
        {
            return _context.RequestLines.Include(x => x.Product).Include(x => x.Request).SingleOrDefault(x => x.Id == id);
        }

        public RequestLine Create(RequestLine requestLine)
        {
            if (requestLine is null)
            {
                throw new ArgumentNullException("Can't leave values empty!");
            }
            if (requestLine.Id != 0)
            {
                throw new ArgumentException("The Id must be zero!");
            }
            _context.RequestLines.Add(requestLine);
            _context.SaveChanges();
            return requestLine;
        }

        public void Change(RequestLine requestLine)
        {
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var requestLine = GetByPk(id);
            if (requestLine is null)
            {
                throw new Exception("Request not found");
            }
            _context.RequestLines.Remove(requestLine);
            _context.SaveChanges();
        }




    }
}
