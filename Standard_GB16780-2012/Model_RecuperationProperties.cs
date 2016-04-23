using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Model_RecuperationProperties
    {
        private decimal _ImportHeat;       //进口热量
        private decimal _ExportHeat;       //出口热量
        private decimal _LossHeat;         //损失热量
        public Model_RecuperationProperties()
        {
            _ImportHeat = 0;
            _ExportHeat = 0;
            _LossHeat = 0;
        }
        public decimal ImportHeat
        {
            get
            {
                return _ImportHeat;
            }
            set
            {
                _ImportHeat = value;
            }
        }
        public decimal ExportHeat
        {
            get
            {
                return _ExportHeat;
            }
            set
            {
                _ExportHeat = value;
            }
        }
        public decimal LossHeat
        {
            get
            {
                return _LossHeat;
            }
            set
            {
                _LossHeat = value;
            }
        }
    }
}
