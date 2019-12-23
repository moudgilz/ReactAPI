using reactapp.Helpers;
using reactapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reactapp.Manager.Contract
{
    /// <summary>
    /// interface for Tag 
    /// </summary>
    public interface IGroceryService
    {
        /// <summary>
        /// To get the Grocery List
        /// </summary>
        /// <returns></returns>
        Task<IResult> GetGroceryList();   
       
    }
}
