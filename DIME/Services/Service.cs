using DIME.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace DIME.Services
{
    public class Service
    {
            public Service() { }
        public async Task<List<Account>> GetAccounts()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://darkice.co/wp-content/uploads/2023/07/accounts.json");
            
            List<Account> deserializedAccount = JsonConvert.DeserializeObject<List<Account>>(response).Where(x => x.IsActive && DateTime.Parse(x.Registered).Year > 2016).ToList();

            //deserializedAccount.Sort((x, y) => x.Age.CompareTo(y.Age));
            //List<Account> sortedbyAge = deserializedAccount.OrderByDescending(x => x.Age).ToList();
            //List<Account> sortedbyBalance = sortedbyAge.OrderBy(x => x.AccountBalance).ToList();



            return deserializedAccount;
        }


    }
}
