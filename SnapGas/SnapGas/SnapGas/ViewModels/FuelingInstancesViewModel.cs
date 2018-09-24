using SnapGas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.ViewModels
{
    public class FuelingInstancesViewModel : BaseViewModel
    {
        private List<FuelingInstance> myFuelingInstances = new List<FuelingInstance>();
        public List<FuelingInstance> MyFuelingInstances
        {
            get { return myFuelingInstances; }
            set
            {
                SetProperty(ref myFuelingInstances, value);
            }
        }

        private bool addEnabled = false;
        public bool AddEnbled
        {
            get { return addEnabled; }
            set { SetProperty(ref addEnabled, value); }
        }

        private bool hasFuelingInstances = false;
        public bool HasFuelingInstances
        {
            get { return hasFuelingInstances; }
            set
            {
                SetProperty(ref hasFuelingInstances, value);
            }
        }

        private bool noFuelingInstances = true;
        public bool NoFuelingInstances
        {
            get { return noFuelingInstances; }
            set
            {
                SetProperty(ref noFuelingInstances, value);
            }
        }

        public Car SelectedCar { get; set; }

        public FuelingInstancesViewModel()
        {
            if(this.SnapGasDb.Cars.ToList().Count > 0)
            {
                var currentCar = this.SnapGasDb.Cars.Where(c => c.IsSelected == true).ToList();
                this.SelectedCar = currentCar[0];
                if (currentCar.Count == 1)
                {
                    this.AddEnbled = true;
                }
            }
           
        }

        public void LoadFuelingInstances()
        {
            if(this.SnapGasDb.Cars.ToList().Count > 0)
            {
                this.MyFuelingInstances = this.SnapGasDb.FuelingInstances.Where(inst => inst.CarId == this.SelectedCar.Id).ToList();
            }
            else
            {
                this.MyFuelingInstances = this.SnapGasDb.FuelingInstances.ToList();
            }

            if (this.MyFuelingInstances.Count > 0)
            {
                this.HasFuelingInstances = true;
                this.NoFuelingInstances = false;
            }
            else
            {
                this.HasFuelingInstances = false;
                this.NoFuelingInstances = true;
            }
        }
    }
}
