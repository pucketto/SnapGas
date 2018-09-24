using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.Models
{
    [Collection("FuelingInstance")]
    public class FuelingInstance : ObservableObject
    {
        private string id = string.Empty;
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string carId = string.Empty;
        public string CarId
        {
            get { return carId; }
            set { SetProperty(ref carId, value); }
        }

        private decimal amountFilled = 0.0m;
        public decimal AmountFilled
        {
            get { return amountFilled; }
            set { SetProperty(ref amountFilled, value); }
        }

        private decimal distance = 0.0m;
        public decimal Distance
        {
            get { return distance; }
            set { SetProperty(ref distance, value); }
        }

        private decimal newOdometerReading = 0.0m;
        public decimal NewOdometerReading
        {
            get { return newOdometerReading; }
            set { SetProperty(ref newOdometerReading, value); }
        }

        //private float efficiency;
        //public float Efficienicy
        //{
        //    get { return efficiency; }
        //    set { SetProperty(ref efficiency, value); }
        //}

        private decimal price = 0.0m;
        public decimal Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private DateTime dateFilled;
        public DateTime DateFilled
        {
            get { return dateFilled; }
            set { SetProperty(ref dateFilled, value); }
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
