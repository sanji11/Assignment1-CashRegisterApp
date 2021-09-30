using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagerPanelPage : ContentPage
    {
        public ObservableCollection<History> historyProduct = new ObservableCollection<History>();
        public ObservableCollection<Product> products = new ObservableCollection<Product>();
        public ManagerPanelPage(ObservableCollection<History> hp, ObservableCollection<Product> p)
        {
            InitializeComponent();
            this.historyProduct = hp;
            this.products = p;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Redirect to different pages
            Button btn = sender as Button;
            if (btn.Text.Equals("History")) {

                Navigation.PushAsync(new HistoryPage(historyProduct));

            } else if (btn.Text.Equals("Restock"))
            {
                Navigation.PushAsync(new RestockPage(products));
            }
            else {
                Navigation.PushAsync(new AddNewProductPage(products));
            }
        }

        
    }
}