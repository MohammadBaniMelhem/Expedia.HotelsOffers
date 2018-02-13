using Expedia.CodingExercise.DataType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.DataType.Responses.HotelsOffering
{
    /// <summary>
    /// Offers response needed for deserialization .
    /// </summary>
    public class GetOffersResponse : BaseServiceResponse
    {
        public Offerinfo offerInfo { get; set; }
        public Userinfo userInfo { get; set; }
        public Offers offers { get; set; }

        /// <summary>
        /// Method to convert the main offers response object to view model type.
        /// </summary>
        public List<HotelOfferDetailsModel> GetHotelsOffersDetailsModel()
        {
            List<HotelOfferDetailsModel> hotelOffers = new List<HotelOfferDetailsModel>();

            if (this.offers.Hotel != null && this.offers.Hotel.Count() > 0)
            {
                foreach (var item in this.offers.Hotel)
                {
                    hotelOffers.Add(new HotelOfferDetailsModel
                    {
                        HotelInfo = new HotelInfo
                        {
                            Name = item.hotelInfo.hotelName,
                            ImageUrl = item.hotelInfo.hotelImageUrl,
                            City = item.hotelInfo.hotelCity,
                            AveragePrice = item.hotelPricingInfo.averagePriceValue,
                            GuestReviewRating = item.hotelInfo.hotelGuestReviewRating,
                            Lat = item.hotelInfo.hotelLatitude,
                            Long = item.hotelInfo.hotelLongitude,
                            ReviewTotal = item.hotelInfo.hotelReviewTotal,
                            StarRating = item.hotelInfo.hotelStarRating,
                            StreetAddress = item.hotelInfo.hotelStreetAddress,
                            VipAccess = item.hotelInfo.vipAccess,
                            Country = item.destination.country,
                            Province = item.destination.province,
                            ID = item.hotelInfo.hotelId
                        },
                        OfferDetails = new OfferDetails
                        {
                            CrossOutPriceTotal = item.hotelPricingInfo.crossOutPriceValue,
                            Currency = item.hotelPricingInfo.currency,
                            Discount = item.hotelPricingInfo.percentSavings,
                            FromDate = new DateTime(item.offerDateRange.travelStartDate[0], item.offerDateRange.travelStartDate[1], item.offerDateRange.travelStartDate[2]).ToString("dd/MM/yyyy"),
                            ToDate = new DateTime(item.offerDateRange.travelEndDate[0], item.offerDateRange.travelEndDate[1], item.offerDateRange.travelEndDate[2]).ToString("dd/MM/yyyy"),
                            lengthOfStay = item.offerDateRange.lengthOfStay,
                            OldPriceTotal = item.hotelPricingInfo.originalPricePerNight,
                            NewPriceTotal = (item.hotelPricingInfo.originalPricePerNight - item.hotelPricingInfo.percentSavings),
                            OldPricePerNight = item.hotelPricingInfo.averagePriceValue

                        }
                    });
                }
            }

            return hotelOffers;
        }
    }

    public class Offerinfo
    {
        public string siteID { get; set; }
        public string language { get; set; }
        public string currency { get; set; }
        public string userSelectedCurrency { get; set; }
    }

    public class Userinfo
    {
        public Persona persona { get; set; }
        public string userId { get; set; }
    }

    public class Persona
    {
        public string personaType { get; set; }
    }

    public class Offers
    {
        public Hotel[] Hotel { get; set; }
    }

    public class Hotel
    {
        public Offerdaterange offerDateRange { get; set; }
        public Destination destination { get; set; }
        public Hotelinfo hotelInfo { get; set; }
        public Hotelpricinginfo hotelPricingInfo { get; set; }
        public Hotelurls hotelUrls { get; set; }
    }

    public class Offerdaterange
    {
        public int[] travelStartDate { get; set; }
        public int[] travelEndDate { get; set; }
        public int lengthOfStay { get; set; }
    }

    public class Destination
    {
        public string regionID { get; set; }
        public string associatedMultiCityRegionId { get; set; }
        public string longName { get; set; }
        public string shortName { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string tla { get; set; }
        public string nonLocalizedCity { get; set; }
    }

    public class Hotelinfo
    {
        public string hotelId { get; set; }
        public string hotelName { get; set; }
        public string localizedHotelName { get; set; }
        public string hotelDestination { get; set; }
        public string hotelDestinationRegionID { get; set; }
        public string hotelLongDestination { get; set; }
        public string hotelStreetAddress { get; set; }
        public string hotelCity { get; set; }
        public string hotelProvince { get; set; }
        public string hotelCountryCode { get; set; }
        public float hotelLatitude { get; set; }
        public float hotelLongitude { get; set; }
        public string hotelStarRating { get; set; }
        public float hotelGuestReviewRating { get; set; }
        public int hotelReviewTotal { get; set; }
        public string hotelImageUrl { get; set; }
        public bool vipAccess { get; set; }
        public bool isOfficialRating { get; set; }
    }

    public class Hotelpricinginfo
    {
        public float averagePriceValue { get; set; }
        public float totalPriceValue { get; set; }
        public float crossOutPriceValue { get; set; }
        public float originalPricePerNight { get; set; }
        public string currency { get; set; }
        public float percentSavings { get; set; }
        public bool drr { get; set; }
    }

    public class Hotelurls
    {
        public string hotelInfositeUrl { get; set; }
        public string hotelSearchResultUrl { get; set; }
    }
}
