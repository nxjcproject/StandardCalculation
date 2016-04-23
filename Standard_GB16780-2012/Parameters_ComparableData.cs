using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Parameters_ComparableData
    {
        private decimal _Clinker_ActualAltitude;                         //熟料实际海拔高度
        private decimal _Cement_ActualAltitude;                          //水泥实际海拔高度
        private decimal _Clinker_ActualAtmosphericPressure;              //熟料实际大气压强
        private decimal _Cement_ActualAtmosphericPressure;               //水泥实际大气压强
        private decimal _ClinkerOutsourcing_PowerConsumption;    //外购熟料综合电耗
        private decimal _ClinkerOutsourcing_CoalConsumption;     //外购熟料综合煤耗
        private decimal _ClinkerCompressiveStrength;             //熟料28d抗压强度

        private decimal _CementCompressiveStrength;              //水泥磨强度

        private decimal _CoalLowCalorificValue;                  //煤粉低位发热量
        private decimal _CoalWaterContent;                       //煤粉水分

        private decimal _RecuperationExportHeat;                 //余热利用出口热量
        private decimal _RecuperationImportHeat;                 //余热利用进口热量
        private decimal _RecuperationLossHeat;                   //余热利用损失热量

        private decimal _CorrectedAltitude;                      //修正海拔高度
        private decimal _StandardAtmosphericPressure;            //标准大气压强
        private decimal _Cement_CorrectedCompressiveStrength;    //水泥修正强度
        private decimal _Clinker_CorrectedCompressiveStrength;   //熟料修正强度
        private decimal _ElectricityToCoalFactor;                //用电折合用煤系数
        private decimal _StandardCalorificValue;                 //标准煤发热量
        public Parameters_ComparableData()
        {
            _Clinker_ActualAltitude = 0;                         //熟料实际海拔高度
            _Cement_ActualAltitude = 0;                          //水泥实际海拔高度
            _Clinker_ActualAtmosphericPressure = 101325m;              //熟料实际大气压强
            _Cement_ActualAtmosphericPressure = 101325m;               //水泥实际大气压强
            _ClinkerOutsourcing_PowerConsumption = 0;    //外购熟料综合电耗
            _ClinkerOutsourcing_CoalConsumption = 0;     //外购熟料综合煤耗
            _ClinkerCompressiveStrength = 0;             //熟料28d抗压强度

            _CementCompressiveStrength = 0;              //水泥磨强度

            _CoalLowCalorificValue = 0;                  //煤粉低位发热量
            _CoalWaterContent = 0;                       //煤粉水分

            _RecuperationExportHeat = 0;                 //余热利用出口热量
            _RecuperationImportHeat = 0;                 //余热利用进口热量
            _RecuperationLossHeat = 0;                   //余热利用损失热量

            _CorrectedAltitude = 0;                      //修正海拔高度
            _StandardAtmosphericPressure = 0;            //标准大气压强
            _Cement_CorrectedCompressiveStrength = 0;    //水泥修正强度
            _Clinker_CorrectedCompressiveStrength = 0;   //熟料修正强度
            _ElectricityToCoalFactor = 0;                //用电折合用煤系数
            _StandardCalorificValue = 0;                 //标准煤发热量
        }
        public decimal Clinker_ActualAltitude
        {
            get
            {
                return _Clinker_ActualAltitude;
            }
            set
            {
                _Clinker_ActualAltitude = value;
            }
        }
        public decimal Cement_ActualAltitude
        {
            get
            {
                return _Cement_ActualAltitude;
            }
            set
            {
                _Cement_ActualAltitude = value;
            }
        }
        public decimal Clinker_ActualAtmosphericPressure
        {
            get
            {
                return _Clinker_ActualAtmosphericPressure;
            }
            set
            {
                _Clinker_ActualAtmosphericPressure = value;
            }
        }
        public decimal Cement_ActualAtmosphericPressure
        {
            get
            {
                return _Cement_ActualAtmosphericPressure;
            }
            set
            {
                _Cement_ActualAtmosphericPressure = value;
            }
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
        public decimal ClinkerCompressiveStrength
        {
            get
            {
                return _ClinkerCompressiveStrength;
            }
            set
            {
                _ClinkerCompressiveStrength = value;
            }
        }

        public decimal CementCompressiveStrength
        {
            get
            {
                return _CementCompressiveStrength;
            }
            set
            {
                _CementCompressiveStrength = value;
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
        public decimal RecuperationExportHeat
        {
            get
            {
                return _RecuperationExportHeat;
            }
            set
            {
                _RecuperationExportHeat = value;
            }
        }
        public decimal RecuperationImportHeat
        {
            get
            {
                return _RecuperationImportHeat;
            }
            set
            {
                _RecuperationImportHeat = value;
            }
        }
        public decimal RecuperationLossHeat
        {
            get
            {
                return _RecuperationLossHeat;
            }
            set
            {
                _RecuperationLossHeat = value;
            }
        }

        public decimal CorrectedAltitude
        {
            get
            {
                return _CorrectedAltitude;
            }
            set
            {
                _CorrectedAltitude = value;
            }
        }
        public decimal StandardAtmosphericPressure
        {
            get
            {
                return _StandardAtmosphericPressure;
            }
            set
            {
                _StandardAtmosphericPressure = value;
            }
        }
        public decimal Cement_CorrectedCompressiveStrength
        {
            get
            {
                return _Cement_CorrectedCompressiveStrength;
            }
            set
            {
                _Cement_CorrectedCompressiveStrength = value;
            }
        }
        public decimal Clinker_CorrectedCompressiveStrength
        {
            get
            {
                return _Clinker_CorrectedCompressiveStrength;
            }
            set
            {
                _Clinker_CorrectedCompressiveStrength = value;
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
