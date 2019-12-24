using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactApi.Models;

namespace ReactApi.Repository.SeedData
{
    /// <summary>
    /// GroceryConfiguration data
    /// </summary>
    public class GroceryConfiguration : IEntityTypeConfiguration<Grocery>
    {
        /// <summary>
        /// configure master data
        /// </summary>
        public void Configure(EntityTypeBuilder<Grocery> builder)
        {
            builder.HasData
                 (
                    new Grocery
                    {
                        Id = 1,
                        Name = "Grocery 1",
                        Caloreis = 144,
                        Cost=89,
                        Weight=66

                    },
                     new Grocery
                     {
                         Id = 2,
                         Name = "Grocery 2",
                         Caloreis = 1244,
                         Cost = 849,
                         Weight = 776

                     },
                    new Grocery
                    {
                        Id = 3,
                        Name = "Grocery 3",
                        Caloreis = 164,
                        Cost = 84,
                        Weight = 56
                    }
                 );
        }
    }
}
