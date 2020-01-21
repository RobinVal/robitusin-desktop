using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Wpf_Robitusin.Models;

namespace Wpf_Robitusin
{
    public class LoginViewModel
    {
        public User TryExisting(int id) /* Nemohu vyhledávat pomocí username, protože se dá zatím hledat pouze pomocí id */
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://localhost:49497/");
            HttpResponseMessage response = apiClient.GetAsync("api/User/" + id).Result;
            /*
            var emp = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            string k = response.Content.ReadAsStringAsync().Result;
            */
            return response.Content.ReadAsAsync<User>().Result; /* musím se pochválit -> Na tento řádek jsem přišel v podstatě sám */
        }
    }
}
