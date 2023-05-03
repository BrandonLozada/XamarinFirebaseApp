using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebaseApp.Views.Producto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductEntry : ContentPage
    {
        ProductRepository repository = new ProductRepository();
        public ProductEntry()
        {
            InitializeComponent();
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            string name = TxtName.Text;
            string cantidad = TxtCantidad.Text;
            if (string.IsNullOrEmpty(name))
            {
                await DisplayAlert("Warning", "Please enter your name", "Cancel");
            }
            if (string.IsNullOrEmpty(cantidad))
            {
                await DisplayAlert("Warning", "Please enter your email", "Cancel");
            }
            else
            {
                ProductoModel producto = new ProductoModel();
                producto.Nombre = name;
                producto.Cantidad = cantidad;

                var isSaved = await repository.Save(producto);
                if (isSaved)
                {
                    await DisplayAlert("Information", "Student has been saved.", "Ok");
                    Clear();
                }
                else
                {
                    await DisplayAlert("Error", "Student saved failed.", "Ok");
                }
            }
            

        }

        public void Clear()
        {
            TxtName.Text = string.Empty;
            TxtCantidad.Text = string.Empty;
        }
    }
}