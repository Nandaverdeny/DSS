using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PM.DSS.App.Entities;
using PM.DSS.App.Web.Context;
using PM.DSS.App.Web.Services;

namespace PM.DSS.App.Web.Services
{
    public class ReportService
    {
        private EntityContext _context = new EntityContext();
        private ArrayExtension _arrExt = new ArrayExtension();
        public ReportService()
        { }


        public AHPViewModel CalculateAHP(List<Criteria> listobj)
        {
            AHPViewModel result = new AHPViewModel();
            result.listRow = new List<RowViewModel>();

            double[,] arr = new double[3, 3] {
               { (listobj[0].Weight/listobj[0].Weight),(listobj[0].Weight/listobj[1].Weight),(listobj[0].Weight/listobj[2].Weight)},
               { (listobj[1].Weight/listobj[0].Weight),(listobj[1].Weight/listobj[1].Weight),(listobj[1].Weight/listobj[2].Weight)},
               { (listobj[2].Weight/listobj[0].Weight),(listobj[2].Weight/listobj[1].Weight),(listobj[2].Weight/listobj[2].Weight)}
            };

            double[] arrTotalVertical = new double[3] {
                (arr[0,0]+arr[1,0]+arr[2,0]), (arr[0,1]+arr[1,1]+arr[2,1]), (arr[2,0]+arr[2,1]+arr[2,2])
            };

            double[,] arrNormalisation = new double[3, 3] {
               { (arr[0,0]/arrTotalVertical[0]),(arr[0,1]/arrTotalVertical[1]),(arr[0,2]/arrTotalVertical[2])},
               { (arr[1,0]/arrTotalVertical[0]),(arr[1,1]/arrTotalVertical[1]),(arr[1,2]/arrTotalVertical[2])},
               { (arr[2,0]/arrTotalVertical[0]),(arr[2,1]/arrTotalVertical[1]),(arr[2,2]/arrTotalVertical[2])}
            };

            double[] arrTotalHorizontal = new double[3] {
                (arrNormalisation[0,0]+arrNormalisation[0,1]+arrNormalisation[0,2]), (arrNormalisation[1,0]+arrNormalisation[1,1]+arrNormalisation[1,2]), (arrNormalisation[2,0]+arrNormalisation[2,1]+arrNormalisation[2,2])
            };

            double[] arrAverage = new double[3] {
                (arrTotalHorizontal[0]/3), (arrTotalHorizontal[1]/3),(arrTotalHorizontal[2]/3)
            };

            result.listRow.Add(new RowViewModel{ Name = listobj[0].Name, Average = arrAverage[0], Total = arrTotalHorizontal[0] });
            result.listRow.Add(new RowViewModel { Name = listobj[1].Name, Average = arrAverage[1], Total = arrTotalHorizontal[1] });
            result.listRow.Add(new RowViewModel { Name = listobj[2].Name, Average = arrAverage[2], Total = arrTotalHorizontal[2] });
            result.EigenValue = (arrTotalHorizontal[0] * arrAverage[0]) + (arrTotalHorizontal[1] * arrAverage[1]) + (arrTotalHorizontal[2] * arrAverage[2]);
            result.ConsistencyIndex = (result.EigenValue - 3) / (3-1);
            result.ConsistencyRatio = result.ConsistencyIndex / 0.58;

            return result;
        }

        public AHPViewModel CalculateAHP(List<RowViewModel> listobj)
        {
            AHPViewModel result = new AHPViewModel();
            result.listRow = new List<RowViewModel>();

            double[,] arr = new double[3, 3] {
               { (listobj[0].Weight/listobj[0].Weight),(listobj[0].Weight/listobj[1].Weight),(listobj[0].Weight/listobj[2].Weight)},
               { (listobj[1].Weight/listobj[0].Weight),(listobj[1].Weight/listobj[1].Weight),(listobj[1].Weight/listobj[2].Weight)},
               { (listobj[2].Weight/listobj[0].Weight),(listobj[2].Weight/listobj[1].Weight),(listobj[2].Weight/listobj[2].Weight)}
            };

            double[] arrTotalVertical = new double[3] {
                (arr[0,0]+arr[1,0]+arr[2,0]), (arr[0,1]+arr[1,1]+arr[2,1]), (arr[2,0]+arr[2,1]+arr[2,2])
            };

            double[,] arrNormalisation = new double[3, 3] {
               { (arr[0,0]/arrTotalVertical[0]),(arr[0,1]/arrTotalVertical[1]),(arr[0,2]/arrTotalVertical[2])},
               { (arr[1,0]/arrTotalVertical[0]),(arr[1,1]/arrTotalVertical[1]),(arr[1,2]/arrTotalVertical[2])},
               { (arr[2,0]/arrTotalVertical[0]),(arr[2,1]/arrTotalVertical[1]),(arr[2,2]/arrTotalVertical[2])}
            };

            double[] arrTotalHorizontal = new double[3] {
                (arrNormalisation[0,0]+arrNormalisation[0,1]+arrNormalisation[0,2]), (arrNormalisation[1,0]+arrNormalisation[1,1]+arrNormalisation[1,2]), (arrNormalisation[2,0]+arrNormalisation[2,1]+arrNormalisation[2,2])
            };

            double[] arrAverage = new double[3] {
                (arrTotalHorizontal[0]/3), (arrTotalHorizontal[1]/3),(arrTotalHorizontal[2]/3)
            };

            result.listRow.Add(new RowViewModel { Name = listobj[0].Name, Average = arrAverage[0], Total = arrTotalHorizontal[0] });
            result.listRow.Add(new RowViewModel { Name = listobj[1].Name, Average = arrAverage[1], Total = arrTotalHorizontal[1] });
            result.listRow.Add(new RowViewModel { Name = listobj[2].Name, Average = arrAverage[2], Total = arrTotalHorizontal[2] });
            result.EigenValue = (arrTotalHorizontal[0] * arrAverage[0]) + (arrTotalHorizontal[1] * arrAverage[1]) + (arrTotalHorizontal[2] * arrAverage[2]);
            result.ConsistencyIndex = (result.EigenValue - 3) / (3 - 1);
            result.ConsistencyRatio = result.ConsistencyIndex / 0.58;

            return result;
        }

        public double GetReportCardPoint(decimal averageofReportCard)
        {
            double result = 0;
            if (averageofReportCard >= 9.0m)
            {
                result = 1.0;
            }
            else if (averageofReportCard >= 8.0m)
            {
                result = 0.9;
            }
            else if (averageofReportCard >= 7.0m)
            {
                result = 0.8;
            }
            else if (averageofReportCard >= 6.0m)
            {
                result = 0.7;
            }
            else if (averageofReportCard >= 5.0m)
            {
                result = 0.6;
            }
            else if (averageofReportCard >= 4.0m)
            {
                result = 0.5;
            }
            else if (averageofReportCard >= 3.0m)
            {
                result = 0.4;
            }
            else if (averageofReportCard >= 2.0m)
            {
                result = 0.3;
            }
            else if (averageofReportCard >= 1.0m)
            {
                result = 0.2;
            }
            return result;
        }

        public double GetNationalExamPoint(decimal averageofNationalExam)
        {
            double result = 0;
            if (averageofNationalExam >= 9.0m)
            {
                result = 1.0;
            }
            else if (averageofNationalExam >= 8.0m)
            {
                result = 0.9;
            }
            else if (averageofNationalExam >= 7.0m)
            {
                result = 0.8;
            }
            else if (averageofNationalExam >= 6.0m)
            {
                result = 0.7;
            }
            else if (averageofNationalExam >= 5.0m)
            {
                result = 0.6;
            }
            else if (averageofNationalExam >= 4.0m)
            {
                result = 0.5;
            }
            else if (averageofNationalExam >= 3.0m)
            {
                result = 0.4;
            }
            else if (averageofNationalExam >= 2.0m)
            {
                result = 0.3;
            }
            else if (averageofNationalExam >= 1.0m)
            {
                result = 0.2;
            }
            return result;
        }

        public double GetNonAcademicPoint(NonAcademicInformation obj)
        {
            double result = 0;

            switch (obj.Value)
            {
                case (1):
                    if (obj.NonAcademicCategory.Code == "National")
                        result = 1.0;
                    else if (obj.NonAcademicCategory.Code == "Province")
                        result = 0.9;
                    else if (obj.NonAcademicCategory.Code == "City")
                        result = 0.8;
                    break;
                case (2):
                    if (obj.NonAcademicCategory.Code == "National")
                        result = 0.7;
                    else if (obj.NonAcademicCategory.Code == "Province")
                        result = 0.6;
                    else if (obj.NonAcademicCategory.Code == "City")
                        result = 0.5;
                    break;
                case (3):
                    if (obj.NonAcademicCategory.Code == "National")
                        result = 0.4;
                    else if (obj.NonAcademicCategory.Code == "Province")
                        result = 0.3;
                    else if (obj.NonAcademicCategory.Code == "City")
                        result = 0.2;
                    break;
            }

            return result;
        }
    }
}