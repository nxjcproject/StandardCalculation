using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Model_BaseELCParameters
    {
        private string _ProcessName;                                  //工序名称
        private string _MarterialsName;                               //物料名称
        private decimal _ProcessElectricityConsumption;               //工序电耗
        private decimal _ProcessMaterialsUsedQuantity;                //该工序物料使用量
        public Model_BaseELCParameters()
        {
            _ProcessName = "";
            _MarterialsName = "";
            _ProcessElectricityConsumption = 0;
            _ProcessMaterialsUsedQuantity = 0;
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
        public decimal ProcessElectricityConsumption
        {
            get
            {
                return _ProcessElectricityConsumption;
            }
            set
            {
                _ProcessElectricityConsumption = value;
            }
        }
        public decimal ProcessMaterialsUsedQuantity
        {
            get
            {
                return _ProcessMaterialsUsedQuantity;
            }
            set
            {
                _ProcessMaterialsUsedQuantity = value;
            }
        }

    }
    public class Model_BaseCLCParameters
    {
        private string _ProcessName;                                  //工序名称
        private string _MarterialsName;                               //物料名称
        private decimal _ProcessCoalConsumption;                      //工序煤耗
        private decimal _ProcessMaterialsUsedQuantity;                //该工序物料使用量
        private decimal _CoalWaterContent;                            //煤粉含水量
        private decimal _CoalLowCalorificValue;                       //实物煤低位发热量
        public Model_BaseCLCParameters()
        {
            _ProcessName = "";
            _MarterialsName = "";                               //物料名称
            _ProcessCoalConsumption = 0;
            _ProcessMaterialsUsedQuantity = 0;
            _CoalWaterContent = 0;
            _CoalLowCalorificValue = 0;
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
        public decimal ProcessCoalConsumption
        {
            get
            {
                return _ProcessCoalConsumption;
            }
            set
            {
                _ProcessCoalConsumption = value;
            }
        }
        public decimal ProcessMaterialsUsedQuantity
        {
            get
            {
                return _ProcessMaterialsUsedQuantity;
            }
            set
            {
                _ProcessMaterialsUsedQuantity = value;
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
