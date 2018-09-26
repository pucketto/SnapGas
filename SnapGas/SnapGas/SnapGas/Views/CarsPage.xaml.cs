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
	public partial class CarsPage : ContentPage
	{
        public CarsViewModel viewModel;

		public CarsPage ()
		{
            viewModel = new CarsViewModel();
            viewModel.LoadCars();
			InitializeComponent ();
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCars();
        }

        async void On_CarSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var car = args.SelectedItem as Car;
            car.IsSelected = true;
            car.NotSelected = false;
            this.viewModel.SnapGasDb.Save<Car>(car);
            foreach (Car c in viewModel.MyCars.Where(c => c.Id != car.Id))
            {
                c.NotSelected = true;
                c.IsSelected = false;
                this.viewModel.SnapGasDb.Save<Car>(c);
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
            await this.Navigation.PushAsync(new AddCarPage(new Car()));
        }
    }
}