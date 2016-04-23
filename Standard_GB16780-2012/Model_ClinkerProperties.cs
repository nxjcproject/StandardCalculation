using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Model_ClinkerProperties
    {
        private decimal _MarterialsOutput;         //熟料产量
        private decimal _MarterialsOutsourcing;    //熟料外购量
        private decimal _Altitude;                 //海拔高度
        private decimal _AtmosphericPressure;      //大气压强
        private decimal _CompressiveStrength;      //熟料强度
        private decimal _ClinkerOutsourcing_PowerConsumption;                          //外购熟料平均电耗
        private decimal _ClinkerOutsourcing_CoalConsumption;                           //外购熟料平均煤耗
        public Model_ClinkerProperties()
        {
            _MarterialsOutput = 0m;                  //熟料产量
            _MarterialsOutsourcing = 0m;             //熟料外购量
            //_MarterialsInput = 0m;                   //熟料消耗量
            _Altitude =0m;                           //海拔高度
            _AtmosphericPressure = 101325m;          //大气压强
            _CompressiveStrength = 52.5m;              //熟料强度
            _ClinkerOutsourcing_PowerConsumption = 0;                                    //外购熟料平均电耗
            _ClinkerOutsourcing_CoalConsumption = 0;                                     //外购熟料平均煤耗
        }
        public decimal MarterialsOutput
        {
            get
            {
                return _MarterialsOutput;
            }
            set
            {
                _MarterialsOutput = value;
            }
        }
        public decimal Altitude
        {
            get
            {
                return _Altitude;
            }
            set
            {
                _Altitude = value;
            }
        }
        public decimal AtmosphericPressure
        {
            get
            {
                return _AtmosphericPressure;
            }
            set
            {
                _AtmosphericPressure = value;
            }
        }
        public decimal CompressiveStrength
        {
            get
            {
                return _CompressiveStrength;
            }
            set
            {
                _CompressiveStrength = value;
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
        public decimal MarterialsOutsourcing
        {
            get
            {
                return _MarterialsOutsourcing;
            }
            set
            {
                _MarterialsOutsourcing = value;
            }
        }
    }
}
