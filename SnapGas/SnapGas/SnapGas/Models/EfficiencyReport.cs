using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.Models
{
    [Collection("EfficiencyReport")]
    public class EfficiencyReport : ObservableObject
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

        private string fuelInstanceId = string.Empty;
        public string FuelInstanceId
        {
            get { return fuelInstanceId; }
            set { SetProperty(ref fuelInstanceId, value); }
        }

        private decimal calculatedEfficiency;
        public decimal CalculatedEfficiency
        {
            get { return calculatedEfficiency; }
            set { SetProperty(ref calculatedEfficiency, value); }
        }

        private DateTime dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { SetProperty(ref dateCreated, value); }
        }

        //private float amountSpent;
        //public float AmountSpent
        //{
        //    get { return amountSpent; }
        //    set { SetProperty(ref amountSpent, value); }
        //}

        //private float amountFilled;
        //public float AmountFilled
        //{
        //    get { return amountFilled; }
        //    set { SetProperty(ref amountFilled, value); }
        //}
    }
}
