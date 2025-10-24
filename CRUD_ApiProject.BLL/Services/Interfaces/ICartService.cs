using CRUD_ApiProject.DAL.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.BLL.Services.Interfaces
{
    public interface ICartService
    {
        bool AddToCart(CartRequest request, string UserId);

    }
}
