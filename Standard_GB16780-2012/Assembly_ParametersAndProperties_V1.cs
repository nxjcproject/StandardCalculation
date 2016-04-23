using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Standard_GB16780_2012
{
    public class Assembly_ParametersAndProperties_V1
    {
        private Model_ClinkerProperties _ClinkerProperties;     //熟料属性
        private Model_CementProperties _CementProperties;       //水泥属性
        private Model_CoalProperties _CoalProperties;           //煤粉属性
        private Model_CogenerationProperties _CogenerationProperties;    //余热发电属性
        private Model_RecuperationProperties _RecuperationProperties;    //余热利用属性
        private List<Model_MartieralsProperties> _ClinkerProcessPowerProperties;    //熟料工序用电属性
        private List<Model_MartieralsProperties> _ClinkerProcessCoalProperties;     //熟料工序用煤属性
        private List<Model_MartieralsProperties> _CementProcessPowerProperties;     //水泥磨工序用电属性
        private List<Model_MartieralsProperties> _CementProcessCoalProperties;      //水泥磨工序用煤属性
        private Model_CommonParameters _CommonParameters;                           //公共参数
        public Assembly_ParametersAndProperties_V1()
        {
            _CementProperties = new Model_CementProperties();       //水泥属性
            _ClinkerProperties = new Model_ClinkerProperties();     //熟料属性
            _CoalProperties = new Model_CoalProperties();           //煤粉属性
            _CogenerationProperties = new Model_CogenerationProperties();    //余热发电属性
            _RecuperationProperties = new Model_RecuperationProperties();    //余热利用属性
            _ClinkerProcessPowerProperties = new List<Model_MartieralsProperties>(1);    //熟料工序用电属性
            _ClinkerProcessCoalProperties = new List<Model_MartieralsProperties>(1);     //熟料工序用煤属性
            _CementProcessPowerProperties = new List<Model_MartieralsProperties>(1);     //水泥磨工序用电属性
            _CementProcessCoalProperties = new List<Model_MartieralsProperties>(0);      //水泥磨工序用煤属性
            _CommonParameters = new Model_CommonParameters();                           //公共参数
        }
        public void ClearPropertiesList()
        {
            _ClinkerProcessPowerProperties.Clear();
            _ClinkerProcessCoalProperties.Clear();
            _CementProcessPowerProperties.Clear();
            _CementProcessCoalProperties.Clear();
        }
        public  Model_ClinkerProperties ClinkerProperties
        {
            get
            {
                return _ClinkerProperties;
            }
            set
            {
                _ClinkerProperties = value;
            }
        }
        public Model_CementProperties CementProperties
        {
            get
            {
                return _CementProperties;
            }
            set
            {
                _CementProperties = value;
            }
        }
        public Model_CoalProperties CoalProperties
        {
            get
            {
                return _CoalProperties;
            }
            set
            {
                _CoalProperties = value;
            }
        }
        public Model_CogenerationProperties CogenerationProperties
        {
            get
            {
                return _CogenerationProperties;
            }
            set
            {
                _CogenerationProperties = value;
            }
        }
        public Model_RecuperationProperties RecuperationProperties
        {
            get
            {
                return _RecuperationProperties;
            }
            set
            {
                _RecuperationProperties = value;
            }
        }
        public Model_CommonParameters CommonParameters
        {
            get
            {
                return _CommonParameters;
            }
            set
            {
                _CommonParameters = value;
            }
        }
        /// <summary>
        /// 设置熟料电耗工序
        /// </summary>
        /// <param name="myProcessData">工序过程数据</param>
        public void SetClinkerProcessPowerProperties(Dictionary<string,decimal> myProcessData)
        {
            //rawMaterialsPreparation:生料制备
            Model_MartieralsProperties m_rawMaterialsPreparation = new Model_MartieralsProperties();
            m_rawMaterialsPreparation.ProcessName = "生料制备";
            m_rawMaterialsPreparation.MarterialsName = "生料";
            if (myProcessData.ContainsKey("rawMaterialsPreparation_ElectricityQuantity"))
            {
                m_rawMaterialsPreparation.ElectricityQuantity = myProcessData["rawMaterialsPreparation_ElectricityQuantity"];
            }
            if(myProcessData.ContainsKey("clinker_MixtureMaterialsOutput"))
            {
                m_rawMaterialsPreparation.MarterialsOutput = myProcessData["clinker_MixtureMaterialsOutput"];
            }
            if (myProcessData.ContainsKey("clinker_MixtureMaterialsInput"))
            {
                m_rawMaterialsPreparation.MarterialsInput = myProcessData["clinker_MixtureMaterialsInput"];
            }
            _ClinkerProcessPowerProperties.Add(m_rawMaterialsPreparation);
            //coalPreparation：煤粉制备

            Model_MartieralsProperties m_coalPreparation = new Model_MartieralsProperties();
            m_coalPreparation.ProcessName = "煤粉制备";
            m_coalPreparation.MarterialsName = "煤粉";
            if (myProcessData.ContainsKey("coalPreparation_ElectricityQuantity"))
            {
                m_coalPreparation.ElectricityQuantity = myProcessData["coalPreparation_ElectricityQuantity"];
            }
            if (myProcessData.ContainsKey("clinker_PulverizedCoalOutput"))
            {
                m_coalPreparation.MarterialsOutput = myProcessData["clinker_PulverizedCoalOutput"];
            }
            if (myProcessData.ContainsKey("clinker_PulverizedCoalInput"))
            {
                m_coalPreparation.MarterialsInput = myProcessData["clinker_PulverizedCoalInput"];
            }
            _ClinkerProcessPowerProperties.Add(m_coalPreparation);
            //clinkerBurning：熟料烧成
            Model_MartieralsProperties m_clinkerBurning = new Model_MartieralsProperties();
            m_clinkerBurning.ProcessName = "熟料烧成";
            m_clinkerBurning.MarterialsName = "熟料";
            if (myProcessData.ContainsKey("clinkerBurning_ElectricityQuantity"))
            {
                m_clinkerBurning.ElectricityQuantity = myProcessData["clinkerBurning_ElectricityQuantity"];
            }
            if (myProcessData.ContainsKey("clinker_ClinkerOutput"))
            {
                m_clinkerBurning.MarterialsOutput = myProcessData["clinker_ClinkerOutput"];
                m_clinkerBurning.MarterialsInput = m_clinkerBurning.MarterialsOutput;
            }
            _ClinkerProcessPowerProperties.Add(m_clinkerBurning);
            //ClinkerOutsourcing：外购熟料烧成
            //Model_MartieralsProperties m_ClinkerOutsourcing = new Model_MartieralsProperties();
            //m_ClinkerOutsourcing.ProcessName = "外购熟料烧成";
            //m_ClinkerOutsourcing.MarterialsName = "外购熟料";
            //if(myProcessData.ContainsKey("clinker_ClinkerOutsourcingInput"))
            //{
            //    m_ClinkerOutsourcing.ElectricityQuantity = ClinkerProperties.ClinkerOutsourcing_PowerConsumption * myProcessData["clinker_ClinkerOutsourcingInput"];
            //    m_ClinkerOutsourcing.MarterialsOutput = myProcessData["clinker_ClinkerOutsourcingInput"];
            //    m_ClinkerOutsourcing.MarterialsInput = m_ClinkerOutsourcing.MarterialsOutput;
            //}
            //_ClinkerProcessPowerProperties.Add(m_ClinkerOutsourcing);
            //kilnSystem:废气处理
            Model_MartieralsProperties m_kilnSystem = new Model_MartieralsProperties();
            m_kilnSystem.ProcessName = "废气处理";
            m_kilnSystem.MarterialsName = "熟料";
            if (myProcessData.ContainsKey("kilnSystem_ElectricityQuantity"))
            {
                m_kilnSystem.ElectricityQuantity = myProcessData["kilnSystem_ElectricityQuantity"];
            }
            if (myProcessData.ContainsKey("clinker_ClinkerOutput"))
            {
                m_kilnSystem.MarterialsOutput = myProcessData["clinker_ClinkerOutput"];
                m_kilnSystem.MarterialsInput = m_kilnSystem.MarterialsOutput;
            }
            _ClinkerProcessPowerProperties.Add(m_kilnSystem);

            //RawMealHomogenization:生料均化
            Model_MartieralsProperties m_RawMealHomogenization = new Model_MartieralsProperties();
            m_RawMealHomogenization.ProcessName = "生料均化";
            m_RawMealHomogenization.MarterialsName = "熟料";
            if (myProcessData.ContainsKey("rawMealHomogenization_ElectricityQuantity"))
            {
                m_RawMealHomogenization.ElectricityQuantity = myProcessData["rawMealHomogenization_ElectricityQuantity"];
            }
            if (myProcessData.ContainsKey("clinker_ClinkerOutput"))
            {
                m_RawMealHomogenization.MarterialsOutput = myProcessData["clinker_ClinkerOutput"];
                m_RawMealHomogenization.MarterialsInput = m_RawMealHomogenization.MarterialsOutput;
            }
            _ClinkerProcessPowerProperties.Add(m_RawMealHomogenization);

            //auxiliaryProduction:辅助用电
            Model_MartieralsProperties m_auxiliaryProduction = new Model_MartieralsProperties();
            m_auxiliaryProduction.ProcessName = "辅助用电";
            m_auxiliaryProduction.MarterialsName = "熟料";
            if (myProcessData.ContainsKey("auxiliaryProduction_ElectricityQuantity"))
            {
                m_auxiliaryProduction.ElectricityQuantity = myProcessData["auxiliaryProduction_ElectricityQuantity"];
            }
            if (myProcessData.ContainsKey("clinker_ClinkerOutput"))
            {
                m_auxiliaryProduction.MarterialsOutput = myProcessData["clinker_ClinkerOutput"];
                m_auxiliaryProduction.MarterialsInput = m_auxiliaryProduction.MarterialsOutput;
            }
            _ClinkerProcessPowerProperties.Add(m_auxiliaryProduction);
        }
        /// <summary>
        /// 获得熟料工序列表
        /// </summary>
        /// <returns>熟料工序列表</returns>
        public List<Model_MartieralsProperties> GetClinkerProcessPowerProperties()
        {
            return _ClinkerProcessPowerProperties;
        }
        /// <summary>
        /// 设置煤耗工序
        /// </summary>
        /// <param name="myProcessData">工序过程数据</param>
        public void SetClinkerProcessCoalProperties(Dictionary<string, decimal> myProcessData)
        {
            //coalPreparation：煤粉消耗
            Model_MartieralsProperties m_coalInput = new Model_MartieralsProperties();
            m_coalInput.ProcessName = "熟料烧成";
            m_coalInput.MarterialsName = "熟料";
            if (myProcessData.ContainsKey("clinker_PulverizedCoalInput"))
            {
                m_coalInput.CoalQuantity = myProcessData["clinker_PulverizedCoalInput"];
            }
            //if (myProcessData.ContainsKey("clinker_ClinkerOutput"))
            //{
            //    m_coalInput.MarterialsInput = myProcessData["clinker_ClinkerOutput"];
            //    m_coalInput.MarterialsOutput = m_coalInput.MarterialsInput;
            //}
            m_coalInput.MarterialsInput = 1;
            m_coalInput.MarterialsOutput = 1;
            _ClinkerProcessCoalProperties.Add(m_coalInput);
        }
        /// <summary>
        /// 获得煤耗工序列表
        /// </summary>
        /// <returns>煤耗工序列表</returns>
        public List<Model_MartieralsProperties> GetClinkerProcessCoalProperties()
        {
            return _ClinkerProcessCoalProperties;
        }
        /// <summary>
        /// 设置水泥电耗工序
        /// </summary>
        /// <param name="myProcessData">工序过程数据</param>
        public void SetCementProcessPowerProperties(Dictionary<string, decimal> myProcessData)
        {
            //cementGrind:水泥粉磨
            Model_MartieralsProperties m_cementGrind = new Model_MartieralsProperties();
            m_cementGrind.ProcessName = "水泥粉磨";
            m_cementGrind.MarterialsName = "水泥";
            if (myProcessData.ContainsKey("cementGrind_ElectricityQuantity"))
            {
                m_cementGrind.ElectricityQuantity = myProcessData["cementGrind_ElectricityQuantity"];
            }
            if (myProcessData.ContainsKey("cement_CementOutput"))
            {
                m_cementGrind.MarterialsOutput = myProcessData["cement_CementOutput"];
                m_cementGrind.MarterialsInput = m_cementGrind.MarterialsOutput;
            }
            _CementProcessPowerProperties.Add(m_cementGrind);
            //hybridMaterialsPreparation:混合材制备
            Model_MartieralsProperties m_hybridMaterialsPreparation = new Model_MartieralsProperties();
            m_hybridMaterialsPreparation.ProcessName = "混合材制备";
            m_hybridMaterialsPreparation.MarterialsName = "混合材常数";
            if (myProcessData.ContainsKey("hybridMaterialsPreparation_ElectricityQuantity"))
            {
                m_hybridMaterialsPreparation.ElectricityQuantity = myProcessData["hybridMaterialsPreparation_ElectricityQuantity"];
                m_hybridMaterialsPreparation.MarterialsOutput = 1;
                m_hybridMaterialsPreparation.MarterialsInput = 1;
            }
            //if (myProcessData.ContainsKey("cement_hybridMaterialsOutput"))
            //{
            //    m_hybridMaterialsPreparation.MarterialsOutput = myProcessData["cement_hybridMaterialsOutput"];
            //}
            //if (myProcessData.ContainsKey("cement_hybridMaterialsIutput"))
            //{
            //    m_hybridMaterialsPreparation.MarterialsInput = myProcessData["cement_hybridMaterialsIutput"];
            //}
            _CementProcessPowerProperties.Add(m_hybridMaterialsPreparation);
            //clinkerTransport:熟料输送
            Model_MartieralsProperties m_clinkerTransport = new Model_MartieralsProperties();
            m_clinkerTransport.ProcessName = "熟料输送";
            m_clinkerTransport.MarterialsName = "熟料常数";
            if (myProcessData.ContainsKey("clinkerTransport_ElectricityQuantity"))
            {
                m_clinkerTransport.ElectricityQuantity = myProcessData["clinkerTransport_ElectricityQuantity"];
                m_clinkerTransport.MarterialsOutput = 1;
                m_clinkerTransport.MarterialsInput = 1;
            }
            _CementProcessPowerProperties.Add(m_clinkerTransport);
            //cementPacking:水泥包装
            Model_MartieralsProperties m_cementPacking = new Model_MartieralsProperties();
            m_cementPacking.ProcessName = "水泥包装";
            m_cementPacking.MarterialsName = "水泥";
            if (myProcessData.ContainsKey("cementPacking_ElectricityQuantity_All"))
            {
                m_cementPacking.ElectricityQuantity = myProcessData["cementPacking_ElectricityQuantity_All"];
            }
            if (myProcessData.ContainsKey("cement_CementOutput_All"))
            {
                m_cementPacking.MarterialsOutput = myProcessData["cement_CementOutput_All"];
            }
            if (myProcessData.ContainsKey("cement_CementOutput"))
            {
                m_cementPacking.MarterialsInput = myProcessData["cement_CementOutput"];
            }
            _CementProcessPowerProperties.Add(m_cementPacking);
            //ClinkerOutsourcing：外购熟料烧成
            Model_MartieralsProperties m_ClinkerOutsourcing = new Model_MartieralsProperties();
            m_ClinkerOutsourcing.ProcessName = "外购熟料烧成";
            m_ClinkerOutsourcing.MarterialsName = "外购熟料";
            if (myProcessData.ContainsKey("clinker_ClinkerOutsourcingInput"))
            {
                m_ClinkerOutsourcing.ElectricityQuantity = ClinkerProperties.ClinkerOutsourcing_PowerConsumption * myProcessData["clinker_ClinkerOutsourcingInput"];
                m_ClinkerOutsourcing.MarterialsOutput = myProcessData["clinker_ClinkerOutsourcingInput"];
                m_ClinkerOutsourcing.MarterialsInput = m_ClinkerOutsourcing.MarterialsOutput;
            }
            _CementProcessPowerProperties.Add(m_ClinkerOutsourcing);

            //auxiliaryProduction:辅助用电
            Model_MartieralsProperties m_auxiliaryProduction = new Model_MartieralsProperties();
            m_auxiliaryProduction.ProcessName = "辅助用电";
            m_auxiliaryProduction.MarterialsName = "水泥";
            if (myProcessData.ContainsKey("auxiliaryProduction_ElectricityQuantity"))
            {
                m_auxiliaryProduction.ElectricityQuantity = myProcessData["auxiliaryProduction_ElectricityQuantity"];
            }
            if (myProcessData.ContainsKey("cement_CementOutput"))
            {
                m_auxiliaryProduction.MarterialsOutput = myProcessData["cement_CementOutput"];
                m_auxiliaryProduction.MarterialsInput = m_auxiliaryProduction.MarterialsOutput;
            }
            _CementProcessPowerProperties.Add(m_auxiliaryProduction);
           
        }
        /// <summary>
        /// 获得水泥电耗工序列表
        /// </summary>
        /// <returns></returns>
        public List<Model_MartieralsProperties> GetCementProcessPowerProperties()
        {
            return _CementProcessPowerProperties;
        }
        /// <summary>
        /// 设置水泥煤耗工序列表
        /// </summary>
        /// <param name="myProcessData">煤耗工序过程数据</param>
        public void SetCementProcessCoalProperties(Dictionary<string, decimal> myProcessData)
        {
            //ClinkerOutsourcing：外购熟料烧成
            Model_MartieralsProperties m_ClinkerOutsourcing = new Model_MartieralsProperties();
            m_ClinkerOutsourcing.ProcessName = "外购熟料烧成";
            m_ClinkerOutsourcing.MarterialsName = "外购熟料";
            if (myProcessData.ContainsKey("clinker_ClinkerOutsourcingInput"))
            {
                m_ClinkerOutsourcing.CoalQuantity = 1 * ClinkerProperties.ClinkerOutsourcing_CoalConsumption * CommonParameters.StandardCalorificValue / CoalProperties.CoalLowCalorificValue;
                m_ClinkerOutsourcing.MarterialsOutput = 1000;
                m_ClinkerOutsourcing.MarterialsInput = myProcessData["clinker_ClinkerOutsourcingInput"];
            }
            _CementProcessCoalProperties.Add(m_ClinkerOutsourcing);
        }
        /// <summary>
        /// 设置其它主要物料属性
        /// </summary>
        /// <param name="myProcessData"></param>
        public void SetMainMaterialsProperties(Dictionary<string, decimal> myProcessData)
        {
            if (myProcessData.ContainsKey("clinker_ClinkerOutput"))    //熟料产量
            {
                _ClinkerProperties.MarterialsOutput = myProcessData["clinker_ClinkerOutput"];
            }

            if (myProcessData.ContainsKey("clinker_ClinkerInput"))     //水泥用熟料消耗量
            {
                _CementProperties.ClinkerInput = myProcessData["clinker_ClinkerInput"];
            }
            if (myProcessData.ContainsKey("cement_CementOutput"))      //水泥产量
            {
                _CementProperties.MarterialsOutput = myProcessData["cement_CementOutput"];
            }
            if (myProcessData.ContainsKey("clinkerElectricityGeneration_ElectricityQuantity"))      //余热发电量
            {
                _CogenerationProperties.GrossGeneration = myProcessData["clinkerElectricityGeneration_ElectricityQuantity"];
            }
            if (myProcessData.ContainsKey("electricityOwnDemand_ElectricityQuantity"))             //余热自用电量
            {
                _CogenerationProperties.OwnDemand = myProcessData["electricityOwnDemand_ElectricityQuantity"];
            }
        }
        /// <summary>
        /// 获得煤耗工序列表
        /// </summary>
        /// <returns>煤耗工序列表</returns>
        public List<Model_MartieralsProperties> GetCementProcessCoalProperties()
        {
            return _CementProcessCoalProperties;
        }
        /// <summary>
        /// 工序过程数据datatable 转dictionary
        /// </summary>
        /// <param name="myProcessDataTable">工序过程数据datatable</param>
        /// <param name="myKeyColumn">Key字段</param>
        /// <param name="myValueColumn">值字段</param>
        /// <returns>工序过程数据dictionary</returns>
        public Dictionary<string, decimal> GetProcessData(DataTable myProcessDataTable, string myKeyColumn, string myValueColumn)
        {
            Dictionary<string, decimal> m_ProcessData = new Dictionary<string, decimal>();
            if (myProcessDataTable != null)
            {
                for (int i = 0; i < myProcessDataTable.Rows.Count; i++)
                {
                    if (!m_ProcessData.ContainsKey((string)myProcessDataTable.Rows[i][myKeyColumn]))
                    {
                        m_ProcessData.Add((string)myProcessDataTable.Rows[i][myKeyColumn], (decimal)myProcessDataTable.Rows[i][myValueColumn]);
                    }
                }
            }
            return m_ProcessData;
        }
        /// <summary>
        /// 获得加权平均值
        /// </summary>
        /// <param name="myValueTable">数据表</param>
        /// <param name="myTargetValueColumn">目标值字段</param>
        /// <param name="myWeightedValueColumn">权值字段</param>
        /// <param name="myDefaultValue">默认值字段</param>
        /// <returns>加权平均值</returns>
        public decimal GetWeightedAverageValue(DataTable myValueTable, string myTargetValueColumn, string myWeightedValueColumn, decimal myDefaultValue)
        {
            decimal m_WeightedAverageValue = myDefaultValue;
            decimal m_TotalTargetValue = 0m;                    //计算目标值
            decimal m_TotalWeightedValue = 0m;                  //权值
            if (myValueTable != null)
            {
                for (int i = 0; i < myValueTable.Rows.Count; i++)
                {
                    m_TotalTargetValue = m_TotalTargetValue + (decimal)myValueTable.Rows[i][myTargetValueColumn] * (decimal)myValueTable.Rows[i][myWeightedValueColumn];
                    m_TotalWeightedValue = m_TotalWeightedValue + (decimal)myValueTable.Rows[i][myWeightedValueColumn];
                }
            }
            if (m_TotalWeightedValue != 0)
            {
                m_WeightedAverageValue = m_TotalTargetValue / m_TotalWeightedValue;
            }
            return m_WeightedAverageValue;
        }
        public decimal GetWeightedAverageValue(DataRow[] myValueRows, string myTargetValueColumn, string myWeightedValueColumn, decimal myDefaultValue)
        {
            decimal m_WeightedAverageValue = myDefaultValue;
            decimal m_TotalTargetValue = 0m;                    //计算目标值
            decimal m_TotalWeightedValue = 0m;                  //权值
            if (myValueRows != null)
            {
                for (int i = 0; i < myValueRows.Length; i++)
                {
                    m_TotalTargetValue = m_TotalTargetValue + (decimal)myValueRows[i][myTargetValueColumn] * (decimal)myValueRows[i][myWeightedValueColumn];
                    m_TotalWeightedValue = m_TotalWeightedValue + (decimal)myValueRows[i][myWeightedValueColumn];
                }
            }
            if (m_TotalWeightedValue != 0)
            {
                m_WeightedAverageValue = m_TotalTargetValue / m_TotalWeightedValue;
            }
            return m_WeightedAverageValue;
        }
    }
}
