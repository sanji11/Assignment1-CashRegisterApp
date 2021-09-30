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
    public partial class HistoryPage : ContentPage
    {
        public ObservableCollection<History> history = new ObservableCollection<History>();
        public HistoryPage(ObservableCollection<History> h)
        {
            InitializeComponent();
            history = h;
            historyList.ItemsSource = h;
            
        }

        private void historyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            History prodHistory = e.SelectedItem as History;
            Navigation.PushAsync(new HistoryDetailPage(prodHistory));
        }
    }
}