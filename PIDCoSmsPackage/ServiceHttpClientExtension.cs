using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PIDCoSmsPackage.Model;

namespace PIDCoSmsPackage
{
    public static class ServiceHttpClientExtension
    {

        public static async Task<ApiResultModel<T>> PostAsync<T>(IHttpClientFactory httpClientFactory, string uri,object postData,string token=null)
        {

            var client = httpClientFactory.CreateClient("MyApi");

            client.BaseAddress = new Uri("https://api.smszone.ir/api/");
            
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);
            

            if (token!=null)
                client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"bearer {token}");

            var response = await client.PostAsync(uri,postData.ToHttpContent());
            //if the status code is OK Deserialize JSON
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(result);
                return new ApiResultModel<T> { Status = HttpStatusCode.OK, Data = data };
            }
            else
            {
                var tt = await response.Content.ReadAsStringAsync();
            }
            return new ApiResultModel<T> { Status = response.StatusCode };


        }

        public static HttpContent ToHttpContent(this object data)
        {
            string output = JsonConvert.SerializeObject(data);
            var json = new StringContent(output, Encoding.UTF8, MediaTypeNames.Application.Json);
            return json;
        }
    }
}
