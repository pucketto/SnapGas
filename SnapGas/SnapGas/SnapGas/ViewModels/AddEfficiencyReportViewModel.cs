using SnapGas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.ViewModels
{
    public class AddEfficiencyReportViewModel : BaseViewModel
    {
        public EfficiencyReport EfficiencyReport { get; set; }
        public FuelingInstance SelectedFuelingInstance { get; set; }
        public Car SelectedCar { get; set; }

        public AddEfficiencyReportViewModel(EfficiencyReport efficiency)
        {
            this.SelectedCar = this.SnapGasDb.Cars.Where(c => c.IsSelected == true).FirstOrDefault();
            this.SelectedFuelingInstance = this.SnapGasDb.FuelingInstances.Where(f => f.IsSelected == true).FirstOrDefault();

            this.EfficiencyReport = efficiency;
        }

        public void CalcEfficiency()
        {
            this.EfficiencyReport.CalculatedEfficiency = this.SelectedFuelingInstance.Distance / this.SelectedFuelingInstance.AmountFilled;
        }

        public async void SaveEfficiencyReport()
        {
            if (this.EfficiencyReport.Id == null || this.EfficiencyReport.Id == string.Empty)
            {
                this.EfficiencyReport.Id = Guid.NewGuid().ToString();
            }
            this.EfficiencyReport.CarId = this.SelectedCar.Id;
            this.EfficiencyReport.FuelInstanceId = this.SelectedFuelingInstance.Id;
            this.EfficiencyReport.DateCreated = DateTime.Now;
            this.SnapGasDb.Save<EfficiencyReport>(this.EfficiencyReport);
        }
    }
}
