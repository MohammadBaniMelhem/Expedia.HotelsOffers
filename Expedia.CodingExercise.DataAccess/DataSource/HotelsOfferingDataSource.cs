using Expedia.CodingExercise.DataType.Requests.HotelsOffering;
using Expedia.CodingExercise.DataType.Responses.HotelsOffering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.DataAccess
{
    public class HotelsOfferingDataSource : BaseServiceDataSource
    {
        private static string baseServiceAddress = Utilities.GetConfigurationValue("Expedia.CodingExercise.HotelsOffering.BaseServiceAddress", "https://offersvc.expedia.com");
        private static string servicePath = Utilities.GetConfigurationValue("Expedia.CodingExercise.HotelsOffering.ServicePath", "/offers/v{0}/");

        private static string fullServiceAddress = baseServiceAddress + servicePath;

        public HotelsOfferingDataSource() : base(fullServiceAddress)
        {

        }
        /// <summary>
        /// Get Offers from the service API.
        /// </summary>
        /// <param name="request">The main request class that holds the needed parameters to make the call.</param>
        /// <returns>
        /// An instance of the <see cref="T:expedia.CodingExercise.DataType.Responses.HotelsOffering.GetOffersResponse"/> class.
        /// </returns>
        public GetOffersResponse GetOffers(GetOffersRequest request)
        {
            string jsonOffers = GetJsonOffers(request);
            if (!string.IsNullOrWhiteSpace(jsonOffers))
            {
                return JsonConvert.DeserializeObject<GetOffersResponse>(jsonOffers);
            }

            return null;
        }
        /// <summary>
        /// Get Offers from the service API.
        /// </summary>
        /// <param name="request">The main request class that holds the needed parameters to make the call.</param>
        /// <returns>
        /// Json object of the offers response.
        /// </returns>
        public string GetJsonOffers(GetOffersRequest request)
        {
            HttpRequestMessage httpRequest;
            /// <summary>
            /// Create common httpclient needed to fetch the response form the API, ite avalaible in the base class
            /// </summary>
            HttpClient client = CreateHttpClient(request, out httpRequest);

            /// <summary>
            /// Create common httpclient executer, ite avalaible in the base class
            /// </summary>
            HttpResponseMessage httpResponse = ExecuteHttpClient(client, httpRequest);

            if (httpResponse.IsSuccessStatusCode)
            {
                return httpResponse.Content.ReadAsStringAsync().Result;
            }

            return null;
        }
    }
}