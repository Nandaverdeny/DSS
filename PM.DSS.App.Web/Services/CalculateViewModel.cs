using System.Collections.Generic;

namespace PM.DSS.App.Web.Services
{
    public class AHPViewModel
    {
        public List<RowViewModel> listRow { get; set; }
        public double EigenValue { get; set; }
        public double ConsistencyIndex { get; set; }
        public double ConsistencyRatio { get; set; }
    }

    public class RowViewModel
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Total { get; set; }
        public double Average { get; set; }
    }
}