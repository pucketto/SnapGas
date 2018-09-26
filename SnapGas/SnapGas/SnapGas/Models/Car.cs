using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SnapGas.Models
{
    [Collection("Car")]
    public class Car : ObservableObject
    {
        private string id = string.Empty;
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string make = string.Empty;
        public string Make
        {
            get { return make; }
            set { SetProperty(ref make, value); }
        }

        private string model = string.Empty;
        public string Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }

        private decimal tankSize = 0.0m;
        public decimal TankSize
        {
            get { return tankSize; }
            set { SetProperty(ref tankSize, value); }
        }

        private decimal odometerReading = 0.0m;
        public decimal OdometerReading
        {
            get { return odometerReading; }
            set { SetProperty(ref odometerReading, value); }
        }

        private decimal avgMPG = 0.0m;
        public decimal AvgMPG
        {
            get { return avgMPG; }
            set { SetProperty(ref avgMPG, value); }
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        private bool notSelected = true;
        public bool NotSelected
        {
            get { return notSelected; }
            set { SetProperty(ref notSelected, value); }
        }


    }
}
