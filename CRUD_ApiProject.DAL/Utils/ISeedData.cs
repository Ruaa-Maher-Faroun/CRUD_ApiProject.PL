﻿using CRUD_ApiProject.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.DAL.Utils
{
    public interface ISeedData
    {
        Task DataSeedingAsync();

        Task IdentityDataSeedingAsync();
    }
}
