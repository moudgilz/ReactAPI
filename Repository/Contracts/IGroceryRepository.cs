﻿using ReactApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApi.Repository.Contracts
{
    /// <summary>
    /// Tag repository
    /// </summary>
    public interface IGroceryRepository
    {
        /// <summary>
        /// To get the Grocery list
        /// </summary>
        /// <returns></returns>
        Task<List<Grocery>> GetGroceryList();       
       
    }
}
