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
    public partial class AddNewProductPage : ContentPage
    {
        public ObservableCollection<Product> productList = new ObservableCollection<Product>();
        public AddNewProductPage(ObservableCollection<Product> prod)
        {
            InitializeComponent();
            productList = prod;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            ToolbarItem toolbarItem = sender as ToolbarItem;

            //Check which toolbar item is selected
            if (toolbarItem.Text.Equals("Save"))
            {
                //Check if all the fields of the new product is entered
                if (!string.IsNullOrEmpty(pName.Text) && !string.IsNullOrEmpty(pPrice.Text) && !string.IsNullOrEmpty(pQty.Text))
                {
                    //Create a new Product
                    Product newProduct = new Product(pName.Text, Int32.Parse(pQty.Text), Double.Parse(pPrice.Text));
                    productList.Add(newProduct);

                    //Shows successful message
                    DisplayAlert("Done", "New Product Added Successfully!", "Ok");

                }
                else
                {
                    //Shows an error message
                    DisplayAlert("Error", "Please fill all the fields to add a new product", "Ok");
                }
            }
            //Reset the variables
            pName.Text = "";
            pPrice.Text = "";
            pQty.Text = "";
            
        }
    }
}