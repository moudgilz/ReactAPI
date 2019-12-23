using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace reactapp.Repository
{
    interface test
    {
        int a { get; set; }
        void testing();
    }
    class useit : test
    {
        public int a { get; set; }

        public void testing()
        {            
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Offer portal context
    /// </summary>
    public partial class ReactAppContext : DbContext
    {
        /// <summary>
        /// ctor default
        /// </summary>
        protected ReactAppContext()
        {
            Log.Logger.Debug("At OfferPortalContext ctor");
        }

        /// <summary>
        /// ctor 
        /// </summary>
        /// <param name="options"></param>
        public ReactAppContext(DbContextOptions<ReactAppContext> options) : base(options)
        {
            Log.Logger.Debug("DbContextOptions at OfferPortalContext ctor");
        }

        /// <summary>
        /// On model creating event
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Log.Logger.Debug("OnModelCreating at OfferPortalContext");        

        }

        /// <summary>
        /// Get set data on db creation
        /// </summary>
        public void SeedData()
        {
            Log.Logger.Debug("Seed at OfferPortalContext");
            ModelBuilderExtensions.Seed(this);
        }

    }

    internal static class ModelBuilderExtensions
    {
        /// <summary>
        /// Get set data on db creation
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(ReactAppContext context)
        {
            Log.Logger.Debug("Seed at ModelBuilderExtensions");
        }
    }
}
