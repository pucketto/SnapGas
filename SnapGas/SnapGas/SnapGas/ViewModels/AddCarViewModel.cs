using SnapGas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.ViewModels
{
    public class AddCarViewModel : BaseViewModel
    {
        public Car Car { get; set; }

        public AddCarViewModel(Car car)
        {
            this.Car = car;
        }

        public async void SaveCar()
        {
            if(this.Car.Id == null || this.Car.Id == string.Empty)
            {
                this.Car.Id = Guid.NewGuid().ToString();
            }

            this.SnapGasDb.Save<Car>(this.Car);
        }
    }
}
