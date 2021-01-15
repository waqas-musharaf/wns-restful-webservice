using System;
using System.IO;
using System.Net;

namespace rest_client
{
    // Defines an enumerable for http methods, with only 'GET' listed
    public enum HttpVerb
    {
        GET
    }

    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }

        // Instantiates the RestClient class with an empty endpoint and 'GET' as the http method
        public RestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = HttpVerb.GET;
        }

        public string MakeRequest()
        {
            string responseString = string.Empty;

            // Creates a new http web request using the provided endpoint
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.Method = HttpMethod.ToString();

            // Stores the http web response within a variable
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Checks for any unexpected status codes
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("ERROR: Unexpected response status code: " + response.StatusCode.ToString());
                }

                // Retrieves the response stream from the stored response variable
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        // If the response stream is not null, uses StreamReader to read the response stream to a string variable
                        using (StreamReader streamReader = new StreamReader(responseStream))
                        {
                            responseString = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            // Returns the response string
            return responseString;
        }
    }
}
