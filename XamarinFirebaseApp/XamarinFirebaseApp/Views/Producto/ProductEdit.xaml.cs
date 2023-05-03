using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;


namespace XamarinFirebaseApp.Views.Producto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ProductEdit : ContentPage
    {
        MediaFile file;
        ProductRepository productRepository = new ProductRepository();

        public ProductEdit(ProductoModel product)
        {
            InitializeComponent();
            TxtName.Text = product.Nombre;
            TxtCantidad.Text = product.Cantidad;
            TxtId.Text = product.Id;
        }

        private async void ButtonUpdate_Clicked(object sender, EventArgs e)
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

            ProductoModel product = new ProductoModel();
            product.Id = TxtId.Text;
            product.Nombre = name;
            product.Cantidad = cantidad;
            if (file != null)
            {
                string image = await productRepository.Upload(file.GetStream(), Path.GetFileName(file.Path));
                product.Image = image;
            }
            bool isUpdated = await productRepository.Update(product);
            if (isUpdated)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "Update failed.", "Cancel");
            }

        }

        private async void ImageTap_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                });
                if (file == null)
                {
                    return;
                }
                StudentImage.Source = ImageSource.FromStream(() =>
                {
                    return file.GetStream();
                });
            }
            catch (Exception ex)
            {

            }
        }
    }
}