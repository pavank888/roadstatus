using RoadStatus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RoadStatus.ServiceLayer
{
    public class Service
    {
        HttpClient client = new HttpClient();
        string app_id = ConfigurationManager.AppSettings["app_id"];
        string app_key = ConfigurationManager.AppSettings["app_key"];



        internal async Task<RoadCorridor> GetRoadStatus(string roadName)
        {
            client.BaseAddress = new Uri("https://api.tfl.gov.uk");
                //specify to use TLS 1.2 as default connection
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var path = @"/Road/" + roadName + "?app_id=" + app_id + "&app_key=" + app_key;
      
                RoadCorridor road = null;
                HttpResponseMessage response = client.GetAsync(Uri.EscapeUriString(path)).Result; //await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var resultList = await response.Content.ReadAsAsync<List<RoadCorridor>>();
                    road = resultList.FirstOrDefault();

                }
                else
                {
                    var apiError = await response.Content.ReadAsAsync<ApiError>();
                    var errorMessage = string.Format("{0} is not a valid road", roadName);
                    throw new Exception(errorMessage);
                }
                return road;
            }
           
           
        }
    }

