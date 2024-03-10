using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingalPageCrud.Data;
using SingalPageCrud.Models;
using SingalPageCrud.Repository;

namespace SingalPageCrud.Controllers
{   
    public class ProductController : Controller
    {
        /*   public readonly ProductRepository _repository;

           public ProductController(ProductRepository repository)
           {
               _repository = repository;
           }*/



        /*  [HttpPost]
          public IActionResult AddProduct (Product product)
          {

          if(_repository.isProductAlreadyExist(product.Name))
          {
              return BadRequest("Product Already Exist");
          }
              _repository.Add(product);
              return Ok(product);
          } */

        public readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product productModel)
        {
            var product = new Product
            {
                Name = productModel.Name,
                Description = productModel.Description,
                color = productModel.color,
                price = productModel.price
            };
            await  _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var produts = await _context.Products.ToListAsync();
            return View(produts);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return View (product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product productModel)
        {
            var product = await _context.Products.FindAsync(productModel.Id);
            if(product == null)
            {
                return View("Error");
            }
            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.color = productModel.color;
            product.price = productModel.price;

            await _context.SaveChangesAsync();
            return RedirectToAction("GetProducts","Product");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product productModel)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(e=>e.Id == productModel.Id);
            if (product != null)
            {
                 _context.Products.Remove(productModel);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetProducts", "Product");
        }
    }
}
