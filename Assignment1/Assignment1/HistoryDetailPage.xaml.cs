using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryDetailPage : ContentPage
    {
        
        public HistoryDetailPage(History h)
        {
            InitializeComponent();

            ProdName.Text = "Product name: " + h.name;
            ProdQty.Text = "Quantity: " + h.quantity.ToString();
            ProdDate.Text = "Date & Time: " + h.date.ToString();
            ProdTotalPrice.Text = "Total amount: " + h.totalPrice.ToString();
            HistoryDetail.Title = h.name;

        }
    }
}