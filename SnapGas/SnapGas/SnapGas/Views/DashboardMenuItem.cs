using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapGas.Views
{

    public class DashboardMenuItem
    {
        public DashboardMenuItem()
        {
            TargetType = typeof(DashboardDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public string Icon { get; set; }

        public Type TargetType { get; set; }
    }
}