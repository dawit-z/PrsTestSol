using PrsTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsTestClassLibrary.Controllers
{
    public class VendorsController
    {
        private readonly PRSContext _db;

        public VendorsController(PRSContext db)
        {
            this._db = db;   
        }

        public IEnumerable<Vendor> GetVendors()
        {
            return _db.Vendors.ToList();
        }

        public Vendor GetByPK(int id)
        {
            return _db.Vendors.Find(id);
        }

        public Vendor Create(Vendor vendor)
        {
            _db.Vendors.Add(vendor);
            _db.SaveChanges();
            return vendor;
        }

        public void Update(Vendor vendor)
        {
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var vendor = _db.Vendors.Find(id);
            if(vendor is not null)
            {
                _db.Vendors.Remove(vendor);
                _db.SaveChanges();
            }
            
        }

    }
}
