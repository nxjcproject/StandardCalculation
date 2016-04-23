using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using SqlServerDataAdapter;

namespace CalculationTestGB
{
    public partial class StandardTest : Form
    {
        private readonly static Standard_GB16780_2012.Function_EnergyConsumption_V1 EnergyConsumption_V1 = new Standard_GB16780_2012.Function_EnergyConsumption_V1();
        private SqlServerDataFactory _dataFactory;
        private AutoSetParameters.AutoGetEnergyConsumptionRuntime_V1 AutoGetEnergyConsumption_V1;
        public StandardTest()
        {
            InitializeComponent();
            string m_DBConnectionString = ConfigurationManager.ConnectionStrings["ConnNXJC"].ToString();
            _dataFactory = new SqlServerDataFactory(m_DBConnectionString);
            AutoGetEnergyConsumption_V1 = new AutoSetParameters.AutoGetEnergyConsumptionRuntime_V1(_dataFactory);
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            decimal ClinkerPowerConsumption = EnergyConsumption_V1.GetClinkerPowerConsumption();
            decimal ClinkerCoalConsumption = EnergyConsumption_V1.GetClinkerCoalConsumption();
            decimal ClinkerEnergyConsumption = EnergyConsumption_V1.GetClinkerEnergyConsumption(ClinkerPowerConsumption, ClinkerCoalConsumption);
            decimal CementPowerConsumption = EnergyConsumption_V1.GetCementPowerConsumption(ClinkerPowerConsumption);
            decimal CementCoalConsumption = EnergyConsumption_V1.GetCementCoalConsumption(ClinkerCoalConsumption);
            decimal CementEnergyConsumption = EnergyConsumption_V1.GetCementEnergyConsumption(CementPowerConsumption, CementCoalConsumption);
            decimal ClinkerPowerConsumptionComparable = EnergyConsumption_V1.GetClinkerPowerConsumptionComparable();
            decimal ClinkerCoalConsumptionComparable = EnergyConsumption_V1.GetClinkerCoalConsumptionComparable();
            decimal ClinkerEnergyConsumptionComparable = EnergyConsumption_V1.GetClinkerEnergyConsumptionComparable(ClinkerPowerConsumptionComparable, ClinkerCoalConsumptionComparable);
            decimal CementPowerConsumptionComparable = EnergyConsumption_V1.GetCementPowerConsumptionComparable(ClinkerPowerConsumption);
            decimal CementCoalConsumptionComparable = EnergyConsumption_V1.GetCementCoalConsumptionComparable(CementCoalConsumption);
            decimal CementEnergyConsumptionComparable = EnergyConsumption_V1.GetCementEnergyConsumptionComparable(CementPowerConsumptionComparable, CementCoalConsumptionComparable);
        }

        private void button_LoadData_Click(object sender, EventArgs e)
        {
            DataTable m_ProcessDataTable = LoadDataTable();
            Standard_GB16780_2012.Parameters_ComparableData m_ComparableData = new Standard_GB16780_2012.Parameters_ComparableData();
            m_ComparableData.Clinker_ActualAltitude = 2000;                         //实际海拔高度
            m_ComparableData.Clinker_ActualAtmosphericPressure = 101200;              //实际大气压强
            m_ComparableData.Cement_ActualAltitude = 2000;                         //实际海拔高度
            m_ComparableData.Cement_ActualAtmosphericPressure = 101200;              //实际大气压强
            m_ComparableData.ClinkerOutsourcing_PowerConsumption = 65;    //外购熟料综合电耗
            m_ComparableData.ClinkerOutsourcing_CoalConsumption = 100;     //外购熟料综合煤耗
            m_ComparableData.ClinkerCompressiveStrength = 40;             //熟料28d抗压强度

            m_ComparableData.CementCompressiveStrength = 32.5m;              //水泥强度

            m_ComparableData.CoalLowCalorificValue = 29307m;                  //煤粉低位发热量
            m_ComparableData.CoalWaterContent = 0m;                       //煤粉水分

            m_ComparableData.RecuperationExportHeat = 0;                 //余热利用出口热量
            m_ComparableData.RecuperationImportHeat = 0;                 //余热利用进口热量
            m_ComparableData.RecuperationLossHeat = 0;                   //余热利用损失热量

            m_ComparableData.CorrectedAltitude = 1000;                      //修正海拔高度
            m_ComparableData.StandardAtmosphericPressure = 101325m;            //标准大气压强
            m_ComparableData.Cement_CorrectedCompressiveStrength = 42.5m;    //水泥修正强度
            m_ComparableData.Clinker_CorrectedCompressiveStrength = 52.5m;   //熟料修正强度
            m_ComparableData.ElectricityToCoalFactor = 0.1229m;                //用电折合用煤系数
            m_ComparableData.StandardCalorificValue = 29307m;                 //标准煤发热量

            EnergyConsumption_V1.LoadComparableData(m_ProcessDataTable, m_ComparableData, "VarialbeId", "Value");

        }
        private DataTable LoadDataTable()
        {
//            cement_CementOutput	27608.6466
//cementGrind_ElectricityQuantity	794879.7
//cementPacking_ElectricityQuantity	33631.1879
//clinker_ClinkerInput	55417.6764
//clinker_ClinkerOutput	22364.9463
//clinker_ClinkerOutsourcingInput	1121.6956
//clinker_LimestoneInput	34760.25
//clinker_MixtureMaterialsOutput	39538.0625
//clinker_PulverizedCoalInput	3630.6195
//clinker_PulverizedCoalOutput	2728.9594
//clinkerBurning_ElectricityQuantity	717128.8
//clinkerElectricityGeneration_ElectricityQuantity	1348800
//clinkerTransport_ElectricityQuantity	11482.8279
//coalPreparation_ElectricityQuantity	109914.8
//electricityOwnDemand_ElectricityQuantity	75581.4
//hybridMaterialsPreparation_ElectricityQuantity	4280.991
//kilnSystem_ElectricityQuantity	113744.4
//rawMaterialsPreparation_ElectricityQuantity	583597.6
//rawMealHomogenization_ElectricityQuantity	10353.6


            DataTable m_ProcessDataTable = new DataTable();
            m_ProcessDataTable.Columns.Add("VarialbeId", typeof(string));
            m_ProcessDataTable.Columns.Add("Value", typeof(decimal));
            m_ProcessDataTable.Rows.Add("rawMaterialsPreparation_ElectricityQuantity", 583597.6m);         //生料制备电量
            m_ProcessDataTable.Rows.Add("clinker_MixtureMaterialsOutput", 39538.0625m);    //生料产量
            m_ProcessDataTable.Rows.Add("clinker_LimestoneInput", 34760.25m);              //石灰石消耗量

            m_ProcessDataTable.Rows.Add("coalPreparation_ElectricityQuantity", 109914.8m);                  //煤粉制备电量
            m_ProcessDataTable.Rows.Add("clinker_PulverizedCoalOutput", 2728.9594m);       //煤粉产量
            m_ProcessDataTable.Rows.Add("clinker_PulverizedCoalInput", 3630.6195m);        //煤粉消耗量

            m_ProcessDataTable.Rows.Add("clinkerBurning_ElectricityQuantity", 717128.8m);                   //熟料烧成电量
            m_ProcessDataTable.Rows.Add("clinker_ClinkerOutput", 22364.9463m);             //熟料产量
            m_ProcessDataTable.Rows.Add("clinker_ClinkerInput", 18472.55m);              //熟料消耗量
            m_ProcessDataTable.Rows.Add("clinker_ClinkerOutsourcingInput", 1121.6956m);              //熟料消耗量（外购）
            m_ProcessDataTable.Rows.Add("clinker_ClinkerFactoryTransportInput", 0m);              //熟料消耗量（厂间倒运）
            m_ProcessDataTable.Rows.Add("clinker_ClinkerCompanyTransportInput", 0m);              //熟料消耗量（公司间倒运）

            m_ProcessDataTable.Rows.Add("kilnSystem_ElectricityQuantity", 113744.4m);                      //废气处理电量
            m_ProcessDataTable.Rows.Add("rawMealHomogenization_ElectricityQuantity", 10353.6m);                      //生料均化

            m_ProcessDataTable.Rows.Add("cementGrind_ElectricityQuantity", 794879.7m);                       //水泥粉磨电量
            m_ProcessDataTable.Rows.Add("cement_CementOutput", 27608.6466m);                 //水泥产量

            m_ProcessDataTable.Rows.Add("hybridMaterialsPreparation_ElectricityQuantity", 4280.991m);          //混合材制备电量
            m_ProcessDataTable.Rows.Add("clinkerTransport_ElectricityQuantity", 11482.8279m);                    //水泥输送电量
            m_ProcessDataTable.Rows.Add("cementPacking_ElectricityQuantity", 33631.1879m);                      //水泥包装电量

            m_ProcessDataTable.Rows.Add("clinkerElectricityGeneration_ElectricityQuantity", 1348800m);                       //余热发电发电电量
            m_ProcessDataTable.Rows.Add("electricityOwnDemand_ElectricityQuantity", 86059.2m);                       //余热发电自用电量

            return m_ProcessDataTable;
        }

        private void button_Comprehensive_Click(object sender, EventArgs e)
        {
            decimal ClinkerPowerConsumption = EnergyConsumption_V1.GetClinkerPowerConsumption();
            decimal ClinkerCoalConsumption = EnergyConsumption_V1.GetClinkerCoalConsumption();
            decimal ClinkerEnergyConsumption = EnergyConsumption_V1.GetClinkerEnergyConsumption(ClinkerPowerConsumption, ClinkerCoalConsumption);
            decimal CementPowerConsumption = EnergyConsumption_V1.GetCementPowerConsumption(ClinkerPowerConsumption);
            decimal CementCoalConsumption = EnergyConsumption_V1.GetCementCoalConsumption(ClinkerCoalConsumption);
            decimal CementEnergyConsumption = EnergyConsumption_V1.GetCementEnergyConsumption(CementPowerConsumption, CementCoalConsumption);
        }

        private void button_LoadDataComprehensive_Click(object sender, EventArgs e)
        {
            DataTable m_ProcessDataTable = LoadDataTable();
            Standard_GB16780_2012.Parameters_ComprehensiveData m_ComprehensiveData = new Standard_GB16780_2012.Parameters_ComprehensiveData();
            m_ComprehensiveData.ClinkerOutsourcing_PowerConsumption = 65;        //外购熟料综合电耗
            m_ComprehensiveData.ClinkerOutsourcing_CoalConsumption = 100;        //外购熟料综合煤耗

            m_ComprehensiveData.CoalLowCalorificValue = 29307m;                  //煤粉低位发热量
            m_ComprehensiveData.CoalWaterContent = 0m;                           //煤粉水分

            m_ComprehensiveData.ElectricityToCoalFactor = 0.1229m;               //用电折合用煤系数
            m_ComprehensiveData.StandardCalorificValue = 29307m;                 //标准煤发热量

            EnergyConsumption_V1.LoadComprehensiveData(m_ProcessDataTable, m_ComprehensiveData, "VarialbeId", "Value");
        }

        private void button_EnergyComsumptionWithFormula_Click(object sender, EventArgs e)
        {
            Standard_GB16780_2012.Model_CaculateValue ClinkerPowerConsumption = EnergyConsumption_V1.GetClinkerPowerConsumptionWithFormula();
            Standard_GB16780_2012.Model_CaculateValue ClinkerCoalConsumption = EnergyConsumption_V1.GetClinkerCoalConsumptionWithFormula();
            Standard_GB16780_2012.Model_CaculateValue ClinkerEnergyConsumption = EnergyConsumption_V1.GetClinkerEnergyConsumptionWithFormula(ClinkerPowerConsumption.CaculateValue, ClinkerCoalConsumption.CaculateValue);
            Standard_GB16780_2012.Model_CaculateValue CementPowerConsumption = EnergyConsumption_V1.GetCementPowerConsumptionWithFormula(ClinkerPowerConsumption.CaculateValue);
            Standard_GB16780_2012.Model_CaculateValue CementCoalConsumption = EnergyConsumption_V1.GetCementCoalConsumptionWithFormula(ClinkerCoalConsumption.CaculateValue);
            Standard_GB16780_2012.Model_CaculateValue CementEnergyConsumption = EnergyConsumption_V1.GetCementEnergyConsumptionWithFormula(CementPowerConsumption.CaculateValue, CementCoalConsumption.CaculateValue);
            Standard_GB16780_2012.Model_CaculateValue ClinkerPowerConsumptionComparable = EnergyConsumption_V1.GetClinkerPowerConsumptionComparableWithFormula();
            Standard_GB16780_2012.Model_CaculateValue ClinkerCoalConsumptionComparable = EnergyConsumption_V1.GetClinkerCoalConsumptionComparableWithFormula();
            Standard_GB16780_2012.Model_CaculateValue ClinkerEnergyConsumptionComparable = EnergyConsumption_V1.GetClinkerEnergyConsumptionComparableWithFormula(ClinkerPowerConsumptionComparable.CaculateValue, ClinkerCoalConsumptionComparable.CaculateValue);
            Standard_GB16780_2012.Model_CaculateValue CementPowerConsumptionComparable = EnergyConsumption_V1.GetCementPowerConsumptionComparableWithFormula(ClinkerPowerConsumption.CaculateValue);
            Standard_GB16780_2012.Model_CaculateValue CementCoalConsumptionComparable = EnergyConsumption_V1.GetCementCoalConsumptionComparableWithFormula(CementCoalConsumption.CaculateValue);
            Standard_GB16780_2012.Model_CaculateValue CementEnergyConsumptionComparable = EnergyConsumption_V1.GetCementEnergyConsumptionComparableWithFormula(CementPowerConsumptionComparable.CaculateValue, CementCoalConsumptionComparable.CaculateValue);
            Standard_GB16780_2012.Model_CaculateValue CogenerationCoalConsumption = EnergyConsumption_V1.GetCogenerationCoalConsumption();
            Standard_GB16780_2012.Model_CaculateValue RecuperationCoalConsumption = EnergyConsumption_V1.GetRecuperationCoalConsumption();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Standard_GB16780_2012.Model_CaculateValue m_Value = AutoGetEnergyConsumption_V1.GetCementPowerConsumptionComparableWithFormula("day", "2016-04-01", "2016-04-15", "O0501");
        }
    }
}
