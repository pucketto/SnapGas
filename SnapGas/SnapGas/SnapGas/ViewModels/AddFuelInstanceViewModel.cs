using SnapGas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.ViewModels
{
    public class AddFuelInstanceViewModel : BaseViewModel
    {
        public FuelingInstance FuelingInstance { get; set; }
        public Car SelectedCar { get; set; }

        //private bool addEnabled = false;
        //public bool AddEnbled
        //{
        //    get { return addEnabled; }
        //    set { SetProperty(ref addEnabled, value); }
        //}

        public AddFuelInstanceViewModel(FuelingInstance fuelingInstance)
        {
            this.SelectedCar = this.SnapGasDb.Cars.Where(c => c.IsSelected == true).FirstOrDefault();

            this.FuelingInstance = fuelingInstance;
        }

        public async void SaveFuelingInstance()
        {
            if (this.FuelingInstance.Id == null || this.FuelingInstance.Id == string.Empty)
            {
                this.FuelingInstance.Id = Guid.NewGuid().ToString();
            }
            this.FuelingInstance.CarId = this.SelectedCar.Id;
            this.FuelingInstance.DateFilled = DateTime.Now;
            this.FuelingInstance.Distance = this.FuelingInstance.NewOdometerReading - this.SelectedCar.OdometerReading;
            this.SnapGasDb.Save<FuelingInstance>(this.FuelingInstance);
            this.SelectedCar.OdometerReading = this.FuelingInstance.NewOdometerReading;
            this.SnapGasDb.Save<Car>(this.SelectedCar);
        }
    }
}
