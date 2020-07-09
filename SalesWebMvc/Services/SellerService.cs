using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int idSeller)
        {
            return _context.Seller.Include(t => t.Department).FirstOrDefault(t => t.Id == idSeller);
        }

        public void Remove(int idSeller)
        {
            var obj = _context.Seller.Find(idSeller);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
