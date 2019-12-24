using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApi.Helpers
{
    /// <summary>
    /// Logged user claim
    /// </summary>
    public class UserClaim
    {
        /// <summary>
        /// Logged user name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Logged user email
        /// </summary>
        public string Email { get; set; }
    }
}
