using SnapGas.Models;
using SnapGas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapGas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCarPage : ContentPage
	{
        AddCarViewModel viewModel;

		public AddCarPage (Car car)
		{
            this.Title = "Enter Car Information";
			InitializeComponent ();
            BindingContext = viewModel = new AddCarViewModel(car);
		}

        async void On_SaveTapped(object sender, EventArgs e)
        {
            this.viewModel.SaveCar();
            await this.Navigation.PopAsync();
        }
    }
}