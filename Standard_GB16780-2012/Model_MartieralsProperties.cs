using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Model_MartieralsProperties
    {
        private string _ProcessName;                                //所属工序名称
        private string _MarterialsName;                              //物料名称
        private decimal _MarterialsOutput;                           //物料产量
        private decimal _MarterialsInput;                            //物料耗量
        private decimal _MarterialsWaterContent;                     //物料含水量
        private decimal _ElectricityQuantity;                        //物料工序电量
        private decimal _CoalQuantity;                               //物料工序煤量
        public Model_MartieralsProperties()
        {
            _ProcessName = "";
            _MarterialsName = "";
            _MarterialsOutput = 0;
            _MarterialsInput = 0;
            _MarterialsWaterContent = 0;
            _ElectricityQuantity = 0;
            _CoalQuantity = 0;
        }
        public string ProcessName
        {
            get
            {
                return _ProcessName;
            }
            set
            {
                _ProcessName = value;
            }
        }
        public string MarterialsName
        {
            get
            {
                return _MarterialsName;
            }
            set
            {
                _MarterialsName = value;
            }
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
        public decimal MarterialsInput
        {
            get
            {
                return _MarterialsInput;
            }
            set
            {
                _MarterialsInput = value;
            }
        }
        public decimal MarterialsWaterContent
        {
            get
            {
                return _MarterialsWaterContent;
            }
            set
            {
                _MarterialsWaterContent = value;
            }
        }
        public decimal ElectricityQuantity
        {
            get
            {
                return _ElectricityQuantity;
            }
            set
            {
                _ElectricityQuantity = value;
            }
        }
        public decimal CoalQuantity
        {
            get
            {
                return _CoalQuantity;
            }
            set
            {
                _CoalQuantity = value;
            }
        }
    }

}
