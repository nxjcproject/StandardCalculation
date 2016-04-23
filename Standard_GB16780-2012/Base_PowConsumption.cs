using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Base_PowConsumption
    {
        /// <summary>
        /// 计算电耗
        /// </summary>
        /// <param name="myELCParameters">电耗参数</param>
        /// <param name="myMarterialsOutput">需要计算综合电耗的物料产量</param>
        /// <returns>电耗</returns>
        public Model_CaculateValue GetPowerConsumption(List<Model_BaseELCParameters> myELCParameters, decimal myMarterialsOutput, string myStaticsMarterialsName)
        {
            decimal m_PowerConsumption = 0;
            decimal m_UsedElectricity = 0;
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            if (myELCParameters != null)
            {
                for (int i = 0; i < myELCParameters.Count; i++)
                {
                    m_UsedElectricity = m_UsedElectricity + myELCParameters[i].ProcessElectricityConsumption * myELCParameters[i].ProcessMaterialsUsedQuantity;
                    if(i==0)
                    {
                        if (myELCParameters[i].ProcessMaterialsUsedQuantity == 1)
                        {
                            m_Model_CaculateValue.CaculateFormula = myELCParameters[i].ProcessName + "耗电量";
                        }
                        else
                        {
                            m_Model_CaculateValue.CaculateFormula = myELCParameters[i].ProcessName + "电耗 * " + myELCParameters[i].MarterialsName + "消耗";
                        }
                        
                    }
                    else
                    {
                        if (myELCParameters[i].ProcessMaterialsUsedQuantity == 1)
                        {
                            m_Model_CaculateValue.CaculateFormula = m_Model_CaculateValue.CaculateFormula + " + " + myELCParameters[i].ProcessName + "耗电量";
                        }
                        else
                        {
                            m_Model_CaculateValue.CaculateFormula = m_Model_CaculateValue.CaculateFormula + " + " + myELCParameters[i].ProcessName + "电耗 * " + myELCParameters[i].MarterialsName + "消耗";
                        }
                    }
                    Model_CaculateFactor m_Model_CaculateFactor = new Model_CaculateFactor();
                    if (myELCParameters[i].ProcessMaterialsUsedQuantity == 1)
                    {
                        m_Model_CaculateFactor.FactorName = myELCParameters[i].ProcessName + "耗电量";
                    }
                    else
                    {
                        m_Model_CaculateFactor.FactorName = myELCParameters[i].ProcessName + "电耗";
                    }
                    m_Model_CaculateFactor.FactorValue = myELCParameters[i].ProcessElectricityConsumption;
                    m_Model_CaculateValue.CaculateFactor.Add(m_Model_CaculateFactor);
                    if (myELCParameters[i].MarterialsName != myStaticsMarterialsName && myELCParameters[i].ProcessMaterialsUsedQuantity != 1)
                    {
                        Model_CaculateFactor m_Model_CaculateFactorX = new Model_CaculateFactor();
                        m_Model_CaculateFactorX.FactorName = myELCParameters[i].MarterialsName + "消耗";
                        m_Model_CaculateFactorX.FactorValue = myELCParameters[i].ProcessMaterialsUsedQuantity;
                        m_Model_CaculateValue.CaculateFactor.Add(m_Model_CaculateFactorX);
                    }
                }
                if (myMarterialsOutput != 0)
                {
                    m_PowerConsumption = m_UsedElectricity / myMarterialsOutput;
                }
                m_Model_CaculateValue.CaculateValue = m_PowerConsumption;
                m_Model_CaculateValue.CaculateFormula = string.Format("({0})", m_Model_CaculateValue.CaculateFormula);
                m_Model_CaculateValue.CaculateFormula = m_Model_CaculateValue.CaculateFormula + " / " + myStaticsMarterialsName + "产量";
                Model_CaculateFactor m_Denominator_CaculateFactor = new Model_CaculateFactor();
                m_Denominator_CaculateFactor.FactorName = myStaticsMarterialsName + "产量";
                m_Denominator_CaculateFactor.FactorValue = myMarterialsOutput;
                m_Model_CaculateValue.CaculateFactor.Add(m_Denominator_CaculateFactor);
            }
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算熟料可比电耗
        /// </summary>
        /// <param name="myClinkerELCParameters">熟料电耗参数</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <param name="myClinkerProperties">熟料属性</param>
        /// <returns>熟料可比电耗</returns>
        public Model_CaculateValue GetClinkerPowerConsumptionComparable(List<Model_BaseELCParameters> myClinkerELCParameters, Model_CommonParameters myCommonParameters, Model_ClinkerProperties myClinkerProperties)
        {
            decimal m_ClinkerPowerConsumptionComparable = 0;
            decimal m_ClinkerPowerConsumption = GetPowerConsumption(myClinkerELCParameters, myClinkerProperties.MarterialsOutput, "熟料").CaculateValue;
            decimal m_CompressiveStrengthCorrectionFactor = (decimal)Math.Pow((double)(myCommonParameters.Clinker_CompressiveStrength / myClinkerProperties.CompressiveStrength), 1 / 4);    //强度修正系数
            decimal m_AltitudeCorrectionFactor = 1;
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();

            m_Model_CaculateValue.CaculateFormula = "熟料综合电耗";
            Model_CaculateFactor m_Model_CaculateFactor = new Model_CaculateFactor();
            m_Model_CaculateFactor.FactorName = "熟料综合电耗";
            m_Model_CaculateFactor.FactorValue = m_ClinkerPowerConsumption;
            m_Model_CaculateValue.CaculateFactor.Add(m_Model_CaculateFactor);

            if (myClinkerProperties.Altitude > myCommonParameters.Altitude)
            {
                m_AltitudeCorrectionFactor = (decimal)Math.Sqrt((double)(myClinkerProperties.AtmosphericPressure / myCommonParameters.AtmosphericPressure));      
                //海拔修正系数
                m_Model_CaculateValue.CaculateFormula = "Sqrt(海拔修正系数)" + " * " +  m_Model_CaculateValue.CaculateFormula;
                Model_CaculateFactor m_Altitude_CaculateFactor = new Model_CaculateFactor();
                m_Altitude_CaculateFactor.FactorName = "海拔修正系数";
                m_Altitude_CaculateFactor.FactorValue = m_AltitudeCorrectionFactor;
                m_Model_CaculateValue.CaculateFactor.Add(m_Altitude_CaculateFactor);
            }
            //28天强度修正系数
            m_Model_CaculateValue.CaculateFormula = "pow(28天强度修正系数,1/4)" + " * " + m_Model_CaculateValue.CaculateFormula;
            Model_CaculateFactor m_CompressiveStrength_CaculateFactor = new Model_CaculateFactor();
            m_CompressiveStrength_CaculateFactor.FactorName = "28天强度修正系数";
            m_CompressiveStrength_CaculateFactor.FactorValue = m_CompressiveStrengthCorrectionFactor;
            m_Model_CaculateValue.CaculateFactor.Add(m_CompressiveStrength_CaculateFactor);

            m_ClinkerPowerConsumptionComparable = m_ClinkerPowerConsumption * m_CompressiveStrengthCorrectionFactor * m_AltitudeCorrectionFactor;
            m_Model_CaculateValue.CaculateValue = m_ClinkerPowerConsumptionComparable;
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算水泥可比电耗
        /// </summary>
        /// <param name="myCementELCParameters">水泥电耗参数</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <param name="myCementProperties">水泥属性</param>
        /// <returns>水泥可比电耗</returns>
        public Model_CaculateValue GetCementPowerConsumptionComparable(List<Model_BaseELCParameters> myCementELCParameters, Model_CommonParameters myCommonParameters, Model_CementProperties myCementProperties)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            decimal m_CementPowerConsumptionComparable = 0;
            decimal m_CementPowerConsumption = GetPowerConsumption(myCementELCParameters, myCementProperties.MarterialsOutput, "水泥").CaculateValue;
            decimal m_CompressiveStrengthCorrectionFactor = (decimal)Math.Pow((double)(myCommonParameters.Cement_CompressiveStrength / myCementProperties.CompressiveStrength), 1 / 4);    //强度修正系数
            decimal m_AltitudeCorrectionFactor = 1;

            m_Model_CaculateValue.CaculateFormula = "水泥综合电耗";
            Model_CaculateFactor m_Model_CaculateFactor = new Model_CaculateFactor();
            m_Model_CaculateFactor.FactorName = "水泥综合电耗";
            m_Model_CaculateFactor.FactorValue = m_CementPowerConsumption;
            m_Model_CaculateValue.CaculateFactor.Add(m_Model_CaculateFactor);

            if (myCementProperties.Altitude > myCommonParameters.Altitude)
            {
                m_AltitudeCorrectionFactor = (decimal)Math.Sqrt((double)(myCementProperties.AtmosphericPressure / myCommonParameters.AtmosphericPressure));
                //海拔修正系数
                m_Model_CaculateValue.CaculateFormula = "Sqrt(海拔修正系数)" + " * " + m_Model_CaculateValue.CaculateFormula;
                Model_CaculateFactor m_Altitude_CaculateFactor = new Model_CaculateFactor();
                m_Altitude_CaculateFactor.FactorName = "海拔修正系数";
                m_Altitude_CaculateFactor.FactorValue = m_AltitudeCorrectionFactor;
                m_Model_CaculateValue.CaculateFactor.Add(m_Altitude_CaculateFactor);
            }
            //水泥强度修正系数
            m_Model_CaculateValue.CaculateFormula = "pow(水泥强度修正系数,1/4)" + " * " + m_Model_CaculateValue.CaculateFormula;
            Model_CaculateFactor m_CompressiveStrength_CaculateFactor = new Model_CaculateFactor();
            m_CompressiveStrength_CaculateFactor.FactorName = "水泥强度修正系数";
            m_CompressiveStrength_CaculateFactor.FactorValue = m_CompressiveStrengthCorrectionFactor;
            m_Model_CaculateValue.CaculateFactor.Add(m_CompressiveStrength_CaculateFactor);
            m_CementPowerConsumptionComparable = m_CementPowerConsumption * m_CompressiveStrengthCorrectionFactor * m_AltitudeCorrectionFactor;

            m_Model_CaculateValue.CaculateValue = m_CementPowerConsumptionComparable;
            return m_Model_CaculateValue;
        }
    }
}
