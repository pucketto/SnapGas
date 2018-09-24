using SnapGas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private List<Car> cars = new List<Car>();
        public List<Car> Cars
        {
            get { return cars; }
            set
            {
                SetProperty(ref cars, value);
            }
        }

        private List<FuelingInstance> fuelInstances = new List<FuelingInstance>();
        public List<FuelingInstance> FuelInstances
        {
            get { return fuelInstances; }
            set
            {
                SetProperty(ref fuelInstances, value);
            }
        }

        private List<EfficiencyReport> efficiencyReports = new List<EfficiencyReport>();
        public List<EfficiencyReport> EfficiencyReports
        {
            get { return efficiencyReports; }
            set
            {
                SetProperty(ref efficiencyReports, value);
            }
        }

        private int totalCars = 0;
        public int TotalCars
        {
            get { return totalCars; }
            set { SetProperty(ref totalCars, value); }
        }

        private int totalFuelInstances = 0;
        public int TotalFuelInstances
        {
            get { return totalFuelInstances; }
            set { SetProperty(ref totalFuelInstances, value); }
        }

        private int totalEfficiencyReports = 0;
        public int TotalEfficiencyReports
        {
            get { return totalEfficiencyReports; }
            set { SetProperty(ref totalEfficiencyReports, value); }
        }

        public DashboardViewModel()
        {

        }

        public void LoadData()
        {
            this.Cars = this.SnapGasDb.Cars.ToList();
            this.FuelInstances = this.SnapGasDb.FuelingInstances.ToList();
            this.EfficiencyReports = this.SnapGasDb.EfficiencyReports.ToList();

            this.TotalCars = this.Cars.Count;
            this.TotalFuelInstances = this.FuelInstances.Count;
            this.TotalEfficiencyReports = this.EfficiencyReports.Count;
        }
    }
}
