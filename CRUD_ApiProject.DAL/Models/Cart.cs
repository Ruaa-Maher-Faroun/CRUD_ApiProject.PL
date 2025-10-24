﻿using Microsoft.EntityFrameworkCore;

namespace CRUD_ApiProject.DAL.Models
{
    [PrimaryKey(nameof(ProductId), nameof(UserId))]
    public class Cart
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId {  get; set; }
        public ApplicationUser User { get; set; }
        public int Count { get; set; }

    }
}
