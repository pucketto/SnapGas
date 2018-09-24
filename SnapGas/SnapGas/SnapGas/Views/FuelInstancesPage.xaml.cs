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
	public partial class FuelInstancesPage : ContentPage
	{
        FuelingInstancesViewModel viewModel;

		public FuelInstancesPage ()
		{
            viewModel = new FuelingInstancesViewModel();
            this.viewModel.LoadFuelingInstances();
			InitializeComponent ();
            BindingContext = this.viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadFuelingInstances();
        }

        async void On_FuelInstanceSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var fuelInstance = args.SelectedItem as FuelingInstance;
            fuelInstance.IsSelected = true;
            fuelInstance.NotSelected = false;
            this.viewModel.SnapGasDb.Save<FuelingInstance>(fuelInstance);
            foreach (FuelingInstance f in viewModel.MyFuelingInstances.Where(f => f.Id != fuelInstance.Id))
            {
                f.NotSelected = true;
                f.IsSelected = false;
                this.viewModel.SnapGasDb.Save<FuelingInstance>(f);
            }
            this.OnAppearing();
        }

        async void On_RemoveClicked(object sender, EventArgs e)
        {
            //var menuItem = (MenuItem)sender;
            //var reminder = (Car)menuItem.CommandParameter;
            //this.viewModel.SnapGasDb.
            //return;
        }

        async void On_AddClicked(object sender, EventArgs e)
        {
            if(this.viewModel.AddEnbled)
            {
                await this.Navigation.PushAsync(new AddFuelInstancePage(new FuelingInstance()));
            }
        }
    }
}