﻿using CRUD_ApiProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.DAL.Repositories.Interfaces
{
    public interface ICartRepository
    {
        int Add(Cart cart);
        List<Cart> GetUserCart(string UserId);
    }
}
