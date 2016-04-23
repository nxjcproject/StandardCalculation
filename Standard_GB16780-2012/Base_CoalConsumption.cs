using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Base_CoalConsumption
    {
        /// <summary>
        /// 计算煤耗
        /// </summary>
        /// <param name="myCLCParameters">煤耗参数</param>
        /// <param name="myMarterialsOutput">物料产量</param>
        /// <returns>煤耗</returns>
        public Model_CaculateValue GetCoalConsumption(List<Model_BaseCLCParameters> myCLCParameters, decimal myMarterialsOutput, decimal myStandardCalorificValue, string myStaticsMarterialsName)
        {
            decimal m_CoalConsumption = 0;
            decimal m_UsedCoal = 0;
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            if (myCLCParameters != null)
            {
                for (int i = 0; i < myCLCParameters.Count; i++)
                {
                    m_UsedCoal = m_UsedCoal + myCLCParameters[i].ProcessCoalConsumption * myCLCParameters[i].ProcessMaterialsUsedQuantity * myCLCParameters[i].CoalLowCalorificValue;
                    if (i == 0)
                    {
                        if (myCLCParameters[i].ProcessMaterialsUsedQuantity == 1)
                        {
                            m_Model_CaculateValue.CaculateFormula = myCLCParameters[i].ProcessName + "耗煤量 * "  + myCLCParameters[i].MarterialsName + "低位发热量";
                        }
                        else
                        {
                            m_Model_CaculateValue.CaculateFormula = myCLCParameters[i].ProcessName + "煤耗 * " + myCLCParameters[i].MarterialsName + "消耗 * " + myCLCParameters[i].MarterialsName + "低位发热量";
                        }
                    }
                    else
                    {
                        if (myCLCParameters[i].ProcessMaterialsUsedQuantity == 1)
                        {
                            m_Model_CaculateValue.CaculateFormula = m_Model_CaculateValue.CaculateFormula + " + " + myCLCParameters[i].ProcessName + "耗煤量 * " + myCLCParameters[i].MarterialsName + "低位发热量";
                        }
                        else
                        {
                            m_Model_CaculateValue.CaculateFormula = m_Model_CaculateValue.CaculateFormula + " + " + myCLCParameters[i].ProcessName + "煤耗 * " + myCLCParameters[i].MarterialsName + "消耗 * " + myCLCParameters[i].MarterialsName + "低位发热量";
                        }
                    }
                    Model_CaculateFactor m_Model_CaculateFactor = new Model_CaculateFactor();
                    if (myCLCParameters[i].ProcessMaterialsUsedQuantity == 1)
                    {
                        m_Model_CaculateFactor.FactorName = myCLCParameters[i].ProcessName + "耗煤量";
                    }
                    else
                    {
                        m_Model_CaculateFactor.FactorName = myCLCParameters[i].ProcessName + "煤耗";
                    }
                    m_Model_CaculateFactor.FactorValue = myCLCParameters[i].ProcessCoalConsumption * 1000;
                    m_Model_CaculateValue.CaculateFactor.Add(m_Model_CaculateFactor);
                    if (myCLCParameters[i].MarterialsName != myStaticsMarterialsName && myCLCParameters[i].ProcessMaterialsUsedQuantity != 1)
                    {
                        Model_CaculateFactor m_Model_CaculateFactorX = new Model_CaculateFactor();
                        m_Model_CaculateFactorX.FactorName = myCLCParameters[i].MarterialsName + "消耗";
                        m_Model_CaculateFactorX.FactorValue = myCLCParameters[i].ProcessMaterialsUsedQuantity;
                        m_Model_CaculateValue.CaculateFactor.Add(m_Model_CaculateFactorX);
                    }
                    ////////////////////煤粉低位发热量因数
                    Model_CaculateFactor m_CoalLowCalorific_CaculateFactor = new Model_CaculateFactor();
                    m_CoalLowCalorific_CaculateFactor.FactorName = myCLCParameters[i].ProcessName + "低位发热量";
                    m_CoalLowCalorific_CaculateFactor.FactorValue = myCLCParameters[i].CoalLowCalorificValue;
                    m_Model_CaculateValue.CaculateFactor.Add(m_CoalLowCalorific_CaculateFactor);
                }
                if (myMarterialsOutput != 0)
                {
                    m_CoalConsumption = (m_UsedCoal * 1000) / (myMarterialsOutput * myStandardCalorificValue);    //煤耗煤为kg
                }

                m_Model_CaculateValue.CaculateValue = m_CoalConsumption;
                m_Model_CaculateValue.CaculateFormula = string.Format("({0})", m_Model_CaculateValue.CaculateFormula);
                m_Model_CaculateValue.CaculateFormula = m_Model_CaculateValue.CaculateFormula + " / (" + myStaticsMarterialsName + "产量 * 标准煤发热量)";
                Model_CaculateFactor m_Denominator_CaculateFactor = new Model_CaculateFactor();
                m_Denominator_CaculateFactor.FactorName = myStaticsMarterialsName + "产量";
                m_Denominator_CaculateFactor.FactorValue = myMarterialsOutput;
                m_Model_CaculateValue.CaculateFactor.Add(m_Denominator_CaculateFactor);
            }
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算熟料可比煤耗
        /// </summary>
        /// <param name="myClinkerCLCParameters">熟料煤耗参数</param>
        /// <param name="myDeductionCLCParameters">熟料应扣除煤耗</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <param name="myClinkerProperties">熟料属性</param>
        /// <returns>熟料可比煤耗</returns>
        public Model_CaculateValue GetClinkerCoalConsumptionComparable(List<Model_BaseCLCParameters> myClinkerCLCParameters, List<Model_BaseCLCParameters> myDeductionCLCParameters, Model_CommonParameters myCommonParameters, Model_ClinkerProperties myClinkerProperties)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            decimal m_ClinkerCoalConsumptionComparable = 0;
            decimal m_ClinkerCoalConsumption = GetCoalConsumption(myClinkerCLCParameters, myClinkerProperties.MarterialsOutput, myCommonParameters.StandardCalorificValue,"熟料").CaculateValue;
            decimal m_DeductionClinkerCoalConsumption = GetCoalConsumption(myDeductionCLCParameters, myClinkerProperties.MarterialsOutput, myCommonParameters.StandardCalorificValue,"熟料").CaculateValue;
            decimal m_CompressiveStrengthCorrectionFactor = (decimal)Math.Pow((double)(myCommonParameters.Clinker_CompressiveStrength / myClinkerProperties.CompressiveStrength), 1 / 4);    //强度修正系数
            decimal m_AltitudeCorrectionFactor = 1;

            if (myClinkerProperties.Altitude > myCommonParameters.Altitude)
            {
                m_AltitudeCorrectionFactor = (decimal)Math.Sqrt((double)(myClinkerProperties.AtmosphericPressure / myCommonParameters.AtmosphericPressure));                               //海拔修正系数
            }
            m_ClinkerCoalConsumptionComparable = (m_ClinkerCoalConsumption - m_DeductionClinkerCoalConsumption) * m_CompressiveStrengthCorrectionFactor * m_AltitudeCorrectionFactor;

            ///////////////////////////熟料综合煤耗/////////////////////////
            Model_CaculateFactor m_ClinkerCoalConsumption_CaculateFactor = new Model_CaculateFactor();
            m_ClinkerCoalConsumption_CaculateFactor.FactorName = "熟料综合煤耗";
            m_ClinkerCoalConsumption_CaculateFactor.FactorValue = m_ClinkerCoalConsumption;
            m_Model_CaculateValue.CaculateFactor.Add(m_ClinkerCoalConsumption_CaculateFactor);
            ///////////////////////////抵扣熟料煤耗////////////////////////
            Model_CaculateFactor m_DeductionClinkerCoalConsumption_CaculateFactor = new Model_CaculateFactor();
            m_DeductionClinkerCoalConsumption_CaculateFactor.FactorName = "抵扣熟料煤耗(余热发电等)";
            m_DeductionClinkerCoalConsumption_CaculateFactor.FactorValue = m_DeductionClinkerCoalConsumption;
            m_Model_CaculateValue.CaculateFactor.Add(m_DeductionClinkerCoalConsumption_CaculateFactor);
            ///////////////////////////水泥强度修正系数////////////////////////
            Model_CaculateFactor m_CompressiveStrengthCorrectionFactor_CaculateFactor = new Model_CaculateFactor();
            m_CompressiveStrengthCorrectionFactor_CaculateFactor.FactorName = "水泥强度修正系数";
            m_CompressiveStrengthCorrectionFactor_CaculateFactor.FactorValue = m_CompressiveStrengthCorrectionFactor;
            m_Model_CaculateValue.CaculateFactor.Add(m_CompressiveStrengthCorrectionFactor_CaculateFactor);
            ///////////////////////////海拔高度修正系数////////////////////////
            Model_CaculateFactor m_AltitudeCorrectionFactor_CaculateFactor = new Model_CaculateFactor();
            m_AltitudeCorrectionFactor_CaculateFactor.FactorName = "海拔高度修正系数";
            m_AltitudeCorrectionFactor_CaculateFactor.FactorValue = m_AltitudeCorrectionFactor;
            m_Model_CaculateValue.CaculateFactor.Add(m_AltitudeCorrectionFactor_CaculateFactor);

            m_Model_CaculateValue.CaculateFormula = "(熟料综合煤耗 - 抵扣熟料煤耗(余热发电等)) * 熟料强度修正系数 * 海拔高度修正系数";
            m_Model_CaculateValue.CaculateValue = m_ClinkerCoalConsumptionComparable;
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算水泥可比煤耗
        /// </summary>
        /// <param name="myCementCLCParameters">水泥煤耗参数</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <param name="myCementProperties">熟料属性</param>
        /// <returns>可比水泥煤耗</returns>
        public Model_CaculateValue GetCementCoalConsumptionComparable(List<Model_BaseCLCParameters> myCementCLCParameters, Model_CommonParameters myCommonParameters, Model_CementProperties myCementProperties)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();

            m_Model_CaculateValue = GetCoalConsumption(myCementCLCParameters, myCementProperties.MarterialsOutput, myCommonParameters.StandardCalorificValue, "水泥");

            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算余热发电折算煤耗
        /// </summary>
        /// <param name="myGrossGeneration">余热发电总发电量</param>
        /// <param name="myOwnDemand">余热发电自用电量</param>
        /// <param name="myClinkerOutput">熟料产量</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>余热发电折算煤耗</returns>
        public Model_CaculateValue GetCogenerationCoalConsumption(decimal myGrossGeneration, decimal myOwnDemand, decimal myClinkerOutput, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            decimal m_CogenerationCoalConsumption = 0;
            m_CogenerationCoalConsumption = myCommonParameters.ElectricityToCoalFactor * (myGrossGeneration - myOwnDemand) / myClinkerOutput;

            ///////////////////////////用电折合用煤系数////////////////////////
            Model_CaculateFactor m_ElectricityToCoalFactor_CaculateFactor = new Model_CaculateFactor();
            m_ElectricityToCoalFactor_CaculateFactor.FactorName = "用电折合用煤系数";
            m_ElectricityToCoalFactor_CaculateFactor.FactorValue = myCommonParameters.ElectricityToCoalFactor;
            m_Model_CaculateValue.CaculateFactor.Add(m_ElectricityToCoalFactor_CaculateFactor);
            ///////////////////////////总发电量////////////////////////
            Model_CaculateFactor m_GrossGeneration_CaculateFactor = new Model_CaculateFactor();
            m_GrossGeneration_CaculateFactor.FactorName = "总发电量";
            m_GrossGeneration_CaculateFactor.FactorValue = myGrossGeneration;
            m_Model_CaculateValue.CaculateFactor.Add(m_GrossGeneration_CaculateFactor);
            ///////////////////////////自用电量////////////////////////
            Model_CaculateFactor m_OwnDemand_CaculateFactor = new Model_CaculateFactor();
            m_OwnDemand_CaculateFactor.FactorName = "自用电量";
            m_OwnDemand_CaculateFactor.FactorValue = myOwnDemand;
            m_Model_CaculateValue.CaculateFactor.Add(m_OwnDemand_CaculateFactor);
            ///////////////////////////熟料产量////////////////////////
            Model_CaculateFactor m_ClinkerOutput_CaculateFactor = new Model_CaculateFactor();
            m_ClinkerOutput_CaculateFactor.FactorName = "熟料产量";
            m_ClinkerOutput_CaculateFactor.FactorValue = myClinkerOutput;
            m_Model_CaculateValue.CaculateFactor.Add(m_ClinkerOutput_CaculateFactor);

            m_Model_CaculateValue.CaculateFormula = "用电折合用煤系数 * (总发电量 - 自用电量) / 熟料产量";
            m_Model_CaculateValue.CaculateValue = m_CogenerationCoalConsumption;
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算余热利用折算煤耗
        /// </summary>
        /// <param name="myImportHeat">余热利用进口总热量</param>
        /// <param name="myExportHeat">余热利用出口总热量</param>
        /// <param name="myLossHeat">余热利用散失量</param>
        /// <param name="myClinkerOutput">熟料产量</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>余热利用折算煤耗</returns>
        public Model_CaculateValue GetRecuperationCoalConsumption(decimal myImportHeat, decimal myExportHeat, decimal myLossHeat, decimal myClinkerOutput, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            decimal m_RecuperationCoalConsumption = 0;
            m_RecuperationCoalConsumption = (myImportHeat - myExportHeat - myLossHeat) / (myClinkerOutput * myCommonParameters.StandardCalorificValue);


            ///////////////////////////进口总热量////////////////////////
            Model_CaculateFactor m_ImportHeat_CaculateFactor = new Model_CaculateFactor();
            m_ImportHeat_CaculateFactor.FactorName = "进口总热量";
            m_ImportHeat_CaculateFactor.FactorValue = myImportHeat;
            m_Model_CaculateValue.CaculateFactor.Add(m_ImportHeat_CaculateFactor);
            ///////////////////////////出口总热量////////////////////////
            Model_CaculateFactor m_ExportHeat_CaculateFactor = new Model_CaculateFactor();
            m_ExportHeat_CaculateFactor.FactorName = "出口总热量";
            m_ExportHeat_CaculateFactor.FactorValue = myExportHeat;
            m_Model_CaculateValue.CaculateFactor.Add(m_ExportHeat_CaculateFactor);
            ///////////////////////////散热损失热量////////////////////////
            Model_CaculateFactor m_LossHeat_CaculateFactor = new Model_CaculateFactor();
            m_LossHeat_CaculateFactor.FactorName = "散热损失热量";
            m_LossHeat_CaculateFactor.FactorValue = myLossHeat;
            m_Model_CaculateValue.CaculateFactor.Add(m_LossHeat_CaculateFactor);
            ///////////////////////////标准煤发热量////////////////////////
            Model_CaculateFactor m_StandardCalorificValue_CaculateFactor = new Model_CaculateFactor();
            m_StandardCalorificValue_CaculateFactor.FactorName = "标准煤发热量";
            m_StandardCalorificValue_CaculateFactor.FactorValue = myCommonParameters.StandardCalorificValue;
            m_Model_CaculateValue.CaculateFactor.Add(m_StandardCalorificValue_CaculateFactor);
            ///////////////////////////熟料产量////////////////////////
            Model_CaculateFactor m_ClinkerOutput_CaculateFactor = new Model_CaculateFactor();
            m_ClinkerOutput_CaculateFactor.FactorName = "熟料产量";
            m_ClinkerOutput_CaculateFactor.FactorValue = myClinkerOutput;
            m_Model_CaculateValue.CaculateFactor.Add(m_ClinkerOutput_CaculateFactor);

            m_Model_CaculateValue.CaculateFormula = "(进口总热量 - (出口总热量 + 散热损失热量)) / (熟料产量 * 标准煤发热量)";
            m_Model_CaculateValue.CaculateValue = m_RecuperationCoalConsumption;
            return m_Model_CaculateValue;
        }
    }
}
