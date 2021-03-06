﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactApi.Models;

namespace ReactApi.Repository
{
    /// <summary>
    /// Offer portal db set
    /// </summary>
    public partial class ReactAppContext
    {
        /// <summary>
        /// Grocery
        /// </summary>
        public DbSet<Grocery> Grocery { get; set; }

    }
}
