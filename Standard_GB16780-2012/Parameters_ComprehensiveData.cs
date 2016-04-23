using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Parameters_ComprehensiveData
    {
        //private decimal _ActualAltitude;                         //实际海拔高度
        //private decimal _ActualAtmosphericPressure;              //实际大气压强
        private decimal _ClinkerOutsourcing_PowerConsumption;    //外购熟料综合电耗
        private decimal _ClinkerOutsourcing_CoalConsumption;     //外购熟料综合煤耗
        //private decimal _ClinkerCompressiveStrength;             //熟料28d抗压强度
        //private decimal _ClinkerMarterialsOutput;                //熟料产量

        //private decimal _CementCompressiveStrength;              //水泥磨强度
        //private decimal _CementMarterialsOutput;                 //水泥产量

        private decimal _CoalLowCalorificValue;                  //煤粉低位发热量
        private decimal _CoalWaterContent;                       //煤粉水分

        //private decimal _RecuperationExportHeat;                 //余热利用出口热量
        //private decimal _RecuperationImportHeat;                 //余热利用进口热量
        //private decimal _RecuperationLossHeat;                   //余热利用损失热量

       // private decimal _CorrectedAltitude;                      //修正海拔高度
        //private decimal _StandardAtmosphericPressure;            //标准大气压强
        //private decimal _Cement_CorrectedCompressiveStrength;    //水泥修正强度
        //private decimal _Clinker_CorrectedCompressiveStrength;   //熟料修正强度
        private decimal _ElectricityToCoalFactor;                //用电折合用煤系数
        private decimal _StandardCalorificValue;                 //标准煤发热量
        public Parameters_ComprehensiveData()
        {

                _ClinkerOutsourcing_PowerConsumption = 0;    //外购熟料综合电耗
                _ClinkerOutsourcing_CoalConsumption = 0;     //外购熟料综合煤耗


                _CoalLowCalorificValue = 0;                  //煤粉低位发热量
                _CoalWaterContent = 0;                       //煤粉水分

                _ElectricityToCoalFactor = 0;                //用电折合用煤系数
                _StandardCalorificValue = 0;                 //标准煤发热量
        }

        public decimal ClinkerOutsourcing_PowerConsumption
        {
            get
            {
                return _ClinkerOutsourcing_PowerConsumption;
            }
            set
            {
                _ClinkerOutsourcing_PowerConsumption = value;
            }
        }
        public decimal ClinkerOutsourcing_CoalConsumption
        {
            get
            {
                return _ClinkerOutsourcing_CoalConsumption;
            }
            set
            {
                _ClinkerOutsourcing_CoalConsumption = value;
            }
        }

        public decimal CoalLowCalorificValue
        {
            get
            {
                return _CoalLowCalorificValue;
            }
            set
            {
                _CoalLowCalorificValue = value; ;
            }
        }
        public decimal CoalWaterContent
        {
            get
            {
                return _CoalWaterContent;
            }
            set
            {
                _CoalWaterContent = value;
            }
        }
        public decimal ElectricityToCoalFactor
        {
            get
            {
                return _ElectricityToCoalFactor;
            }
            set
            {
                _ElectricityToCoalFactor = value;
            }
        }
        public decimal StandardCalorificValue
        {
            get
            {
                return _StandardCalorificValue;
            }
            set
            {
                _StandardCalorificValue = value;
            }
        }

    }
}
