using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using reactapp.Helpers;
using reactapp.Manager.Contract;
using reactapp.Models;
using reactapp.ViewModels;

namespace reactapp.Manager.Service
{
    /// <summary>
    /// Tag service
    /// </summary>
    public class TagService : IGroceryService
    {
        /// <summary>
        /// logger for Tag
        /// </summary>
        readonly ILogger<TagService> _logger;

 
        /// <summary>
        /// Claim Identity
        /// </summary>
        private readonly ClaimsPrincipal _principal;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="principal"></param>   
        public TagService(ILogger<TagService> logger, IPrincipal principal)
        {
            _logger = logger;
            _principal = principal as ClaimsPrincipal;           
        }

        /// <summary>
        /// To get Tag list
        /// </summary>
        /// <returns></returns>
        public async Task<IResult> GetGroceryList()
        {
            var result = new Result
            {
                Operation = Enums.Operation.Read,
                Status = Enums.Status.Success,
                StatusCode = System.Net.HttpStatusCode.OK
            };
            try
            {
                var listGrocery = new List<GroceryViewModel>();
              //  var contents = await _tagRepository.GetTagByTagId(TagId);
                for (int i = 1; i <= 10; i++)
                {
                    GroceryViewModel groceryViewModel = new GroceryViewModel();
                    groceryViewModel.Caloreis = i + 100;
                    groceryViewModel.Cost = i + 200;
                    groceryViewModel.Id = i + 300;
                    groceryViewModel.Name = "grocery " + i;
                    groceryViewModel.Weight = i + 400;
                    listGrocery.Add(groceryViewModel);
                }
                result.Body =  listGrocery;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                result.Status = Enums.Status.Error;
                result.Message = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return result;
        }
    
    }
}
