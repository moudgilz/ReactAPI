using ReactApi.Helpers;
using ReactApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApi.Manager.Contract
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
