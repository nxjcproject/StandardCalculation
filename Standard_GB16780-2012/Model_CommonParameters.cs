using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Model_CommonParameters
    {
         private decimal _StandardCalorificValue;                                       //标准煤发热量
         private decimal _Altitude;                                                     //修正海拔高度
         private decimal _AtmosphericPressure;                                          //修正大气压强
         private decimal _Clinker_CompressiveStrength;                                  //修正熟料强度
         private decimal _Cement_CompressiveStrength;                                   //修正水泥强度
         private decimal _ElectricityToCoalFactor;                                      //电量标准煤转换系数

         public Model_CommonParameters()
         {
             _StandardCalorificValue = 0;                                       //标准煤发热量
             _Altitude = 0;                                                     //修正海拔高度
             _AtmosphericPressure = 0;                                          //修正大气压强
             _Clinker_CompressiveStrength = 0;                                  //修正熟料强度
             _Cement_CompressiveStrength = 0;                                   //修正水泥强度
             _ElectricityToCoalFactor = 0;                                      //电量标准煤转换系数

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
         public decimal Clinker_CompressiveStrength
         {
             get
             {
                 return _Clinker_CompressiveStrength;
             }
             set
             {
                 _Clinker_CompressiveStrength = value;
             }
         }
         public decimal Cement_CompressiveStrength
         {
             get
             {
                 return _Cement_CompressiveStrength;
             }
             set
             {
                 _Cement_CompressiveStrength = value;
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
         
    }
}
