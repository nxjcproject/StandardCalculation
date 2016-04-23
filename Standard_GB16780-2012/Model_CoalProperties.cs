using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Model_CoalProperties
    {
        //private decimal _CoalOutput;                           //煤粉产量
        //private decimal _CoalInput;                            //煤粉耗量
        private decimal _CoalWaterContent;                     //煤粉含水量
        private decimal _CoalLowCalorificValue;                //实物煤低位发热量
        public Model_CoalProperties()
        {
            //_CoalOutput = 0;
            //_CoalInput = 0;
            _CoalWaterContent = 0;
            _CoalLowCalorificValue = 0;
        }
        //public decimal CoalOutput
        //{
        //    get
        //    {
        //        return _CoalOutput;
        //    }
        //    set
        //    {
        //        _CoalOutput = value;
        //    }
        //}
        //public decimal CoalInput
        //{
        //    get
        //    {
        //        return _CoalInput;
        //    }
        //    set
        //    {
        //        _CoalInput = value;
        //    }
        //}
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
        public decimal CoalLowCalorificValue
        {
            get
            {
                return _CoalLowCalorificValue;
            }
            set
            {
                _CoalLowCalorificValue = value;
            }
        }
    }
}
