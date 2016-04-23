using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Standard_GB16780_2012;
namespace AutoSetParameters
{
    public class AutoGetEnergyConsumption_V1
    {
        private const string Clinker = "熟料";
        private const string CementMill = "水泥磨";
        private const string Factory = "分厂";
        private const string Company = "分公司";
        private SqlServerDataAdapter.ISqlServerDataFactory SqlServerDataFactory;
        public AutoGetEnergyConsumption_V1(SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            SqlServerDataFactory = mySqlServerDataFactory;
        }
        #region  带公式全自动方式
        public Model_CaculateValue GetClinkerPowerConsumptionWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            //计算数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, Clinker, myStaticsCycle);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            return m_EnergyConsumption_V1.GetClinkerPowerConsumptionWithFormula();
        }
        public Model_CaculateValue GetClinkerCoalConsumptionWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            //计算数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, Clinker, myStaticsCycle);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            return m_EnergyConsumption_V1.GetClinkerCoalConsumptionWithFormula();
        }
        public Model_CaculateValue GetClinkerEnergyConsumptionWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            //计算数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, Clinker, myStaticsCycle);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            decimal m_ClinkerPowConsumption = m_EnergyConsumption_V1.GetClinkerPowerConsumption();
            decimal m_ClinkerCoalConsumption = m_EnergyConsumption_V1.GetClinkerCoalConsumption();
            return m_EnergyConsumption_V1.GetClinkerEnergyConsumptionWithFormula(m_ClinkerPowConsumption, m_ClinkerCoalConsumption);
        }
        public Model_CaculateValue GetCementPowerConsumptionWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            //计算熟料数据
            DataTable m_ValueTableClinker = GetBenchmarkingDataValue(myStartTime, myEndTime, m_ClinkerLevelCode, Clinker, myStaticsCycle);
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTableClinker, m_Parameters_ComprehensiveData, "VariableId", "Value");
            decimal m_ClinkerPowConsumption = m_EnergyConsumption_V1.GetClinkerPowerConsumption();
            //计算水泥数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, CementMill, myStaticsCycle);
            //增加包装电耗
            GetCementPackingDataValue(myStartTime, myEndTime, ref m_ValueTable, m_FactoryOrganizationId, myStaticsCycle);

            m_EnergyConsumption_V1.ClearPropertiesList();
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            return m_EnergyConsumption_V1.GetCementPowerConsumptionWithFormula(m_ClinkerPowConsumption);
        }
        public Model_CaculateValue GetCementCoalConsumptionWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表

            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            //计算熟料数据
            DataTable m_ValueTableClinker = GetBenchmarkingDataValue(myStartTime, myEndTime, m_ClinkerLevelCode, Clinker, myStaticsCycle);
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTableClinker, m_Parameters_ComprehensiveData, "VariableId", "Value");
            decimal m_ClinkerCoalConsumption = m_EnergyConsumption_V1.GetClinkerCoalConsumption();
            //计算水泥数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, CementMill, myStaticsCycle);

            m_EnergyConsumption_V1.ClearPropertiesList();
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            return m_EnergyConsumption_V1.GetCementCoalConsumptionWithFormula(m_ClinkerCoalConsumption);
        }
        public Model_CaculateValue GetCementEnergyConsumptionWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表

            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            //计算熟料数据
            DataTable m_ValueTableClinker = GetBenchmarkingDataValue(myStartTime, myEndTime, m_ClinkerLevelCode, Clinker, myStaticsCycle);
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTableClinker, m_Parameters_ComprehensiveData, "VariableId", "Value");
            decimal m_ClinkerPowConsumption = m_EnergyConsumption_V1.GetClinkerPowerConsumption();
            decimal m_ClinkerCoalConsumption = m_EnergyConsumption_V1.GetClinkerCoalConsumption();
            //计算水泥数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, CementMill, myStaticsCycle);
            //增加包装电耗
            GetCementPackingDataValue(myStartTime, myEndTime, ref m_ValueTable, m_FactoryOrganizationId, myStaticsCycle);

            m_EnergyConsumption_V1.ClearPropertiesList();
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            decimal m_CementPowConsumption = m_EnergyConsumption_V1.GetCementPowerConsumption(m_ClinkerPowConsumption);
            decimal m_CementCoalConsumption = m_EnergyConsumption_V1.GetCementCoalConsumption(m_ClinkerCoalConsumption);
            return m_EnergyConsumption_V1.GetCementEnergyConsumptionWithFormula(m_CementPowConsumption, m_CementCoalConsumption);
        }
        public Model_CaculateValue GetClinkerPowerConsumptionComparableWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComparableData m_Parameters_ComparableData = AutoSetParameters.AutoSetParameters_V1.SetComparableParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            //计算数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, Clinker, myStaticsCycle);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            m_EnergyConsumption_V1.LoadComparableData(m_ValueTable, m_Parameters_ComparableData, "VariableId", "Value");

            return m_EnergyConsumption_V1.GetClinkerPowerConsumptionComparableWithFormula();
        }
        public Model_CaculateValue GetClinkerCoalConsumptionComparableWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComparableData m_Parameters_ComparableData = AutoSetParameters.AutoSetParameters_V1.SetComparableParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            //计算数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, Clinker, myStaticsCycle);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            m_EnergyConsumption_V1.LoadComparableData(m_ValueTable, m_Parameters_ComparableData, "VariableId", "Value");
            return m_EnergyConsumption_V1.GetClinkerCoalConsumptionComparableWithFormula();
        }
        public Model_CaculateValue GetClinkerEnergyConsumptionComparableWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComparableData m_Parameters_ComparableData = AutoSetParameters.AutoSetParameters_V1.SetComparableParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            //计算数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, Clinker, myStaticsCycle);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            m_EnergyConsumption_V1.LoadComparableData(m_ValueTable, m_Parameters_ComparableData, "VariableId", "Value");
            decimal m_ClinkerPowerConsumptionComparable = m_EnergyConsumption_V1.GetClinkerPowerConsumptionComparable();
            decimal m_ClinkerCoalConsumptionComparable = m_EnergyConsumption_V1.GetClinkerCoalConsumptionComparable();
            return m_EnergyConsumption_V1.GetClinkerEnergyConsumptionComparableWithFormula(m_ClinkerPowerConsumptionComparable, m_ClinkerCoalConsumptionComparable);
        }
        public Model_CaculateValue GetCementPowerConsumptionComparableWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Parameters_ComparableData m_Parameters_ComparableData = AutoSetParameters.AutoSetParameters_V1.SetComparableParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            //计算熟料综合数据
            DataTable m_ClinkerValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, m_ClinkerLevelCode, Clinker, myStaticsCycle);
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ClinkerValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            decimal m_ClinkerPowerConsumption = m_EnergyConsumption_V1.GetClinkerPowerConsumption();
            //计算水泥磨可比数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, CementMill, myStaticsCycle);
            m_EnergyConsumption_V1.ClearPropertiesList();
            m_EnergyConsumption_V1.LoadComparableData(m_ValueTable, m_Parameters_ComparableData, "VariableId", "Value");
            return m_EnergyConsumption_V1.GetCementPowerConsumptionComparableWithFormula(m_ClinkerPowerConsumption);
        }
        public Model_CaculateValue GetCementCoalConsumptionComparableWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Parameters_ComparableData m_Parameters_ComparableData = AutoSetParameters.AutoSetParameters_V1.SetComparableParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            //计算熟料综合数据
            DataTable m_ClinkerValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, m_ClinkerLevelCode, Clinker, myStaticsCycle);
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ClinkerValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            decimal m_ClinkerCoalConsumption = m_EnergyConsumption_V1.GetClinkerCoalConsumption();
            //计算水泥磨可比数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, CementMill, myStaticsCycle);
            m_EnergyConsumption_V1.ClearPropertiesList();
            m_EnergyConsumption_V1.LoadComparableData(m_ValueTable, m_Parameters_ComparableData, "VariableId", "Value");
            return m_EnergyConsumption_V1.GetCementCoalConsumptionComparableWithFormula(m_ClinkerCoalConsumption);
        }
        public Model_CaculateValue GetCementEnergyConsumptionComparableWithFormula(string myStaticsCycle, string myStartTime, string myEndTime, string myLevelCode)
        {
            string m_ClinkerLevelCode = "";
            string m_FactoryOrganizationId = "";
            DataTable m_OrganizationContrastTable = GetOrganizationContrast(myLevelCode);
            if (m_OrganizationContrastTable != null && m_OrganizationContrastTable.Rows.Count > 0)
            {
                m_ClinkerLevelCode = m_OrganizationContrastTable.Rows[0]["LevelCode"].ToString();
                m_FactoryOrganizationId = m_OrganizationContrastTable.Rows[0]["FactoryOrganizationId"].ToString();
            }
            List<string> m_FactoryOrganizationIds = m_FactoryOrganizationId.Split(',').ToList();   //获得分厂级组织机构ID列表
            Parameters_ComprehensiveData m_Parameters_ComprehensiveData = AutoSetParameters.AutoSetParameters_V1.SetComprehensiveParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Parameters_ComparableData m_Parameters_ComparableData = AutoSetParameters.AutoSetParameters_V1.SetComparableParametersFromSql(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationIds, SqlServerDataFactory);
            Standard_GB16780_2012.Function_EnergyConsumption_V1 m_EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
            //计算熟料综合数据
            DataTable m_ClinkerValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, m_ClinkerLevelCode, Clinker, myStaticsCycle);
            m_EnergyConsumption_V1.LoadComprehensiveData(m_ClinkerValueTable, m_Parameters_ComprehensiveData, "VariableId", "Value");
            decimal m_ClinkerPowerConsumption = m_EnergyConsumption_V1.GetClinkerPowerConsumption();
            decimal m_ClinkerCoalConsumption = m_EnergyConsumption_V1.GetClinkerCoalConsumption();
            //计算水泥磨可比数据
            DataTable m_ValueTable = GetBenchmarkingDataValue(myStartTime, myEndTime, myLevelCode, CementMill, myStaticsCycle);
            m_EnergyConsumption_V1.ClearPropertiesList();
            m_EnergyConsumption_V1.LoadComparableData(m_ValueTable, m_Parameters_ComparableData, "VariableId", "Value");
            decimal m_CementPowerConsumptionComparable = m_EnergyConsumption_V1.GetCementPowerConsumptionComparable(m_ClinkerPowerConsumption);
            decimal m_CementCoalConsumptionComparable = m_EnergyConsumption_V1.GetCementCoalConsumptionComparable(m_ClinkerCoalConsumption);
            return m_EnergyConsumption_V1.GetCementEnergyConsumptionComparableWithFormula(m_CementPowerConsumptionComparable, m_CementCoalConsumptionComparable);
        }
        #endregion

        public DataTable GetOrganizationContrast(string myLevelCode)
        {
            string m_Sql = @"select 
                                A.FactoryOrganizationID as FactoryOrganizationId, 
                                C.LevelCode as LevelCode 
                                from analyse_KPI_OrganizationContrast A, system_Organization B, system_Organization C
                                where A.OrganizationID = B.OrganizationID
                                and B.LevelCode = '{0}'
                                and A.ClinkerOrganizationID = C.OrganizationID";
            m_Sql = string.Format(m_Sql, myLevelCode);
            try
            {
                DataTable mDataTable_ClinkerLevelCode = SqlServerDataFactory.Query(m_Sql);
                return mDataTable_ClinkerLevelCode;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetBenchmarkingDataValue(string myStartTime, string myEndTime, string myLevelCode, string myOrganizationType, string myStaticsCycle)
        {
            string m_SqlStatisticalRange = @"select A.LevelType as LevelType from system_Organization A where A.LevelCode = '{0}'";
            m_SqlStatisticalRange = string.Format(m_SqlStatisticalRange, myLevelCode);
            try
            {
                DataTable mDataTable_StatisticalRange = SqlServerDataFactory.Query(m_SqlStatisticalRange);
                string m_StatisticalRange = mDataTable_StatisticalRange.Rows[0]["LevelType"].ToString();

                string m_Sql = @"select 
                                D.VariableId as VariableId,
                                sum(D.Value) as Value 
                                from (
                                select C.LevelCode as LevelCode,
                                {3} as VariableId, 
                                B.TotalPeakValleyFlatB as Value
                                from tz_Balance A, balance_energy B, system_Organization C
                                where A.StaticsCycle = '{5}'
                                and A.BalanceId = B.KeyId
                                and (B.ValueType = 'ElectricityQuantity' or B.ValueType = 'MaterialWeight')
                                and A.TimeStamp >= '{0}'
                                and A.TimeStamp <='{1}'
                                and B.OrganizationID = C.OrganizationID
                                and C.LevelCode like '{2}%'
                                and C.Type = '{4}') D
                                group by D.VariableId";
                //substring(D.LevelCode,1,3), 
                //
                string m_ClinkerInputStatics = "";    //当以集团角度统计,公司间、分厂间倒运视为内倒；当以分公司角度统计，公司间倒运视为外倒，分厂间为内倒
                if (m_StatisticalRange == "Group")    //集团
                {
                    m_ClinkerInputStatics = "(case when B.VariableId = 'clinker_ClinkerFactoryTransportInput' then 'clinker_ClinkerInput' when B.VariableId = 'clinker_ClinkerCompanyTransportInput' then 'clinker_ClinkerInput' else B.VariableId end) ";
                }
                else if (m_StatisticalRange == "Company")
                {
                    m_ClinkerInputStatics = "(case when B.VariableId = 'clinker_ClinkerFactoryTransportInput' then 'clinker_ClinkerInput' when B.VariableId = 'clinker_ClinkerCompanyTransportInput' then 'clinker_ClinkerOutsourcingInput' else B.VariableId end) ";
                }
                else
                {
                    m_ClinkerInputStatics = "(case when B.VariableId = 'clinker_ClinkerFactoryTransportInput' then 'clinker_ClinkerOutsourcingInput' when B.VariableId = 'clinker_ClinkerCompanyTransportInput' then 'clinker_ClinkerOutsourcingInput' else B.VariableId end) ";
                }
                m_Sql = string.Format(m_Sql, myStartTime, myEndTime, myLevelCode, m_ClinkerInputStatics, myOrganizationType, myStaticsCycle);

                DataTable mDataTable_BenchmarkingDataValue = SqlServerDataFactory.Query(m_Sql);
                return mDataTable_BenchmarkingDataValue;
            }
            catch
            {
                return null;
            }

        }
        private void GetCementPackingDataValue(string myStartTime, string myEndTime, ref DataTable myValueTable, string myFactoryOrganizationId, string myStaticsCycle)
        {
            string m_Sql = @"select 
                                D.VariableId + '_All' as VariableId,
                                sum(D.Value) as Value 
                                from (
                                select B.VariableId as VariableId, 
                                B.TotalPeakValleyFlatB as Value
                                from tz_Balance A, balance_energy B
                                where A.StaticsCycle = '{3}'
                                and A.BalanceId = B.KeyId
                                and B.ValueType = 'ElectricityQuantity'
                                and A.TimeStamp >= '{0}'
                                and A.TimeStamp <='{1}'
                                and B.OrganizationID in ({2})
                                and B.VariableId = 'cementPacking_ElectricityQuantity') D
                                group by D.VariableId
                             union
                             select 
                                D.VariableId + '_All' as VariableId,
                                sum(D.Value) as Value 
                                from (
                                select B.VariableId as VariableId, 
                                B.TotalPeakValleyFlatB as Value
                                from tz_Balance A, balance_energy B
                                where A.StaticsCycle = '{3}'
                                and A.BalanceId = B.KeyId
                                and B.ValueType = 'MaterialWeight'
                                and A.TimeStamp >= '{0}'
                                and A.TimeStamp <='{1}'
                                and A.OrganizationID in ({2})
                                and B.VariableId = 'cement_CementOutput') D
                                group by D.VariableId";
            //substring(D.LevelCode,1,3), 
            //
            string m_OrganizationIds = myFactoryOrganizationId.Replace(",", "','");
            m_OrganizationIds = "'" + m_OrganizationIds + "'";
            m_Sql = string.Format(m_Sql, myStartTime, myEndTime, m_OrganizationIds, myStaticsCycle);
            try
            {
                DataTable mDataTable_CementPackingDataValue = SqlServerDataFactory.Query(m_Sql);
                if (mDataTable_CementPackingDataValue != null)
                {
                    for (int i = 0; i < mDataTable_CementPackingDataValue.Rows.Count; i++)
                    {
                        myValueTable.Rows.Add(mDataTable_CementPackingDataValue.Rows[i]["VariableId"], mDataTable_CementPackingDataValue.Rows[i]["Value"]);
                    }
                }
            }
            catch
            {
            }
        }

    }
}
