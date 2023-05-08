﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp.Views.Producto;
using XamarinFirebaseApp.Views.Student;
using XamarinFirebaseApp.Views.Proveedor;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            //LblUser.Text = Preferences.Get("userEmail", "default");
        }

        private void BtnStudentList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentListPage());
        }


        private void BtnProductsList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductListPage());
        }

        private void BtnProveedorList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProveedorListPage());
        }

        private void BtnChangePassword_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePassword());
        }

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}