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
    public partial class RestockPage : ContentPage
    {
        public ObservableCollection<Product> products = new ObservableCollection<Product>();
        public Product selectedProduct = null;
        public RestockPage(ObservableCollection<Product> prod)
        {
            InitializeComponent();
            this.products = prod;
            restockList.ItemsSource = this.products;
        }

        private void RestockButton_Clicked(object sender, EventArgs e)
        {
            //Check if the user entered any quantity
            if (!String.IsNullOrEmpty(NewQuantity.Text)) {
                //Check if the user selected a product
                if (selectedProduct != null)
                {
                    //Find the selected product from the observable collection
                    Product foundProd = products.FirstOrDefault(p => p.name.Equals(selectedProduct.name));
                    int index = products.IndexOf(foundProd);

                    //Update the qunatity with adding new quantity to the old quantity
                    Product newProd = new Product(products[index].name, products[index].quantity + Int32.Parse(NewQuantity.Text), products[index].price);
                    products[index] = newProd;

                    //Reset the variables
                    //NewQuantity.Text = "";
                    selectedProduct = null;
                }
                else
                {
                    //Handel Misusing : showing alert if the user does not select a product
                    DisplayAlert("Error", "You have to select an item and provide a new quantity", "OK");
                }
            }
            else
            {
                //Handel Misusing : showing alert if the user does not enter any quantity
                DisplayAlert("Error", "You have to select an item and provide a new quantity", "OK");
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            //Redirect back to previous page which is Manager Panel Page
            Navigation.PopAsync();
        }

        private void restockList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Save the selected product
            selectedProduct = e.SelectedItem as Product;
        }
    }
}