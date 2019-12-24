using System.Diagnostics.CodeAnalysis;

namespace ReactApi.FilterTypes
{
    /// <summary>
    /// BaseFilter setting
    /// </summary>
    public class PagingFilter
    {
        private string _sortDirection = string.Empty;
        private int _take;
        
        /// <summary>
        /// SortDirection
        /// </summary>
        public string SortDirection
        {
            get => _sortDirection;
            set => _sortDirection = value ?? "Ascending";
        }
        
        /// <summary>
        /// Skip
        /// </summary>
        public int Skip { get; set; }
        
        /// <summary>
        /// Take
        /// </summary>
        public int Take
        {
            get => _take;
            set => _take = value == 0 ? 10 : value;
        }

        /// <summary>
        /// SearchContent
        /// </summary>
        public string SearchContent { get; set; }

        /// <summary>
        /// Selected category for searching
        /// </summary>
        public int Category { get; set; }

    }
}
