using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.Models;
using CRUD_ApiProject.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.BLL.Services.Classes
{
    public class CartService:ICartService
    {
        private readonly ICartRepository _cartRepo;

        public CartService(ICartRepository cartRepository) {
            _cartRepo = cartRepository;
        }
        public bool AddToCart(CartRequest request, string UserId)
        {
            var newItem = new Cart
            {
                ProductId = request.ProductId,
                UserId = UserId,
                Count = 1
            };

            return _cartRepo.Add(newItem) > 0;
        }

    }
}
