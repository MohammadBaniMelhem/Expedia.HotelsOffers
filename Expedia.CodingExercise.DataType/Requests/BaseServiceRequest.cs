using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.DataType.Requests
{
    /// <summary>
    /// Base class for any API service call.
    /// </summary>
    public abstract class BaseServiceRequest
    {
        public int ApiVersion;
        public string APIName { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public BaseServiceRequest()
        {
            ApiVersion = 1;
            HttpMethod = HttpMethod.Get;
        }
        public abstract string BuildRequestParameters(eRequestParametersType requestParametersType);
    }
}