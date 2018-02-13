using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Expedia.CodingExercise.DataType.Models
{
    /// <summary>
    /// Offers filter fields.
    /// </summary>
    public class HotelsOffersFilter
    {
        public string filterQuery { get; set; }

        string destinationName { get; set; }
        string lengthOfStay { get; set; }
        string minTripStartDate { get; set; }
        string maxTripStartDate { get; set; }
        string minStarRating { get; set; }
        string maxStarRating { get; set; }
        string maxTotalRate { get; set; }
        string minTotalRate { get; set; }
        string maxGuestRating { get; set; }
        string minGuestRating { get; set; }
        [Display(ResourceType = typeof(Resources.Labels), Name = "lblDestinationName")]
        public string DestinationName { get { return destinationName; } set { destinationName = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&destinationName=" + value; } }
        [Display(ResourceType = typeof(Resources.Labels), Name = "lblLengthOfStay")]

        public string LengthOfStay { get { return lengthOfStay; } set { lengthOfStay = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&lengthOfStay=" + value; } }

        [Display(ResourceType = typeof(Resources.Labels), Name = "lblMinTripStartDate")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string MinTripStartDate { get { return minTripStartDate; } set { minTripStartDate = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&minTripStartDate=" + value; } }
        [Display(ResourceType = typeof(Resources.Labels), Name = "lblMaxTripStartDate")]
        public string MaxTripStartDate
        {
            get { return maxTripStartDate; }
            set
            {
                maxTripStartDate = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&maxTripStartDate=" + value;
            }
        }
        [Display(ResourceType = typeof(Resources.Labels), Name = "lblMinStarRating")]
        public string MinStarRating { get { return minStarRating; } set { minStarRating = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&minStarRating=" + value; } }
        [Display(ResourceType = typeof(Resources.Labels), Name = "lblMaxStarRating")]
        public string MaxStarRating { get { return maxStarRating; } set { maxStarRating = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&maxStarRating=" + value; } }

        [Display(ResourceType = typeof(Resources.Labels), Name = "lblMaxTotalRate")]
        public string MaxTotalRate { get { return maxTotalRate; } set { maxTotalRate = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&maxTotalRate=" + value; } }
        [Display(ResourceType = typeof(Resources.Labels), Name = "lblMinTotalRate")]
        public string MinTotalRate { get { return minTotalRate; } set { minTotalRate = value; if (!string.IsNullOrWhiteSpace(value)) minTotalRate += "&minTotalRate=" + value; } }

        [Display(ResourceType = typeof(Resources.Labels), Name = "lblMaxGuestRating")]
        public string MaxGuestRating { get { return maxGuestRating; } set { maxGuestRating = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&maxGuestRating=" + value; } }
        [Display(ResourceType = typeof(Resources.Labels), Name = "lblMinGuestRating")]
        public string MinGuestRating { get { return minGuestRating; } set { minGuestRating = value; if (!string.IsNullOrWhiteSpace(value)) filterQuery += "&minGuestRating=" + value; } }
    }
}