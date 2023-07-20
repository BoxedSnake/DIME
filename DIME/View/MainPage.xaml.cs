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
        
        MainPageModel model = new MainPageModel();
        public MainPage()
        {
            InitializeComponent();

           

            Task task = SetAccounts();

        }
        public async Task SetAccounts()
        {
            await model.getAccounts();
            LV_Accounts.ItemsSource = model.LoadAccounts();

        }

        private async void Bt_Age_Clicked(object sender, EventArgs e)
        {
            model.sortByAge();




        }

        private void bt_Balance_Clicked(object sender, EventArgs e)
        {

        }
    }
}
