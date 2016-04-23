using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Standard_GB16780_2012
{
    public class Function_EnergyConsumption_V1
    {

        private Standard_GB16780_2012.Assembly_ParametersAndProperties_V1 ParametersAndProperties;
        private Standard_GB16780_2012.Assembly_EnergyConsumption EnergyConsumption;
        public Function_EnergyConsumption_V1()
        {
            ParametersAndProperties = new Standard_GB16780_2012.Assembly_ParametersAndProperties_V1();
            EnergyConsumption = new Standard_GB16780_2012.Assembly_EnergyConsumption();
        }
        public void LoadComprehensiveData(DataTable myProcessDataTable, Parameters_ComprehensiveData myComprehensiveData, string myKeyColumn, string myValueColumn)
        {
            Parameters_ComparableData m_ComparableData = new Parameters_ComparableData();
            m_ComparableData.ClinkerOutsourcing_PowerConsumption = myComprehensiveData.ClinkerOutsourcing_PowerConsumption;    //外购熟料综合电耗
            m_ComparableData.ClinkerOutsourcing_CoalConsumption = myComprehensiveData.ClinkerOutsourcing_CoalConsumption;     //外购熟料综合煤耗
            m_ComparableData.CoalLowCalorificValue = myComprehensiveData.CoalLowCalorificValue;                    //煤粉低位发热量
            m_ComparableData.CoalWaterContent = myComprehensiveData.CoalWaterContent;                              //煤粉水分
            m_ComparableData.ElectricityToCoalFactor = myComprehensiveData.ElectricityToCoalFactor;                //用电折合用煤系数
            m_ComparableData.StandardCalorificValue = myComprehensiveData.StandardCalorificValue;                  //标准煤发热量
            LoadData(myProcessDataTable, m_ComparableData, myKeyColumn, myValueColumn);
        }
        public void LoadComprehensiveData(DataTable myProcessDataTable, Parameters_ComprehensiveData myComprehensiveData, string myKeyColumn, string myValueColumn, string myPrefix)
        {
            Parameters_ComparableData m_ComparableData = new Parameters_ComparableData();
            m_ComparableData.ClinkerOutsourcing_PowerConsumption = myComprehensiveData.ClinkerOutsourcing_PowerConsumption;    //外购熟料综合电耗
            m_ComparableData.ClinkerOutsourcing_CoalConsumption = myComprehensiveData.ClinkerOutsourcing_CoalConsumption;     //外购熟料综合煤耗
            m_ComparableData.CoalLowCalorificValue = myComprehensiveData.CoalLowCalorificValue;                    //煤粉低位发热量
            m_ComparableData.CoalWaterContent = myComprehensiveData.CoalWaterContent;                              //煤粉水分
            m_ComparableData.ElectricityToCoalFactor = myComprehensiveData.ElectricityToCoalFactor;                //用电折合用煤系数
            m_ComparableData.StandardCalorificValue = myComprehensiveData.StandardCalorificValue;                  //标准煤发热量
            LoadData(myProcessDataTable, m_ComparableData, myKeyColumn, myValueColumn);
        }
        public void LoadComparableData(DataTable myProcessDataTable, Parameters_ComparableData myComparableData, string myKeyColumn, string myValueColumn)
        {
            LoadData(myProcessDataTable, myComparableData, myKeyColumn, myValueColumn);
        }
        private void LoadData(DataTable myProcessDataTable, Parameters_ComparableData myComparableData, string myKeyColumn, string myValueColumn)
        {
            SetClinkerProperties(myComparableData);
            SetCementProperties(myComparableData);
            SetCoalProperties(myComparableData);
            SetRecuperationProperties(myComparableData);
            SetCommonParameters(myComparableData);

            Dictionary<string, decimal> m_ProcessData = ParametersAndProperties.GetProcessData(myProcessDataTable, myKeyColumn, myValueColumn);
            ParametersAndProperties.SetClinkerProcessPowerProperties(m_ProcessData);
            ParametersAndProperties.SetClinkerProcessCoalProperties(m_ProcessData);
            ParametersAndProperties.SetCementProcessPowerProperties(m_ProcessData);
            ParametersAndProperties.SetCementProcessCoalProperties(m_ProcessData);
            ParametersAndProperties.SetMainMaterialsProperties(m_ProcessData);
        }
        public void ClearPropertiesList()
        {
            ParametersAndProperties.ClearPropertiesList();
        }
        /// <summary>
        /// 设置熟料属性
        /// </summary>
        private void SetClinkerProperties(Parameters_ComparableData myComparableData)
        {
            ParametersAndProperties.ClinkerProperties.Altitude = myComparableData.Clinker_ActualAltitude;
            ParametersAndProperties.ClinkerProperties.AtmosphericPressure = myComparableData.Clinker_ActualAtmosphericPressure;
            ParametersAndProperties.ClinkerProperties.ClinkerOutsourcing_PowerConsumption = myComparableData.ClinkerOutsourcing_PowerConsumption;
            ParametersAndProperties.ClinkerProperties.ClinkerOutsourcing_CoalConsumption = myComparableData.ClinkerOutsourcing_CoalConsumption;
            ParametersAndProperties.ClinkerProperties.CompressiveStrength = myComparableData.ClinkerCompressiveStrength;
        }
        private void SetCementProperties(Parameters_ComparableData myComparableData)
        {
            ParametersAndProperties.CementProperties.Altitude = myComparableData.Cement_ActualAltitude;
            ParametersAndProperties.CementProperties.AtmosphericPressure = myComparableData.Cement_ActualAtmosphericPressure;
            ParametersAndProperties.CementProperties.CompressiveStrength = myComparableData.CementCompressiveStrength;
        }
        private void SetCoalProperties(Parameters_ComparableData myComparableData)
        {
            ParametersAndProperties.CoalProperties.CoalLowCalorificValue = myComparableData.CoalLowCalorificValue;
            ParametersAndProperties.CoalProperties.CoalWaterContent = myComparableData.CoalWaterContent;
        }
        private void SetRecuperationProperties(Parameters_ComparableData myComparableData)
        {
            ParametersAndProperties.RecuperationProperties.ExportHeat = myComparableData.RecuperationExportHeat;
            ParametersAndProperties.RecuperationProperties.ImportHeat = myComparableData.RecuperationImportHeat;
            ParametersAndProperties.RecuperationProperties.LossHeat = myComparableData.RecuperationLossHeat;
        }
        private void SetCommonParameters(Parameters_ComparableData myComparableData)
        {
            ParametersAndProperties.CommonParameters.Altitude = myComparableData.CorrectedAltitude;
            ParametersAndProperties.CommonParameters.AtmosphericPressure = myComparableData.StandardAtmosphericPressure;
            ParametersAndProperties.CommonParameters.Cement_CompressiveStrength = myComparableData.Cement_CorrectedCompressiveStrength;
            ParametersAndProperties.CommonParameters.Clinker_CompressiveStrength = myComparableData.Clinker_CorrectedCompressiveStrength;
            ParametersAndProperties.CommonParameters.ElectricityToCoalFactor = myComparableData.ElectricityToCoalFactor;
            ParametersAndProperties.CommonParameters.StandardCalorificValue = myComparableData.StandardCalorificValue;
        }
        #region  只获得值方式
        //////////////////////////////////////////////只获得值方式/////////////////////////////////////
        /// <summary>
        /// //////////////////////////////////
        /// </summary>
        /// <returns></returns>
        public decimal GetClinkerPowerConsumption()
        {
            return EnergyConsumption.GetClinkerPowerConsumption(ParametersAndProperties.ClinkerProperties, ParametersAndProperties.GetClinkerProcessPowerProperties()).CaculateValue;
        }
        public decimal GetClinkerCoalConsumption()
        {
            return EnergyConsumption.GetClinkerCoalConsumption(ParametersAndProperties.ClinkerProperties, ParametersAndProperties.CoalProperties, ParametersAndProperties.GetClinkerProcessCoalProperties(), ParametersAndProperties.CommonParameters).CaculateValue;
        }
        public decimal GetClinkerEnergyConsumption(decimal myClinkerPowerConsumption, decimal myClinkerCoalConsumption)
        {

            return EnergyConsumption.GetClinkerEnergyConsumption(myClinkerPowerConsumption, myClinkerCoalConsumption, ParametersAndProperties.CommonParameters).CaculateValue;
        }
        public decimal GetCementPowerConsumption(decimal myClinkerPowerConsumption)
        {
            return EnergyConsumption.GetCementPowerConsumption(ParametersAndProperties.CementProperties, ParametersAndProperties.GetCementProcessPowerProperties(), myClinkerPowerConsumption).CaculateValue;
        }
        public decimal GetCementCoalConsumption(decimal myClinkerCoalConsumption)
        {
            return EnergyConsumption.GetCementCoalConsumption(ParametersAndProperties.CementProperties, ParametersAndProperties.CoalProperties, ParametersAndProperties.GetCementProcessCoalProperties(), ParametersAndProperties.CommonParameters, myClinkerCoalConsumption).CaculateValue;
        }
        public decimal GetCementEnergyConsumption(decimal myCementPowerConsumption, decimal myCementCoalConsumption)
        {
            return EnergyConsumption.GetCementEnergyConsumption(myCementPowerConsumption, myCementCoalConsumption, ParametersAndProperties.CommonParameters).CaculateValue;
        }
        public decimal GetClinkerPowerConsumptionComparable()
        {
            return EnergyConsumption.GetClinkerPowerConsumptionComparable(ParametersAndProperties.ClinkerProperties, ParametersAndProperties.GetClinkerProcessPowerProperties(), ParametersAndProperties.CommonParameters).CaculateValue;
        }
        public decimal GetClinkerCoalConsumptionComparable()
        {
            return EnergyConsumption.GetClinkerCoalConsumptionComparable(ParametersAndProperties.ClinkerProperties, ParametersAndProperties.CoalProperties, ParametersAndProperties.GetClinkerProcessCoalProperties(), ParametersAndProperties.CommonParameters, ParametersAndProperties.CogenerationProperties, ParametersAndProperties.RecuperationProperties).CaculateValue;
        }
        public decimal GetClinkerEnergyConsumptionComparable(decimal myClinkerPowerConsumption, decimal myClinkerCoalConsumption)
        {
            return EnergyConsumption.GetClinkerEnergyConsumptionComparable(myClinkerPowerConsumption, myClinkerCoalConsumption, ParametersAndProperties.CommonParameters).CaculateValue;
        }
        public decimal GetCementPowerConsumptionComparable(decimal myClinkerPowerConsumption)
        {
            return EnergyConsumption.GetCementPowerConsumptionComparable(ParametersAndProperties.CementProperties, ParametersAndProperties.GetCementProcessPowerProperties(), ParametersAndProperties.CommonParameters, myClinkerPowerConsumption).CaculateValue;
        }
        public decimal GetCementCoalConsumptionComparable(decimal myCementCoalConsumption)
        {
            return EnergyConsumption.GetCementCoalConsumptionComparable(ParametersAndProperties.CementProperties, ParametersAndProperties.CoalProperties, ParametersAndProperties.GetCementProcessCoalProperties(), myCementCoalConsumption, ParametersAndProperties.CommonParameters).CaculateValue;
        }
        public decimal GetCementEnergyConsumptionComparable(decimal myCementPowerConsumptionComparable, decimal myCementCoalConsumptionComparable)
        {
            return EnergyConsumption.GetCementEnergyConsumptionComparable(myCementPowerConsumptionComparable, myCementCoalConsumptionComparable, ParametersAndProperties.CommonParameters).CaculateValue;
        }
        public decimal GetCementCompressiveStrength(DataTable myCementCompressiveStrength, string myCompressiveStrengthColumn, string myCementOutputColumn, decimal myDefaultValue)
        {
            return ParametersAndProperties.GetWeightedAverageValue(myCementCompressiveStrength, myCompressiveStrengthColumn, myCementOutputColumn, myDefaultValue);
        }
        public decimal GetWeightedAverageValue(DataTable myValueTable, string myTargetValueColumn, string myWeightedValueColumn, decimal myDefaultValue)
        {
            return ParametersAndProperties.GetWeightedAverageValue(myValueTable, myTargetValueColumn, myWeightedValueColumn, myDefaultValue);
        }
        public decimal GetWeightedAverageValue(DataRow[] myValueRows, string myTargetValueColumn, string myWeightedValueColumn, decimal myDefaultValue)
        {
            return ParametersAndProperties.GetWeightedAverageValue(myValueRows, myTargetValueColumn, myWeightedValueColumn, myDefaultValue);
        }
        #endregion

        #region  带公式方式
        public Model_CaculateValue GetClinkerPowerConsumptionWithFormula()
        {
            return EnergyConsumption.GetClinkerPowerConsumption(ParametersAndProperties.ClinkerProperties, ParametersAndProperties.GetClinkerProcessPowerProperties());
        }
        public Model_CaculateValue GetClinkerCoalConsumptionWithFormula()
        {
            return EnergyConsumption.GetClinkerCoalConsumption(ParametersAndProperties.ClinkerProperties, ParametersAndProperties.CoalProperties, ParametersAndProperties.GetClinkerProcessCoalProperties(), ParametersAndProperties.CommonParameters);
        }
        public Model_CaculateValue GetClinkerEnergyConsumptionWithFormula(decimal myClinkerPowerConsumption, decimal myClinkerCoalConsumption)
        {
            return EnergyConsumption.GetClinkerEnergyConsumption(myClinkerPowerConsumption, myClinkerCoalConsumption, ParametersAndProperties.CommonParameters);
        }
        public Model_CaculateValue GetCementPowerConsumptionWithFormula(decimal myClinkerPowerConsumption)
        {
            return EnergyConsumption.GetCementPowerConsumption(ParametersAndProperties.CementProperties, ParametersAndProperties.GetCementProcessPowerProperties(), myClinkerPowerConsumption);
        }
        public Model_CaculateValue GetCementCoalConsumptionWithFormula(decimal myClinkerCoalConsumption)
        {
            return EnergyConsumption.GetCementCoalConsumption(ParametersAndProperties.CementProperties, ParametersAndProperties.CoalProperties, ParametersAndProperties.GetCementProcessCoalProperties(), ParametersAndProperties.CommonParameters, myClinkerCoalConsumption);
        }
        public Model_CaculateValue GetCementEnergyConsumptionWithFormula(decimal myCementPowerConsumption, decimal myCementCoalConsumption)
        {
            return EnergyConsumption.GetCementEnergyConsumption(myCementPowerConsumption, myCementCoalConsumption, ParametersAndProperties.CommonParameters);
        }
        public Model_CaculateValue GetClinkerPowerConsumptionComparableWithFormula()
        {
            return EnergyConsumption.GetClinkerPowerConsumptionComparable(ParametersAndProperties.ClinkerProperties, ParametersAndProperties.GetClinkerProcessPowerProperties(), ParametersAndProperties.CommonParameters);
        }
        public Model_CaculateValue GetClinkerCoalConsumptionComparableWithFormula()
        {
            return EnergyConsumption.GetClinkerCoalConsumptionComparable(ParametersAndProperties.ClinkerProperties, ParametersAndProperties.CoalProperties, ParametersAndProperties.GetClinkerProcessCoalProperties(), ParametersAndProperties.CommonParameters, ParametersAndProperties.CogenerationProperties, ParametersAndProperties.RecuperationProperties);
        }
        public Model_CaculateValue GetClinkerEnergyConsumptionComparableWithFormula(decimal myClinkerPowerConsumptionComparable, decimal myClinkerCoalConsumptionComparable)
        {
            return EnergyConsumption.GetClinkerEnergyConsumptionComparable(myClinkerPowerConsumptionComparable, myClinkerCoalConsumptionComparable, ParametersAndProperties.CommonParameters);
        }
        public Model_CaculateValue GetCementPowerConsumptionComparableWithFormula(decimal myClinkerPowerConsumption)
        {
            return EnergyConsumption.GetCementPowerConsumptionComparable(ParametersAndProperties.CementProperties, ParametersAndProperties.GetCementProcessPowerProperties(), ParametersAndProperties.CommonParameters, myClinkerPowerConsumption);
        }
        public Model_CaculateValue GetCementCoalConsumptionComparableWithFormula(decimal myCementCoalConsumption)
        {
            return EnergyConsumption.GetCementCoalConsumptionComparable(ParametersAndProperties.CementProperties, ParametersAndProperties.CoalProperties, ParametersAndProperties.GetCementProcessCoalProperties(), myCementCoalConsumption, ParametersAndProperties.CommonParameters);
        }
        public Model_CaculateValue GetCementEnergyConsumptionComparableWithFormula(decimal myCementPowerConsumptionComparable, decimal myCementCoalConsumptionComparable)
        {
            return EnergyConsumption.GetCementEnergyConsumptionComparable(myCementPowerConsumptionComparable, myCementCoalConsumptionComparable, ParametersAndProperties.CommonParameters);
        }
        public Model_CaculateValue GetCogenerationCoalConsumption()
        {
            return EnergyConsumption.GetCogenerationCoalConsumption(ParametersAndProperties.CogenerationProperties.GrossGeneration, ParametersAndProperties.CogenerationProperties.OwnDemand, ParametersAndProperties.ClinkerProperties.MarterialsOutput, ParametersAndProperties.CommonParameters);
        }
        public Model_CaculateValue GetRecuperationCoalConsumption()
        {
            return EnergyConsumption.GetRecuperationCoalConsumption(ParametersAndProperties.RecuperationProperties.ImportHeat, ParametersAndProperties.RecuperationProperties.ExportHeat, ParametersAndProperties.RecuperationProperties.LossHeat, ParametersAndProperties.ClinkerProperties.MarterialsOutput, ParametersAndProperties.CommonParameters);
        }
        #endregion
    }
}
