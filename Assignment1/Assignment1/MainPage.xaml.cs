using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> products = new ObservableCollection<Product>
        {
            new Product("Pants", 20, 50.7),
            new Product("Shoes", 50, 90),
            new Product("Hats", 10, 20.5),
            new Product("Tshirts", 10, 24.99),
            new Product("Dresses", 24, 140.3)

        };
        public ObservableCollection<History> histories = new ObservableCollection<History>();
        public MainPage()
        {
            InitializeComponent();
            myList.ItemsSource = products;
           

        }
        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            //Update quantity label with selected quantity
            Button numBtn = sender as Button;
            if (!Quantity.Text.Equals("Quantity")) {
                Quantity.Text += numBtn.Text;
            }
            else {
                Quantity.Text = numBtn.Text;
            }

            //Update the total: Total = amount * item price
            foreach (Product p in products) {
                if (p.name.Equals(Name.Text)) {
                    Total.Text = (Int32.Parse(Quantity.Text) * p.price).ToString();
                }
            
            }
            
        }

        private void BuyButton_Clicked(object sender, EventArgs e)
        {
            //Check if the quantity is entered and the product is selected
            if (!Quantity.Text.Equals("Quantity") && !Name.Text.Equals("Type"))
            {
                int qty = Int32.Parse(Quantity.Text);
                //Find the selected product from the observable collection
                Product selectedProd = products.FirstOrDefault(p => p.name.Equals(Name.Text));
                int index = products.IndexOf(selectedProd);

                //Check if the quantity avaialble in the stock
                if (products[index].quantity >= qty)
                {
                    /*Update the product's quantity
                    New Quantity = Old Quantity - Purchased amount*/
                    Product newProduct = new Product(products[index].name, products[index].quantity - qty, products[index].price);
                    products[index] = newProduct;

                    //Save the purchased product to the history
                    History aHistory = new History(products[index].name, products[index].quantity, double.Parse(Total.Text), DateTime.Now);
                    histories.Add(aHistory);

                }
                else
                {
                    //Alert with an error message
                    DisplayAlert("Error", "The selected quantity is more than the available quantity in the stock", "OK");
                }

                //reset the UI
                Name.Text = "Type";
                Quantity.Text = "Quantity";
                Total.Text = "Total";


            }
            else
            {
                //Alert with an error message
                DisplayAlert("Error", "Please select a product and enter a quantity to buy the product", "OK");
            }


        }

        private void myList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Update type label with product name
            Product selectedProduct = e.SelectedItem as Product;
            Name.Text = selectedProduct.name;

            //Update the total if quantity is selected: Total = amount * item price
            if (!Quantity.Text.Equals("Quantity")) {
                Total.Text = (Int32.Parse(Quantity.Text) * selectedProduct.price).ToString();
            }


        }

        private void ManagerButton_Clicked(object sender, EventArgs e)
        {
            //Redirect to Manager Panel Page
            Navigation.PushAsync(new ManagerPanelPage(histories, products));
        }
    }
}
