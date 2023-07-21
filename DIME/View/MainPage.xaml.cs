using DIME.ViewModel;
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
            _ = SetAccounts();



        }
        public async Task SetAccounts()
        {
            await model.GetAccounts();
            LV_Accounts.ItemsSource = model.GroupByGender();


        }

    }
}
