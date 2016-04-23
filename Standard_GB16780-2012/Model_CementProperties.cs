using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Model_CementProperties
    {
        private decimal _MarterialsOutput;         //水泥产量
        private decimal _ClinkerInput;             //熟料消耗量
        private decimal _Altitude;                 //海拔高度
        private decimal _AtmosphericPressure;      //大气压强
        private decimal _CompressiveStrength;       //熟料强度
        public Model_CementProperties()
        {
            _MarterialsOutput = 0m;              //水泥产量
            _ClinkerInput = 0m;
            _Altitude =0m;                       //海拔高度
            _AtmosphericPressure = 101325m;      //大气压强
            _CompressiveStrength = 52.5m;              //熟料强度
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
        public decimal ClinkerInput
        {
            get
            {
                return _ClinkerInput;
            }
            set
            {
                _ClinkerInput = value;
            }
        }
    }
}
