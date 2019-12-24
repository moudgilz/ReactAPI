using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApi.Models
{
    /// <summary>
    /// Tag an item to make it searchable
    /// </summary>
    public class Grocery
    {
        /// <summary>
        /// primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Tage name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Cost
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Caloreis
        /// </summary>
        public decimal Caloreis { get; set; }
        /// <summary>
        /// Weight
        /// </summary>
        public decimal Weight { get; set; }


    }
}
