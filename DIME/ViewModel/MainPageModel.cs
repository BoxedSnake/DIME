using DIME.Model;
using DIME.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIME.ViewModel
{
    public class MainPageModel
    {
        public MainPageModel() { }
        Service service = new Service();
        public List<Account> accounts;

        public async Task getAccounts()
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

            return accounts;
        }

        public void sortByAge()
        {
            accounts.Sort((x, y) => x.Age.CompareTo(y.Age));
        }

        public void sortByBalance()
        {

        }

    }
}
