using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Acr.Settings;
using Newtonsoft.Json;

namespace DroidFragmentCrash.Data
{
    public class DataManager<T> : IDataManager<T>
    {
        private readonly string _apiUri;

        public DataManager(string path)
        {
            _apiUri = "http://10.0.3.2:5000/api/" + path;
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var token = CrossSettings.Current.Get<string>("AuthToken");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var result = await client.GetAsync(_apiUri))
                    {
                        result.EnsureSuccessStatusCode();

                        var response = await result.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<List<T>>(response);
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