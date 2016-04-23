using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_GB16780_2012
{
    public class Assembly_EnergyConsumption
    {
        private Base_PowConsumption m_Base_PowConsumption;
        private Base_CoalConsumption m_Base_CoalConsumption;
        private Base_EnergyConsumption m_Base_EnergyConsumption;

        public Assembly_EnergyConsumption()
        {
            m_Base_PowConsumption = new Base_PowConsumption();
            m_Base_CoalConsumption = new Base_CoalConsumption();
            m_Base_EnergyConsumption = new Base_EnergyConsumption();
        }
        ///////////////////////////////////////////////////熟料//////////////////////////////////////////////
        /// <summary>
        /// 计算熟料综合电耗
        /// </summary>
        /// <param name="myClinkerProperties">熟料属性</param>
        /// <param name="myClinkerProcessMartieralsProperties">各工序物料属性</param>
        /// <returns>熟料电耗</returns>
        public Model_CaculateValue GetClinkerPowerConsumption(Model_ClinkerProperties myClinkerProperties, List<Model_MartieralsProperties> myClinkerProcessMartieralsProperties)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            List<Model_BaseELCParameters> m_ClinkerBaseELCParameters = new List<Model_BaseELCParameters>(1);
            if (myClinkerProperties != null && myClinkerProcessMartieralsProperties != null)
            {
                for (int i = 0; i < myClinkerProcessMartieralsProperties.Count; i++)
                {
                    Model_BaseELCParameters m_Model_BaseELCParameters = new Model_BaseELCParameters();
                    //求工序干基电耗
                    m_Model_BaseELCParameters.ProcessName = myClinkerProcessMartieralsProperties[i].ProcessName;    //获取工序名称
                    m_Model_BaseELCParameters.MarterialsName = myClinkerProcessMartieralsProperties[i].MarterialsName;    //获取物料名称
                    if (myClinkerProcessMartieralsProperties[i].MarterialsOutput != 0 && myClinkerProcessMartieralsProperties[i].MarterialsWaterContent < 1 && myClinkerProcessMartieralsProperties[i].MarterialsWaterContent >= 0)
                    {
                        m_Model_BaseELCParameters.ProcessElectricityConsumption = myClinkerProcessMartieralsProperties[i].ElectricityQuantity / (myClinkerProcessMartieralsProperties[i].MarterialsOutput * (1 - myClinkerProcessMartieralsProperties[i].MarterialsWaterContent));
                    }
                    else
                    {
                        m_Model_BaseELCParameters.ProcessElectricityConsumption = 0;
                    }
                    m_Model_BaseELCParameters.ProcessMaterialsUsedQuantity = myClinkerProcessMartieralsProperties[i].MarterialsInput * (1 - myClinkerProcessMartieralsProperties[i].MarterialsWaterContent);
                    m_ClinkerBaseELCParameters.Add(m_Model_BaseELCParameters);
                }
                m_Model_CaculateValue = m_Base_PowConsumption.GetPowerConsumption(m_ClinkerBaseELCParameters, myClinkerProperties.MarterialsOutput, "熟料");
            }
            m_Model_CaculateValue.CaculateName = "熟料综合电耗";
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算熟料综合煤耗
        /// </summary>
        /// <param name="myClinkerProperties">熟料属性</param>
        /// <param name="myCoalProperties">煤粉属性</param>
        /// <param name="myClinkerProcessMartieralsProperties">各耗煤工序物料属性</param>
        /// <returns>熟料综合煤耗</returns>
        public Model_CaculateValue GetClinkerCoalConsumption(Model_ClinkerProperties myClinkerProperties, Model_CoalProperties myCoalProperties, List<Model_MartieralsProperties> myClinkerProcessMartieralsProperties, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            List<Model_BaseCLCParameters> m_ClinkerBaseCLCParameters = new List<Model_BaseCLCParameters>(1);
            if (myClinkerProcessMartieralsProperties != null)
            {
                for (int i = 0; i < myClinkerProcessMartieralsProperties.Count; i++)
                {
                    //求工序干基煤耗
                    Model_BaseCLCParameters m_Model_BaseCLCParameters = new Model_BaseCLCParameters();
                    m_Model_BaseCLCParameters.ProcessName = myClinkerProcessMartieralsProperties[i].ProcessName;    //获取工序名称
                    m_Model_BaseCLCParameters.MarterialsName = myClinkerProcessMartieralsProperties[i].MarterialsName;    //获取物料名称
                    if (myClinkerProcessMartieralsProperties[i].MarterialsOutput != 0 && myClinkerProcessMartieralsProperties[i].MarterialsWaterContent < 1 && myClinkerProcessMartieralsProperties[i].MarterialsWaterContent >= 0)
                    {
                        m_Model_BaseCLCParameters.ProcessCoalConsumption = (myClinkerProcessMartieralsProperties[i].CoalQuantity * (1 - myCoalProperties.CoalWaterContent)) / (myClinkerProcessMartieralsProperties[i].MarterialsOutput * (1 - myClinkerProcessMartieralsProperties[i].MarterialsWaterContent));
                    }
                    else
                    {
                        m_Model_BaseCLCParameters.ProcessCoalConsumption = 0;
                    }
                    m_Model_BaseCLCParameters.ProcessMaterialsUsedQuantity = myClinkerProcessMartieralsProperties[i].MarterialsInput * (1 - myClinkerProcessMartieralsProperties[i].MarterialsWaterContent);
                    m_Model_BaseCLCParameters.CoalWaterContent = myClinkerProcessMartieralsProperties[i].MarterialsWaterContent;
                    m_Model_BaseCLCParameters.CoalLowCalorificValue = myCoalProperties.CoalLowCalorificValue;
                    m_ClinkerBaseCLCParameters.Add(m_Model_BaseCLCParameters);
                }
                m_Model_CaculateValue = m_Base_CoalConsumption.GetCoalConsumption(m_ClinkerBaseCLCParameters, myClinkerProperties.MarterialsOutput, myCommonParameters.StandardCalorificValue,"熟料");
            }
            m_Model_CaculateValue.CaculateName = "熟料综合煤耗";
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算熟料综合能耗
        /// </summary>
        /// <param name="myClinkerPowerConsumption">熟料综合电耗</param>
        /// <param name="myClinkerCoalConsumption">熟料综合煤耗</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>熟料综合能耗</returns>
        public Model_CaculateValue GetClinkerEnergyConsumption(decimal myClinkerPowerConsumption, decimal myClinkerCoalConsumption, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            m_Model_CaculateValue = m_Base_EnergyConsumption.GetEnergyConsumption(myClinkerPowerConsumption, myClinkerCoalConsumption, myCommonParameters,"熟料");
            m_Model_CaculateValue.CaculateName = "熟料综合能耗";
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算可比熟料综合电耗
        /// </summary>
        /// <param name="myClinkerProperties">熟料属性</param>
        /// <param name="myClinkerProcessMartieralsProperties">各耗电工序物料属性</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>可比熟料综合电耗</returns>
        public Model_CaculateValue GetClinkerPowerConsumptionComparable(Model_ClinkerProperties myClinkerProperties, List<Model_MartieralsProperties> myClinkerProcessMartieralsProperties, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValueComparable = new Model_CaculateValue();
            List<Model_BaseELCParameters> m_ClinkerELCParameters = new List<Model_BaseELCParameters>();
            //计算熟料电耗
            Model_BaseELCParameters m_Model_BaseELCParameters = new Model_BaseELCParameters();
            m_Model_BaseELCParameters.ProcessName = "熟料综合电耗";    //获取工序名称
            m_Model_BaseELCParameters.MarterialsName = "熟料";    //获取物料名称

            m_Model_BaseELCParameters.ProcessElectricityConsumption = GetClinkerPowerConsumption(myClinkerProperties, myClinkerProcessMartieralsProperties).CaculateValue;
            m_Model_BaseELCParameters.ProcessMaterialsUsedQuantity = myClinkerProperties.MarterialsOutput;
            m_ClinkerELCParameters.Add(m_Model_BaseELCParameters);
            m_Model_CaculateValueComparable = m_Base_PowConsumption.GetClinkerPowerConsumptionComparable(m_ClinkerELCParameters, myCommonParameters, myClinkerProperties);
            m_Model_CaculateValueComparable.CaculateName = "可比熟料综合电耗";
            return m_Model_CaculateValueComparable;
        }
        /// <summary>
        /// 计算可比熟料综合煤耗
        /// </summary>
        /// <param name="myClinkerProperties">熟料属性</param>
        /// <param name="myCoalProperties">煤粉属性</param>
        /// <param name="myClinkerProcessMartieralsProperties">各耗煤工序物料属性</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <param name="myCogenerationProperties">余热发电属性</param>
        /// <param name="myRecuperationProperties">余热利用属性</param>
        /// <returns>可比熟料综合煤耗</returns>
        public Model_CaculateValue GetClinkerCoalConsumptionComparable(Model_ClinkerProperties myClinkerProperties, Model_CoalProperties myCoalProperties, List<Model_MartieralsProperties> myClinkerProcessMartieralsProperties,
            Model_CommonParameters myCommonParameters, Model_CogenerationProperties myCogenerationProperties, Model_RecuperationProperties myRecuperationProperties)
        {
            Model_CaculateValue m_Model_CaculateValueComparable = new Model_CaculateValue();
            List<Model_BaseCLCParameters> m_ClinkerCLCParameters = new List<Model_BaseCLCParameters>();
            List<Model_BaseCLCParameters> m_DeductionCLCParameters = new List<Model_BaseCLCParameters>();    //应扣项
            //计算熟料煤耗
            Model_BaseCLCParameters m_Model_BaseCLCParameters = new Model_BaseCLCParameters();
            m_Model_BaseCLCParameters.ProcessName = "熟料综合煤耗";    //获取工序名称
            m_Model_BaseCLCParameters.MarterialsName = "熟料";    //获取物料名称
            m_Model_BaseCLCParameters.ProcessCoalConsumption = GetClinkerCoalConsumption(myClinkerProperties, myCoalProperties, myClinkerProcessMartieralsProperties, myCommonParameters).CaculateValue / 1000;
            m_Model_BaseCLCParameters.ProcessMaterialsUsedQuantity = myClinkerProperties.MarterialsOutput;
            m_Model_BaseCLCParameters.CoalWaterContent = myCoalProperties.CoalWaterContent;
            m_Model_BaseCLCParameters.CoalLowCalorificValue = myCoalProperties.CoalLowCalorificValue;
            m_ClinkerCLCParameters.Add(m_Model_BaseCLCParameters);
            //计算余热发电折算煤耗
            Model_BaseCLCParameters m_Model_BaseCLCParameters_Cogeneration = new Model_BaseCLCParameters();
            m_Model_BaseCLCParameters_Cogeneration.ProcessName = "余热发电折算煤耗";    //获取工序名称
            m_Model_BaseCLCParameters_Cogeneration.MarterialsName = "熟料";    //获取物料名称
            m_Model_BaseCLCParameters_Cogeneration.ProcessCoalConsumption = m_Base_CoalConsumption.GetCogenerationCoalConsumption(myCogenerationProperties.GrossGeneration, myCogenerationProperties.OwnDemand, myClinkerProperties.MarterialsOutput, myCommonParameters).CaculateValue / 1000;
            m_Model_BaseCLCParameters_Cogeneration.ProcessMaterialsUsedQuantity = myClinkerProperties.MarterialsOutput;
            m_Model_BaseCLCParameters_Cogeneration.CoalWaterContent = 0;
            m_Model_BaseCLCParameters_Cogeneration.CoalLowCalorificValue = myCoalProperties.CoalLowCalorificValue;
            m_DeductionCLCParameters.Add(m_Model_BaseCLCParameters_Cogeneration);
            //计算余热利用折算煤耗
            Model_BaseCLCParameters m_Model_BaseCLCParameters_Recuperation = new Model_BaseCLCParameters();
            m_Model_BaseCLCParameters_Cogeneration.ProcessName = "计算余热利用折算煤耗";    //获取工序名称
            m_Model_BaseCLCParameters_Cogeneration.MarterialsName = "熟料";    //获取物料名称
            m_Model_BaseCLCParameters_Recuperation.ProcessCoalConsumption = m_Base_CoalConsumption.GetRecuperationCoalConsumption(myRecuperationProperties.ImportHeat, myRecuperationProperties.ExportHeat, myRecuperationProperties.LossHeat, myClinkerProperties.MarterialsOutput, myCommonParameters).CaculateValue / 1000;
            m_Model_BaseCLCParameters_Recuperation.ProcessMaterialsUsedQuantity = myClinkerProperties.MarterialsOutput;
            m_Model_BaseCLCParameters_Recuperation.CoalWaterContent = 0;
            m_Model_BaseCLCParameters_Recuperation.CoalLowCalorificValue = myCoalProperties.CoalLowCalorificValue;
            m_DeductionCLCParameters.Add(m_Model_BaseCLCParameters_Recuperation);

            m_Model_CaculateValueComparable = m_Base_CoalConsumption.GetClinkerCoalConsumptionComparable(m_ClinkerCLCParameters, m_DeductionCLCParameters, myCommonParameters, myClinkerProperties);
            m_Model_CaculateValueComparable.CaculateName = "可比熟料综合煤耗";
            return m_Model_CaculateValueComparable;
        }
        /// <summary>
        /// 计算可比熟料综合能耗
        /// </summary>
        /// <param name="myClinkerPowerConsumptionComparable">熟料可比综合电耗</param>
        /// <param name="myClinkerCoalConsumptionComparable">熟料可比综合煤耗</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>可比熟料综合能耗</returns>
        public Model_CaculateValue GetClinkerEnergyConsumptionComparable(decimal myClinkerPowerConsumptionComparable, decimal myClinkerCoalConsumptionComparable, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValueComparable = new Model_CaculateValue();
            m_Model_CaculateValueComparable = m_Base_EnergyConsumption.GetEnergyConsumptionComparable(myClinkerPowerConsumptionComparable, myClinkerCoalConsumptionComparable, myCommonParameters,"熟料");
            m_Model_CaculateValueComparable.CaculateName = "可比熟料综合能耗";
            return m_Model_CaculateValueComparable;
        }



        /////////////////////////////////////////水泥磨////////////////////////////////////////////
        /// <summary>
        /// 计算水泥综合电耗
        /// </summary>
        /// <param name="myCementProperties">水泥属性</param>
        /// <param name="myCementProcessMartieralsProperties">各耗电工序物料属性</param>
        /// <param name="myClinkerPowerConsumption">熟料综合电耗</param>
        /// <param name="myClinkerInput">熟料消耗量</param>
        /// <returns>水泥综合电耗</returns>
        public Model_CaculateValue GetCementPowerConsumption(Model_CementProperties myCementProperties, List<Model_MartieralsProperties> myCementProcessMartieralsProperties, decimal myClinkerPowerConsumption)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            List<Model_BaseELCParameters> m_CementBaseELCParameters = new List<Model_BaseELCParameters>(1);
            if (myCementProcessMartieralsProperties != null)
            {
                for (int i = 0; i < myCementProcessMartieralsProperties.Count; i++)
                {
                    Model_BaseELCParameters m_Model_BaseELCParameters = new Model_BaseELCParameters();
                    //求工序干基电耗
                    m_Model_BaseELCParameters.ProcessName = myCementProcessMartieralsProperties[i].ProcessName;    //获取工序名称
                    m_Model_BaseELCParameters.MarterialsName = myCementProcessMartieralsProperties[i].MarterialsName;    //获取物料名称
                    if (myCementProcessMartieralsProperties[i].MarterialsOutput != 0 && myCementProcessMartieralsProperties[i].MarterialsWaterContent < 1 && myCementProcessMartieralsProperties[i].MarterialsWaterContent >= 0)
                    {
                        m_Model_BaseELCParameters.ProcessElectricityConsumption = myCementProcessMartieralsProperties[i].ElectricityQuantity / (myCementProcessMartieralsProperties[i].MarterialsOutput * (1 - myCementProcessMartieralsProperties[i].MarterialsWaterContent));
                    }
                    else
                    {
                        m_Model_BaseELCParameters.ProcessElectricityConsumption = 0;
                    }
                    m_Model_BaseELCParameters.ProcessMaterialsUsedQuantity = myCementProcessMartieralsProperties[i].MarterialsInput * (1 - myCementProcessMartieralsProperties[i].MarterialsWaterContent);
                    m_CementBaseELCParameters.Add(m_Model_BaseELCParameters);
                }
            }
            if(myCementProperties != null)
            {
                Model_BaseELCParameters m_Model_ClinkerELCParameters = new Model_BaseELCParameters();
                //增加熟料综合电耗
                m_Model_ClinkerELCParameters.ProcessName = "熟料综合";    //获取工序名称
                m_Model_ClinkerELCParameters.MarterialsName = "熟料";    //获取物料名称
                m_Model_ClinkerELCParameters.ProcessElectricityConsumption = myClinkerPowerConsumption;
                m_Model_ClinkerELCParameters.ProcessMaterialsUsedQuantity = myCementProperties.ClinkerInput;
                m_CementBaseELCParameters.Add(m_Model_ClinkerELCParameters);

                m_Model_CaculateValue = m_Base_PowConsumption.GetPowerConsumption(m_CementBaseELCParameters, myCementProperties.MarterialsOutput, "水泥");
            }
            m_Model_CaculateValue.CaculateName = "水泥综合电耗";
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算水泥综合煤耗
        /// </summary>
        /// <param name="myCementProperties">水泥属性</param>
        /// <param name="myCoalProperties">煤粉属性</param>
        /// <param name="myCementProcessMartieralsProperties">各耗煤工序物料属性</param>
        /// <param name="myClinkerCoalConsumption">熟料综合煤耗</param>
        /// <param name="myClinkerInput">熟料消耗量</param>
        /// <returns>水泥综合煤耗</returns>
        public Model_CaculateValue GetCementCoalConsumption(Model_CementProperties myCementProperties, Model_CoalProperties myCoalProperties, List<Model_MartieralsProperties> myCementProcessMartieralsProperties, Model_CommonParameters myCommonParameters, decimal myClinkerCoalConsumption)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            List<Model_BaseCLCParameters> m_CementBaseCLCParameters = new List<Model_BaseCLCParameters>(1);
            if (myCementProcessMartieralsProperties != null)
            {
                for (int i = 0; i < myCementProcessMartieralsProperties.Count; i++)
                {
                    //求工序干基煤耗
                    Model_BaseCLCParameters m_Model_CementCLCParameters = new Model_BaseCLCParameters();
                    m_Model_CementCLCParameters.ProcessName = myCementProcessMartieralsProperties[i].ProcessName;    //获取工序名称
                    m_Model_CementCLCParameters.MarterialsName = myCementProcessMartieralsProperties[i].MarterialsName;    //获取物料名称
                    if (myCementProcessMartieralsProperties[i].MarterialsOutput != 0 && myCementProcessMartieralsProperties[i].MarterialsWaterContent < 1 && myCementProcessMartieralsProperties[i].MarterialsWaterContent >= 0)
                    {
                        m_Model_CementCLCParameters.ProcessCoalConsumption = (myCementProcessMartieralsProperties[i].CoalQuantity * (1 - myCoalProperties.CoalWaterContent)) / (myCementProcessMartieralsProperties[i].MarterialsOutput * (1 - myCementProcessMartieralsProperties[i].MarterialsWaterContent));
                    }
                    else
                    {
                        m_Model_CementCLCParameters.ProcessCoalConsumption = 0;
                    }
                    m_Model_CementCLCParameters.ProcessMaterialsUsedQuantity = myCementProcessMartieralsProperties[i].MarterialsInput * (1 - myCementProcessMartieralsProperties[i].MarterialsWaterContent);
                    m_Model_CementCLCParameters.CoalWaterContent = myCementProcessMartieralsProperties[i].MarterialsWaterContent;
                    m_Model_CementCLCParameters.CoalLowCalorificValue = myCoalProperties.CoalLowCalorificValue;
                    m_CementBaseCLCParameters.Add(m_Model_CementCLCParameters);
                }
            }
            if (myCementProperties != null)
            {
                Model_BaseCLCParameters m_Model_ClinkerCLCParameters = new Model_BaseCLCParameters();
                //增加熟料综合煤耗
                m_Model_ClinkerCLCParameters.ProcessName = "熟料综合";     //获取工序名称
                m_Model_ClinkerCLCParameters.MarterialsName = "熟料";          //获取物料名称
                m_Model_ClinkerCLCParameters.ProcessCoalConsumption = myClinkerCoalConsumption/1000;
                m_Model_ClinkerCLCParameters.ProcessMaterialsUsedQuantity = myCementProperties.ClinkerInput;
                m_Model_ClinkerCLCParameters.CoalLowCalorificValue = myCommonParameters.StandardCalorificValue;
                m_Model_ClinkerCLCParameters.CoalWaterContent = 0;
                m_CementBaseCLCParameters.Add(m_Model_ClinkerCLCParameters);

                m_Model_CaculateValue = m_Base_CoalConsumption.GetCoalConsumption(m_CementBaseCLCParameters, myCementProperties.MarterialsOutput, myCommonParameters.StandardCalorificValue,"水泥");
            }
            m_Model_CaculateValue.CaculateName = "水泥综合煤耗";
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算水泥综合能耗
        /// </summary>
        /// <param name="myCementPowerConsumption">水泥综合电耗</param>
        /// <param name="myCementCoalConsumption">水泥综合煤耗</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>水泥综合能耗</returns>
        public Model_CaculateValue GetCementEnergyConsumption(decimal myCementPowerConsumption, decimal myCementCoalConsumption, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            m_Model_CaculateValue = m_Base_EnergyConsumption.GetEnergyConsumption(myCementPowerConsumption, myCementCoalConsumption, myCommonParameters,"水泥");
            m_Model_CaculateValue.CaculateName = "水泥综合能耗";
            return m_Model_CaculateValue;
        }
        /// <summary>
        /// 计算可比水泥综合电耗
        /// </summary>
        /// <param name="myCementProperties">水泥属性</param>
        /// <param name="myCementProcessMartieralsProperties">各耗电工序物料属性</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <param name="myClinkerPowerConsumption">熟料综合电耗</param>
        /// <param name="myClinkerInput">熟料消耗量</param>
        /// <returns>可比水泥综合电耗</returns>
        public Model_CaculateValue GetCementPowerConsumptionComparable(Model_CementProperties myCementProperties, List<Model_MartieralsProperties> myCementProcessMartieralsProperties, Model_CommonParameters myCommonParameters, decimal myClinkerPowerConsumption)
        {
            Model_CaculateValue m_Model_CaculateValueComparable = new Model_CaculateValue();
            List<Model_BaseELCParameters> m_CementELCParameters = new List<Model_BaseELCParameters>();

            Model_BaseELCParameters m_Model_BaseELCParameters = new Model_BaseELCParameters();
            m_Model_BaseELCParameters.ProcessName = "水泥综合电耗";     //获取工序名称
            m_Model_BaseELCParameters.MarterialsName = "水泥";          //获取物料名称
            m_Model_BaseELCParameters.ProcessElectricityConsumption = GetCementPowerConsumption(myCementProperties, myCementProcessMartieralsProperties, myClinkerPowerConsumption).CaculateValue;
            m_Model_BaseELCParameters.ProcessMaterialsUsedQuantity = myCementProperties.MarterialsOutput;
            m_CementELCParameters.Add(m_Model_BaseELCParameters);
            m_Model_CaculateValueComparable = m_Base_PowConsumption.GetCementPowerConsumptionComparable(m_CementELCParameters, myCommonParameters, myCementProperties);
            m_Model_CaculateValueComparable.CaculateName = "可比水泥综合电耗";
            return m_Model_CaculateValueComparable;
        }
        /// <summary>
        /// 计算可比水泥综合煤耗
        /// </summary>
        /// <param name="myCementProperties">水泥属性</param>
        /// <param name="myCoalProperties">煤粉属性</param>
        /// <param name="myCementProcessMartieralsProperties">各耗煤工序物料属性</param>
        /// <param name="myClinkerCoalConsumption">熟料综合煤耗</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>可比水泥综合煤耗</returns>
        public Model_CaculateValue GetCementCoalConsumptionComparable(Model_CementProperties myCementProperties, Model_CoalProperties myCoalProperties, List<Model_MartieralsProperties> myCementProcessMartieralsProperties,
            decimal myClinkerCoalConsumptionComparable, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValueComparable = new Model_CaculateValue();
            List<Model_BaseCLCParameters> m_CementBaseCLCParameters = new List<Model_BaseCLCParameters>(1);
            if (myCementProcessMartieralsProperties != null)
            {
                for (int i = 0; i < myCementProcessMartieralsProperties.Count; i++)
                {
                    //求工序干基煤耗
                    Model_BaseCLCParameters m_Model_BaseCLCParameters = new Model_BaseCLCParameters();
                    m_Model_BaseCLCParameters.ProcessName = myCementProcessMartieralsProperties[i].ProcessName;                //获取工序名称
                    m_Model_BaseCLCParameters.MarterialsName = myCementProcessMartieralsProperties[i].MarterialsName;          //获取物料名称
                    if (myCementProcessMartieralsProperties[i].MarterialsOutput != 0 && myCementProcessMartieralsProperties[i].MarterialsWaterContent < 1 && myCementProcessMartieralsProperties[i].MarterialsWaterContent >= 0)
                    {
                        m_Model_BaseCLCParameters.ProcessCoalConsumption = (myCementProcessMartieralsProperties[i].CoalQuantity * (1 - myCoalProperties.CoalWaterContent)) / (myCementProcessMartieralsProperties[i].MarterialsOutput * (1 - myCementProcessMartieralsProperties[i].MarterialsWaterContent)) / 1000;
                    }
                    else
                    {
                        m_Model_BaseCLCParameters.ProcessCoalConsumption = 0;
                    }
                    m_Model_BaseCLCParameters.ProcessMaterialsUsedQuantity = myCementProcessMartieralsProperties[i].MarterialsInput * (1 - myCementProcessMartieralsProperties[i].MarterialsWaterContent);
                    m_Model_BaseCLCParameters.CoalLowCalorificValue = myCoalProperties.CoalLowCalorificValue;
                    m_Model_BaseCLCParameters.CoalWaterContent = myCementProcessMartieralsProperties[i].MarterialsWaterContent;
                    m_CementBaseCLCParameters.Add(m_Model_BaseCLCParameters);
                }
            }
            if (myCementProperties != null)
            {
                Model_BaseCLCParameters m_Model_CementCLCParameters = new Model_BaseCLCParameters();
                //增加熟料综合煤耗
                m_Model_CementCLCParameters.ProcessName = "可比熟料综合煤耗";    //获取工序名称
                m_Model_CementCLCParameters.MarterialsName = "熟料";             //获取物料名称
                m_Model_CementCLCParameters.ProcessCoalConsumption = myClinkerCoalConsumptionComparable / 1000;
                m_Model_CementCLCParameters.ProcessMaterialsUsedQuantity = myCementProperties.ClinkerInput;
                m_Model_CementCLCParameters.CoalLowCalorificValue = myCommonParameters.StandardCalorificValue;
                m_Model_CementCLCParameters.CoalWaterContent = 0;
                m_CementBaseCLCParameters.Add(m_Model_CementCLCParameters);

                m_Model_CaculateValueComparable = m_Base_CoalConsumption.GetCementCoalConsumptionComparable(m_CementBaseCLCParameters, myCommonParameters, myCementProperties);
            }
            m_Model_CaculateValueComparable.CaculateName = "可比水泥综合煤耗";
            return m_Model_CaculateValueComparable;
        }
        /// <summary>
        /// 计算可比水泥综合能耗
        /// </summary>
        /// <param name="myCementPowerConsumptionComparable">水泥可比综合电耗</param>
        /// <param name="myCementCoalConsumptionComparable">水泥可比综合煤耗</param>
        /// <param name="myCommonParameters">公共参数</param>
        /// <returns>可比水泥综合能耗</returns>
        public Model_CaculateValue GetCementEnergyConsumptionComparable(decimal myCementPowerConsumptionComparable, decimal myCementCoalConsumptionComparable, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValueComparable = new Model_CaculateValue();
            m_Model_CaculateValueComparable = m_Base_EnergyConsumption.GetEnergyConsumptionComparable(myCementPowerConsumptionComparable, myCementCoalConsumptionComparable, myCommonParameters,"水泥");
            m_Model_CaculateValueComparable.CaculateName = "可比水泥综合能耗";
            return m_Model_CaculateValueComparable;
        }
        /// <summary>
        /// 计算余热发电折算煤耗
        /// </summary>
        /// <param name="myGrossGeneration">余热发电总发电量</param>
        /// <param name="myOwnDemand">余热发电自用电量</param>
        /// <param name="myClinkerOutput">熟料产量</param>
        /// <param name="myCommonParameters">公共参数</param>
        ///
        public Model_CaculateValue GetCogenerationCoalConsumption(decimal myGrossGeneration, decimal myOwnDemand, decimal myClinkerOutput, Model_CommonParameters myCommonParameters)
        {
            Model_CaculateValue m_Model_CaculateValue = new Model_CaculateValue();
            m_Model_CaculateValue = m_Base_CoalConsumption.GetCogenerationCoalConsumption(myGrossGeneration, myOwnDemand, myClinkerOutput, myCommonParameters);
            m_Model_CaculateValue.CaculateName = "余热发电折算煤耗";
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
            m_Model_CaculateValue =  m_Base_CoalConsumption.GetRecuperationCoalConsumption(myImportHeat, myExportHeat, myLossHeat, myClinkerOutput, myCommonParameters);
            m_Model_CaculateValue.CaculateName = "余热利用折算煤耗";
            return m_Model_CaculateValue;
        }
    }
}
