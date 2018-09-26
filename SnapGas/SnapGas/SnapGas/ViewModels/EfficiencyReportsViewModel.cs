using SnapGas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.ViewModels
{
    public class EfficiencyReportsViewModel : BaseViewModel
    {
        private List<EfficiencyReport> myEfficiencyReports = new List<EfficiencyReport>();
        public List<EfficiencyReport> MyEfficiencyReports
        {
            get { return myEfficiencyReports; }
            set
            {
                SetProperty(ref myEfficiencyReports, value);
            }
        }

        private bool addEnabled = false;
        public bool AddEnbled
        {
            get { return addEnabled; }
            set { SetProperty(ref addEnabled, value); }
        }

        private bool hasReports = false;
        public bool HasReports
        {
            get { return hasReports; }
            set
            {
                SetProperty(ref hasReports, value);
            }
        }

        private bool noReports = true;
        public bool NoReports
        {
            get { return noReports; }
            set
            {
                SetProperty(ref noReports, value);
            }
        }

        public Car SelectedCar { get; set; }
        public FuelingInstance SelectedFuelingInstance { get; set; }

        public EfficiencyReportsViewModel()
        {
            if (this.SnapGasDb.Cars.ToList().Count > 0 && this.SnapGasDb.FuelingInstances.ToList().Count > 0 )
            {
                var currentCar = this.SnapGasDb.Cars.Where(c => c.IsSelected == true).ToList();
                this.SelectedCar = currentCar[0];
                var currentFuelInstance = this.SnapGasDb.FuelingInstances.Where(f => f.IsSelected == true).ToList();
                this.SelectedFuelingInstance = currentFuelInstance[0];

                if (currentCar.Count == 1 && currentFuelInstance.Count == 1)
                {
                    var reports = this.SnapGasDb.EfficiencyReports
                        .Where(r => r.CarId == this.SelectedCar.Id && r.FuelInstanceId == this.SelectedFuelingInstance.Id).ToList();
                    if(reports.Count == 0)
                    {
                        this.AddEnbled = true;
                    }
                }
            }
        }

        public void LoadEfficiencyReports()
        {
            //if (this.SnapGasDb.Cars.ToList().Count > 0 && this.SnapGasDb.FuelingInstances.ToList().Count > 0)
            //{
            //    this.MyEfficiencyReports = this.SnapGasDb.EfficiencyReports
            //        .Where(rep => rep.CarId == this.SelectedCar.Id && rep.FuelInstanceId == this.SelectedFuelingInstance.Id).ToList();
            //}
            if(this.SnapGasDb.Cars.ToList().Count > 0)
            {
                this.MyEfficiencyReports = this.SnapGasDb.EfficiencyReports.Where(rep => rep.CarId == this.SelectedCar.Id).ToList();
            }
            else
            {
                this.MyEfficiencyReports = this.SnapGasDb.EfficiencyReports.ToList();
            }

            if (this.MyEfficiencyReports.Count > 0)
            {
                this.HasReports = true;
                this.NoReports = false;
            }
            else
            {
                this.HasReports = false;
                this.NoReports = true;
            }
        }

    }
}
