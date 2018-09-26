using SnapGas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.ViewModels
{
    public class CarsViewModel : BaseViewModel
    {
        private List<Car> myCars = new List<Car>();
        public List<Car> MyCars
        {
            get { return myCars; }
            set
            {
                SetProperty(ref myCars, value);
            }
        }

        private bool hasCars = false;
        public bool HasCars
        {
            get { return hasCars; }
            set
            {
                SetProperty(ref hasCars, value);
            }
        }

        private bool noCars = true;
        public bool NoCars
        {
            get { return noCars; }
            set
            {
                SetProperty(ref noCars, value);
            }
        }

        public CarsViewModel()
        {
            
        }

        public void LoadCars()
        {
            this.MyCars = this.SnapGasDb.Cars.ToList();
            if(this.MyCars.Count > 0)
            {
                this.HasCars = true;
                this.NoCars = false;
            }
            else
            {
                this.HasCars = false;
                this.NoCars = true;
            }
        }
    }
}
