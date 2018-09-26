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
	public partial class AddEfficiencyReportPage : ContentPage
	{
        AddEfficiencyReportViewModel viewModel;

		public AddEfficiencyReportPage ()
		{
            this.viewModel = new AddEfficiencyReportViewModel(new EfficiencyReport());
			InitializeComponent ();
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.viewModel.CalcEfficiency();
        }

        async void On_SaveTapped(object sender, EventArgs e)
        {
            this.viewModel.SaveEfficiencyReport();
            await this.Navigation.PopAsync();
        }
    }
}