using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Base_EnergyConsumption
    {
        /// <summary>
        /// 计算综合能耗
        /// </summary>
        /// <param name="myPowConsumption">综合电耗</param>
        /// <param name="myCoalConsumption">综合煤耗</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>综合能耗</returns>
        public Model_CaculateValue GetEnergyConsumption(decimal myPowConsumption, decimal myCoalConsumption, Model_CommonParameters myCommonParameters, string myStaticsMarterialsName)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            decimal m_EnergyConsumption = 0;
            if (myCommonParameters != null)
            {
                m_EnergyConsumption = myCoalConsumption + myPowConsumption * myCommonParameters.ElectricityToCoalFactor;
            }

            ///////////////////////综合煤耗/////////////////////
            Model_CaculateFactor m_CoalConsumption_CaculateFactor = new Model_CaculateFactor();
            m_CoalConsumption_CaculateFactor.FactorName = myStaticsMarterialsName + "综合煤耗";
            m_CoalConsumption_CaculateFactor.FactorValue = myCoalConsumption;
            m_Model_CaculateValue.CaculateFactor.Add(m_CoalConsumption_CaculateFactor);
            /////////////////////综合电耗///////////////////////
            Model_CaculateFactor m_PowConsumption_CaculateFactor = new Model_CaculateFactor();
            m_PowConsumption_CaculateFactor.FactorName = myStaticsMarterialsName + "综合电耗";
            m_PowConsumption_CaculateFactor.FactorValue = myPowConsumption;
            m_Model_CaculateValue.CaculateFactor.Add(m_PowConsumption_CaculateFactor);
            ///////////////////////用电折合用煤系数/////////////////////
            Model_CaculateFactor m_ElectricityToCoalFactor_CaculateFactor = new Model_CaculateFactor();
            m_ElectricityToCoalFactor_CaculateFactor.FactorName = "用电折合用煤系数";
            m_ElectricityToCoalFactor_CaculateFactor.FactorValue = myCommonParameters.ElectricityToCoalFactor;
            m_Model_CaculateValue.CaculateFactor.Add(m_ElectricityToCoalFactor_CaculateFactor);

            m_Model_CaculateValue.CaculateFormula = myStaticsMarterialsName + "综合煤耗 + " + myStaticsMarterialsName + "综合电耗 * 用电折合用煤系数";
            m_Model_CaculateValue.CaculateValue = m_EnergyConsumption;
            return m_Model_CaculateValue;

        }
        /// <summary>
        /// 计算可比综合能耗
        /// </summary>
        /// <param name="myPowConsumptionComparable">可比综合电耗</param>
        /// <param name="myCoalConsumptionComparable">可比综合煤耗</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>可比综合能耗</returns>
        public Model_CaculateValue GetEnergyConsumptionComparable(decimal myPowConsumptionComparable, decimal myCoalConsumptionComparable, Model_CommonParameters myCommonParameters, string myStaticsMarterialsName)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            decimal m_EnergyConsumptionComparable = 0;
            if (myCommonParameters != null)
            {
                m_EnergyConsumptionComparable = myCoalConsumptionComparable + myPowConsumptionComparable * myCommonParameters.ElectricityToCoalFactor;
            }

            ///////////////////////可比综合煤耗/////////////////////
            Model_CaculateFactor m_CoalConsumptionComparable_CaculateFactor = new Model_CaculateFactor();
            m_CoalConsumptionComparable_CaculateFactor.FactorName = myStaticsMarterialsName + "可比综合煤耗";
            m_CoalConsumptionComparable_CaculateFactor.FactorValue = myCoalConsumptionComparable;
            m_Model_CaculateValue.CaculateFactor.Add(m_CoalConsumptionComparable_CaculateFactor);
            /////////////////////可比综合电耗///////////////////////
            Model_CaculateFactor m_PowConsumptionComparable_CaculateFactor = new Model_CaculateFactor();
            m_PowConsumptionComparable_CaculateFactor.FactorName = myStaticsMarterialsName + "可比综合电耗";
            m_PowConsumptionComparable_CaculateFactor.FactorValue = myPowConsumptionComparable;
            m_Model_CaculateValue.CaculateFactor.Add(m_PowConsumptionComparable_CaculateFactor);
            ///////////////////////用电折合用煤系数/////////////////////
            Model_CaculateFactor m_ElectricityToCoalFactor_CaculateFactor = new Model_CaculateFactor();
            m_ElectricityToCoalFactor_CaculateFactor.FactorName = "用电折合用煤系数";
            m_ElectricityToCoalFactor_CaculateFactor.FactorValue = myCommonParameters.ElectricityToCoalFactor;
            m_Model_CaculateValue.CaculateFactor.Add(m_ElectricityToCoalFactor_CaculateFactor);

            m_Model_CaculateValue.CaculateFormula = myStaticsMarterialsName + "可比综合煤耗 + " + myStaticsMarterialsName + "可比综合电耗 * 用电折合用煤系数";
            m_Model_CaculateValue.CaculateValue = m_EnergyConsumptionComparable;
            return m_Model_CaculateValue;
        }
    }
}
