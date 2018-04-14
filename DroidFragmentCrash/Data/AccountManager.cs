using System;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.Settings;
using Newtonsoft.Json.Linq;

namespace DroidFragmentCrash.Data
{
    public class AccountManager : IAccountManager
    {
        private static AccountManager defaultInstance = new AccountManager();
        public static AccountManager DefaultInstance
        {
            get => defaultInstance;
            private set => defaultInstance = value;
        }

        private string _apiUri;

        public AccountManager()
        {
            // For use with Genymotion.
            _apiUri = "http://10.0.3.2:5000/api/accounts/signin";
        }

        public async Task SignInAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var result = await client.GetAsync(_apiUri))
                    {
                        result.EnsureSuccessStatusCode();

                        var response = await result.Content.ReadAsStringAsync();

                        var token = JObject.Parse(response)["token"].ToString();

                        Settings.Current.Set<string>("AuthToken", token);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SignOut()
        {
            Settings.Current.Clear();
        }
    }
}
