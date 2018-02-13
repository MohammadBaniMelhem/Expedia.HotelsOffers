using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Expedia.CodingExercise.DataType.Models
{
    /// <summary>
    /// Offers sorting fields.
    /// </summary>
    public class HotelsOffersSorting
    {
        public string OrderBy { get; set; }

        string byName;
        string byPrice;
        string byRating;

        public string ByName { get { return byName; } set { byName = value; if (!string.IsNullOrWhiteSpace(value)) OrderBy += "," + value; } }
        public string ByPrice { get { return byPrice; } set { byPrice = value; if (!string.IsNullOrWhiteSpace(value)) OrderBy += "," + value; } }
        public string ByRating { get { return byRating; } set { byRating = value; if (!string.IsNullOrWhiteSpace(value)) OrderBy += "," + value; } }
    }
}