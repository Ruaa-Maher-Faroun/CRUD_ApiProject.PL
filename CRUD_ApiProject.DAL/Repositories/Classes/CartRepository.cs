using CRUD_ApiProject.DAL.Data;
using CRUD_ApiProject.DAL.Models;
using CRUD_ApiProject.DAL.Repositories.Interfaces;


namespace CRUD_ApiProject.DAL.Repositories.Classes
{
    public class CartRepository: ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context) {
            _context = context;
        }
        public int Add(Cart cart)
        {
            _context.Carts.Add(cart);
            return _context.SaveChanges();
        }
    }
}
