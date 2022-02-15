using Microsoft.EntityFrameworkCore;
using PrsTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsTestClassLibrary.Controllers
{
    public class ProductsController
    {
        private readonly PRSContext _context;

        public ProductsController(PRSContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(x => x.Vendor).ToList();
        }

        public Product GetByPk(int id)
        {
            return _context.Products.Include(x => x.Vendor).SingleOrDefault(x => x.Id == id);
        }

        public Product Create(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException("Null");
            }
            if (product.Id != 0)
            {
                throw new ArgumentException("Id must be zero!");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Change(Product product)
        {
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var product = GetByPk(id);
            if (product is null)
            {
                throw new Exception("User not found");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
