using Expedia.CodingExercise.DataType;
using Expedia.CodingExercise.DataType.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.DataAccess
{
    /// <summary>
    /// Base class of any API datasource.
    /// </summary>
    public abstract class BaseServiceDataSource : IDisposable
    {
        private static string serviceAddress;
        public BaseServiceDataSource(string serviceUrl)
        {
            serviceAddress = serviceUrl;
        }

        /// <summary>
        /// Create HttpClient based on common base request.
        /// </summary>
        /// <param name="request">The base request class that holds the needed parameters to make the call.</param>
        public HttpClient CreateHttpClient(BaseServiceRequest request, out HttpRequestMessage httpRequest)
        {
            var fullServiceAddress = string.Format(serviceAddress, request.ApiVersion, 1);

            UriBuilder uriBuilder = new UriBuilder(fullServiceAddress);
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(fullServiceAddress);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (request.HttpMethod == HttpMethod.Post)
            {
                httpRequest = new HttpRequestMessage(request.HttpMethod, request.APIName);

                var requestData = request.BuildRequestParameters(eRequestParametersType.Json);
                httpRequest.Content = new StringContent(requestData, Encoding.UTF8, "application/json");
            }
            else
            {

                uriBuilder.Query = request.BuildRequestParameters(eRequestParametersType.QueryString);
                httpRequest = new HttpRequestMessage(request.HttpMethod, request.APIName + uriBuilder.Query);
            }

            return client;
        }
        /// <summary>
        /// Execute any HttpClient.
        /// </summary>
        /// <param name="httpClient"></param>
        public HttpResponseMessage ExecuteHttpClient(HttpClient httpClient, HttpRequestMessage httpRequest)
        {
            return Task.Run(() => httpClient.SendAsync(httpRequest)).Result;
        }
        public void Dispose()
        {
        }
    }
}