using DIME.Model;
using DIME.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DIME.ViewModel
{
    public class MainPageModel
    {
        public MainPageModel() { }
        Service service = new Service();
        public List<Account> accounts;
        public List<GroupedAccounts> groupedAccounts;

        public async Task GetAccounts()
        {
            try
            {
                //AccountList value = await service.GetAccounts();
                //accounts = value.accounts.ToList();
                accounts = await service.GetAccounts();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        public List<Account> LoadAccounts()
        {
            SortByAge();
            SortByBalance();

            return accounts;
        }
        public List<GroupedAccounts> LoadGroups()
        {
            SortByAge();
            SortByBalance(); GroupByGender();

            return groupedAccounts;
        }

        public void SortByAge()
        {
            accounts.Sort((x, y) => y.Age.CompareTo(x.Age));
        }

        public void SortByBalance()
        {
            accounts.Sort((x, y) => ParseCurrencyString(x.AccountBalance).CompareTo(ParseCurrencyString(y.AccountBalance)));

        }

        public void GroupByGender()
        {
           var grouped = accounts.GroupBy(x => x.Gender).ToList();
            foreach (var gender in grouped)
            {
                GroupedAccounts group = new GroupedAccounts();
                group.Title = gender.Key;
                foreach (var item in gender)
                {
                    group.Accounts.Add(item);
                }
                groupedAccounts.Add(group);
            }

        }

        public static decimal ParseCurrencyString(string currencyString)
        {
            if (string.IsNullOrWhiteSpace(currencyString))
            {
                throw new ArgumentException("Currency string cannot be null or empty.");
            }

            // Remove non-numeric characters and parse the value to a decimal
            decimal amount = decimal.Parse(currencyString.Replace("$", "").Replace(",", ""), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

            return amount;
        }

    }
}
