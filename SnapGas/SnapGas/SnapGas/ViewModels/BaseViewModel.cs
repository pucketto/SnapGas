using SnapGas.Models;
using SnapGas.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SnapGas.ViewModels
{
    public class BaseViewModel : ObservableObject, IDisposable
    {
        private readonly IDependencyService _dependencyService;

        public BaseViewModel() : this(new DependencyServiceWrapper())
        {
        }

        public BaseViewModel(IDependencyService dependencyService)
        {
            if (dependencyService != null)
            {
                _dependencyService = dependencyService;
            }
            else
            {
                _dependencyService = new DependencyServiceWrapper();
            }
        }

        public LiteDBDataStore SnapGasDb => _dependencyService.Get<LiteDBDataStore>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public void Dispose()
        {
        }
    }
}

