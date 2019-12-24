using Microsoft.EntityFrameworkCore;
using ReactApi.Enums;
using ReactApi.Models;
using ReactApi.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApi.Repository.Services
{
    /// <summary>   
    /// Tag repository
    /// </summary>
    public class GroceryRepository : IGroceryRepository
    {
        private readonly ReactAppContext _context;

        /// <summary>
        /// Ctor
        /// context injection\creation
        /// </summary>
        /// <param name="context"></param>
        public GroceryRepository(ReactAppContext context)
        {
            _context = context;
        }


        /// <summary>
        /// To get the tags list
        /// </summary>
        /// <returns></returns>
        public async Task<List<Grocery>> GetGroceryList()
        {
            return await _context.Grocery.ToListAsync();
        }            

    }
}
