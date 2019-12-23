using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reactapp.Helpers;
using reactapp.Manager.Contract;
using reactapp.ViewModels;

namespace reactapp.Controllers
{
    /// <summary>
    /// common controller
    /// </summary>
    [Route("api")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        readonly ILogger<CommonController> _logger;
        IGroceryService _tagService;
        /// <summary>
        /// CommonController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="tagService"></param>    
        public CommonController(ILogger<CommonController> logger, IGroceryService tagService)
        {
            _logger = logger;
            _tagService = tagService;
        }

        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet("getGroceryList")]
        [ProducesResponseType(typeof(List<GroceryViewModel>), (int)HttpStatusCode.PartialContent)]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IResult>> GetGroceryList()
        {
            _logger.LogDebug("Started calling get all the contents");
            var result = await _tagService.GetGroceryList();
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
