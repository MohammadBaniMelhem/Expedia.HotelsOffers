using Expedia.CodingExercise.BusinessLogic.Interface;
using Expedia.CodingExercise.DataAccess;
using Expedia.CodingExercise.DataType;
using Expedia.CodingExercise.DataType.Models;
using Expedia.CodingExercise.DataType.Requests.HotelsOffering;
using Expedia.CodingExercise.DataType.Responses.HotelsOffering;
using Expedia.CodingExercise.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.BusinessLogic.Activities
{
    public class HotelsOfferingActivities : BaseActivities, IHotelsOffering
    {
        /// <summary>
        /// Get Offers from the service API, and do the needed filtering and sorting.
        /// </summary>
        /// <param name="filter">The filter of offers.</param>
        /// <param name="sorting">The sorting order.</param>
        /// <returns>
        /// An instance of the <see cref="T:Expedia.CodingExercise.DataType.ActivityResult"/> class.
        /// </returns>
        public ActivityResult GetOffers(HotelsOffersFilter filter, HotelsOffersSorting sorting)
        {
            /// <summary>
            /// Returned calss
            /// </summary>
            ActivityResult activityResult = new ActivityResult();

            /// <summary>
            /// The needed parameters to make the API request
            /// </summary>
            GetOffersRequest request = new GetOffersRequest(filter);

            try
            {
                
                using (HotelsOfferingDataSource dataSource = new HotelsOfferingDataSource())
                {
                    var offers = dataSource.GetOffers(request);

                    if (offers != null)
                    {
                        HotelOfferModel hotelOffersModel = new HotelOfferModel();
                        hotelOffersModel.Offers = offers.GetHotelsOffersDetailsModel();
                        hotelOffersModel.Filter = filter ?? new HotelsOffersFilter();
                        hotelOffersModel.Sorting = sorting ?? new HotelsOffersSorting();
                        if (sorting != null)
                        {
                            hotelOffersModel.Offers = hotelOffersModel.Offers.ApplyOrder(sorting.OrderBy);
                        }

                        activityResult.IsPassed = true;
                        activityResult.ReturnedObject = hotelOffersModel;
                    }
                    else
                    {
                        activityResult.IsPassed = false;
                        activityResult.Code = eResponseCode.General_Error;
                    }
                }
            }
            catch (Exception ex)
            {
                activityResult.IsPassed = false;
                activityResult.Code = eResponseCode.General_Error;
            }

            return activityResult;
        }

    }
}
