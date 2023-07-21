using DIME.Model;
using DIME.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DIME.ViewModel
{
    public class MainPageModel
    {
        Service service = new Service();
        public List<Account> accounts = new List<Account> { };
        public List<GroupedAccount> groupedAccounts = new List<GroupedAccount> { };
        public MainPageModel() { }

        public async Task GetAccounts()
        {
            try
            {
                //AccountList value = await service.GetAccounts();
                accounts = await service.GetAccounts();
                SortAccounts();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        public void SortAccounts()
        {
            SortByAge();

            SortByBalance();

        }


        public void SortByAge()
        {
            accounts.Sort((x, y) => y.Age.CompareTo(x.Age));

        }
        public void SortByBalance()
        {
            accounts.Sort((x, y) => ParseCurrencyString(x.AccountBalance).CompareTo(ParseCurrencyString(y.AccountBalance)));

        }

        public List<Account> LoadAccounts()
        {
            groupedAccounts = GroupByGender();
            return accounts;
        }

        public List<GroupedAccount> GroupByGender()
        {
            var source = accounts;
            var groupedAccounts = source.GroupBy(a => a.Gender)
                                          .Select(group => new GroupedAccount(group.Key, group.ToList()))
                                          .ToList();

            return groupedAccounts;
        }

        public decimal ParseCurrencyString(string currencyString)
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
