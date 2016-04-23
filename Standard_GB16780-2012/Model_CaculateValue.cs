using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Standard_GB16780_2012
{
    public class Model_CaculateValue
    {
        private string _CaculateName;     //计算名称
        private string _CaculateFormula;  //计算公式
        private decimal _CaculateValue;   //计算值
        //private string _TargetMaterialName;   //目标物料名称
        //private decimal _TargetMaterialWeight;
        private List<Model_CaculateFactor> _CaculateFactor;    //计算过程因数
        public Model_CaculateValue()
        {
            _CaculateName = "";
            _CaculateFormula = "";
            _CaculateValue = 0.0m;
            _CaculateFactor = new List<Model_CaculateFactor>();
        }
        public string CaculateName
        {
            get
            {
                return _CaculateName;
            }
            set
            {
                _CaculateName = value;
            }
        }
        public string CaculateFormula
        {
            get
            {
                return _CaculateFormula;
            }
            set
            {
                _CaculateFormula = value;
            }
        }
        public decimal CaculateValue
        {
            get
            {
                return _CaculateValue;
            }
            set
            {
                _CaculateValue = value;
            }
        }
        public List<Model_CaculateFactor> CaculateFactor
        {
            get
            {
                return _CaculateFactor;
            }
            set
            {
                _CaculateFactor = value;
            }
        }
    }
    public class Model_CaculateFactor
    {
        private string _FactorName;
        private decimal _FactorValue;
        private decimal _FactorUsedValue;
        private string _FactorValueType;        //Quantity电量或者耗煤量,Consumption表示电耗或者煤耗
        public Model_CaculateFactor()
        {
            _FactorName = "";
            _FactorValue = 0.0m;
            _FactorUsedValue = 1;
            _FactorValueType = "Consumption";
        }
        public string FactorName
        {
            get
            {
                return _FactorName;
            }
            set
            {
                _FactorName = value;
            }
        }
        public decimal FactorValue
        {
            get
            {
                return _FactorValue;
            }
            set
            {
                _FactorValue = value;
            }
        }
        public decimal FactorUsedValue
        {
            get
            {
                return _FactorUsedValue;
            }
            set
            {
                _FactorUsedValue = value;
            }
        }
        public string FactorValueType
        {
            get
            {
                return _FactorValueType;
            }
            set
            {
                _FactorValueType = value;
            }
        }
    }
}
