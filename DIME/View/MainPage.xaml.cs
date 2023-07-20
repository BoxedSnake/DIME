using DIME.Model;
using DIME.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DIME
{
    public partial class MainPage : ContentPage
    {

        readonly MainPageModel model = new MainPageModel();
        public MainPage()
        {
            InitializeComponent();
            _ = SetAccounts();

            

        }
        public async Task SetAccounts()
        {
            await model.GetAccounts();
            LV_Accounts.ItemsSource = model.LoadAccounts();
            //LV_Accounts.ItemsSource = model.LoadGroups();
          

        }

    }
}
