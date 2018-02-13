using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.DataType.Models
{
    /// <summary>
    /// Offers page view model.
    /// </summary>
    public class HotelOfferModel
    {
        /// <summary>
        /// Offers result.
        /// </summary>
        public List<HotelOfferDetailsModel> Offers { get; set; }
        /// <summary>
        /// Used when submiting the form for search.
        /// </summary>
        public HotelsOffersFilter Filter { get; set; }
        /// <summary>
        /// Used when submiting the form for sort.
        /// </summary>
        public HotelsOffersSorting Sorting { get; set; }
        
        public HotelOfferModel()
        {
            Offers = new List<HotelOfferDetailsModel>();
        }
    }

    /// <summary>
    /// Hotel offer.
    /// </summary>
    public class HotelOfferDetailsModel
    {
        public HotelInfo HotelInfo { get; set; }
        public OfferDetails OfferDetails { get; set; }
        public HotelOfferDetailsModel()
        {
            HotelInfo = new HotelInfo();
            OfferDetails = new OfferDetails();
        }
    }
    public class HotelInfo
    {
        public string ID { get; set; }
        public string ImageUrl { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }

        public string StreetAddress { get; set; }
        public string Name { get; set; }
        public bool VipAccess { get; set; }
        public string StarRating { get; set; }
        public float GuestReviewRating { get; set; }
        public int ReviewTotal { get; set; }
        public float AveragePrice { get; set; }
    }
    public class OfferDetails
    {
        public string Currency { get; set; }
        public float Discount { get; set; }
        public float OldPriceTotal { get; set; }
        public float OldPricePerNight { get; set; }
        public float CrossOutPriceTotal { get; set; }
        public float NewPriceTotal { get; set; }
        public int lengthOfStay { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
