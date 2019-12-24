using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApi.ViewModels
{
    /// <summary>
    /// Tag veiw model an item to make it searchable
    /// </summary>
    public class GroceryViewModel
    {
        /// <summary>
        /// primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
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
