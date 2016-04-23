using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Model_CogenerationProperties
    {
        private decimal _GrossGeneration;                //发电量
        private decimal _OwnDemand;                      //自用电量
        public Model_CogenerationProperties()
        {
            _GrossGeneration = 0;
            _OwnDemand = 0;
        }
        public decimal GrossGeneration
        {
            get
            {
                return _GrossGeneration;
            }
            set
            {
                _GrossGeneration = value;
            }
        }
        public decimal OwnDemand
        {
            get
            {
                return _OwnDemand;
            }
            set
            {
                _OwnDemand = value;
            }
        }
    } 
}
