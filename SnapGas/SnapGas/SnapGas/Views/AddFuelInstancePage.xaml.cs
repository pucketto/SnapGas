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
	public partial class AddFuelInstancePage : ContentPage
	{
        AddFuelInstanceViewModel viewModel;

		public AddFuelInstancePage (FuelingInstance fuelingInstance)
		{
            this.viewModel = new AddFuelInstanceViewModel(fuelingInstance);

            if(this.viewModel.SelectedCar != null)
            {
                this.Title = this.viewModel.SelectedCar.Make + " " + this.viewModel.SelectedCar.Model;
            }

            InitializeComponent ();
            BindingContext = this.viewModel;
		}

        async void On_SaveTapped(object sender, EventArgs e)
        {
            this.viewModel.SaveFuelingInstance();
            await this.Navigation.PopAsync();
        }
    }
}