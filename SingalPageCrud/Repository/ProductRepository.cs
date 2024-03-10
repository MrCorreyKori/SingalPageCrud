using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SingalPageCrud.Data;
using SingalPageCrud.Models;
using System.Net;

namespace SingalPageCrud.Repository
{
    public class ProductRepository
    {
        public readonly ApplicationDbContext _context;

        public ProductRepository (ApplicationDbContext context)
        {
             _context= context;
        }

        public Boolean isProductAlreadyExist(string Name)
        {
            return _context.Products.Any(p => p.Name == Name);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }


    }
}
