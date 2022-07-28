using Algebra_Seminar_Drdic.Data;
using Algebra_Seminar_Drdic.Models;

namespace Algebra_Seminar_Drdic.Repositories
{
    public class ProductRepo 
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }
    }
}
