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
	public partial class DashboardPage : ContentPage
	{
        DashboardViewModel viewModel;

        public DashboardPage ()
		{
            this.Title = "Home";
            this.viewModel = new DashboardViewModel();
            this.viewModel.LoadData();
            InitializeComponent ();
            BindingContext = this.viewModel;
		}

        protected override void OnAppearing()
        {
            this.viewModel.LoadData();
        }
    }
}