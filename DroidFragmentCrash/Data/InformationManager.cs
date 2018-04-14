using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Acr.Settings;
using DroidFragmentCrash.Models;
using Newtonsoft.Json;

namespace DroidFragmentCrash.Data
{
    public class InformationManager : IInformationManager
    {
        private static InformationManager defaultInstance = new InformationManager();
        public static InformationManager DefaultInstance
        {
            get => defaultInstance;
            private set => defaultInstance = value;
        }

        private string _apiUri;

        public InformationManager()
        {
            // For use with Genymotion.
            _apiUri = "http://10.0.3.2:5000/api/values";
        }

        public async Task<List<Information>> GetInformationListAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var token = Settings.Current.Get<string>("AuthToken");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var result = await client.GetAsync(_apiUri))
                    {
                        result.EnsureSuccessStatusCode();

                        var response = await result.Content.ReadAsStringAsync();

                        var list = JsonConvert.DeserializeObject<List<string>>(response);

                        List<Information> infoList = new List<Information>();

                        foreach(var item in list)
                        {
                            var info = new Information { Value = item };

                            infoList.Add(info);
                        }

                        return infoList;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
