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
                await DisplayAlert("Advertencia", "Por favor ingresa el Nombre del Producto", "Cancel");
            }
            if (string.IsNullOrEmpty(cantidad))
            {
                await DisplayAlert("Advertencia", "Por favor ingresa la Cantidad del Producto", "Cancel");
            }
            else
            {
                ProductoModel producto = new ProductoModel();
                producto.Nombre = name;
                producto.Cantidad = cantidad;

                var isSaved = await repository.Save(producto);
                if (isSaved)
                {
                    await DisplayAlert("Exito", "Producto añadido", "Ok");
                    Clear();
                }
                else
                {
                    await DisplayAlert("Error", "No se guardó el Producto", "Ok");
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