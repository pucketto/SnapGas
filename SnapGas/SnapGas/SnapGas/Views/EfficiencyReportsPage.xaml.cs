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
	public partial class EfficiencyReportsPage : ContentPage
	{
        EfficiencyReportsViewModel viewModel;
        
		public EfficiencyReportsPage ()
		{
            viewModel = new EfficiencyReportsViewModel();
            InitializeComponent ();
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.viewModel.LoadEfficiencyReports();
        }

        async void On_AddClicked(object sender, EventArgs e)
        {
            if(this.viewModel.AddEnbled)
            {
                await this.Navigation.PushAsync(new AddEfficiencyReportPage());
            }
        }
    }
}