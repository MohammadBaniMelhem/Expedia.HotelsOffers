using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Expedia.CodingExercise.DataType.Models;

namespace Expedia.CodingExercise.DataType.Requests.HotelsOffering
{
    /// <summary>
    /// Offers request needed to consuming the offers API.
    /// </summary>
    public class GetOffersRequest : BaseServiceRequest
    {
        HotelsOffersFilter _filter;
        public override string BuildRequestParameters(eRequestParametersType requestParametersType)
        {
            string staticQuery = "scenario=deal-finder&page=foo&uid=foo&productType=Hotel";

            switch (requestParametersType)
            {
                case eRequestParametersType.QueryString:
                    {
                        if (_filter != null)
                        {

                            return staticQuery + _filter.filterQuery;
                        }
                        return staticQuery + "";
                    }

                case eRequestParametersType.Json:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }
        public GetOffersRequest(HotelsOffersFilter filter)
        {
            APIName = "getOffers";
            ApiVersion = 2;
            HttpMethod = HttpMethod.Get;
            _filter = filter;
        }
        public GetOffersRequest()
        {
            APIName = "getOffers";
            ApiVersion = 2;
            HttpMethod = HttpMethod.Get;
        }
        public void AddFilter(HotelsOffersFilter filter)
        {
            _filter = filter;
        }
    }

}