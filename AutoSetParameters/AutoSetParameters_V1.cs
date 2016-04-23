using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AutoSetParameters
{
    public class AutoSetParameters_V1
    {
        public static Standard_GB16780_2012.Parameters_ComparableData SetComparableParametersFromSql(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            Standard_GB16780_2012.Parameters_ComparableData m_ComparableData = new Standard_GB16780_2012.Parameters_ComparableData();

            GetDefaultParametersValue(ref m_ComparableData, mySqlServerDataFactory);       //获取默认的参数值

            GetCementWeightedCompressiveStrength(myStaticsCycle, myStartTime, myEndTime, myFactoryOrganizationId, ref m_ComparableData, mySqlServerDataFactory);   //获得水泥加权强度
            GetFactoryPropertyFixedValue(myStaticsCycle, myStartTime, myEndTime, myFactoryOrganizationId, ref m_ComparableData, mySqlServerDataFactory);         //获得工厂固定属性数值
            GetMenualInputValue(myStaticsCycle, myStartTime, myEndTime, myFactoryOrganizationId, ref m_ComparableData, mySqlServerDataFactory);          //获得手动录入数值
            return m_ComparableData;
        }
        public static Standard_GB16780_2012.Parameters_ComprehensiveData SetComprehensiveParametersFromSql(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            Standard_GB16780_2012.Parameters_ComprehensiveData m_ComprehensiveData = new Standard_GB16780_2012.Parameters_ComprehensiveData();

            GetDefaultParametersValue(ref m_ComprehensiveData, mySqlServerDataFactory);       //获取默认的参数值

            GetMenualInputValue(myStaticsCycle, myStartTime, myEndTime, myFactoryOrganizationId, ref m_ComprehensiveData, mySqlServerDataFactory);          //获得手动录入数值
            return m_ComprehensiveData;
        }
        public static Standard_GB16780_2012.Parameters_ComprehensiveData SetComprehensiveParametersFromSql(string myStaticsCycle, string myStartTime, string myEndTime, string myFactoryOrganizationId, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            Standard_GB16780_2012.Parameters_ComprehensiveData m_ComprehensiveData = new Standard_GB16780_2012.Parameters_ComprehensiveData();

            GetDefaultParametersValue(ref m_ComprehensiveData, mySqlServerDataFactory);       //获取默认的参数值
            List<string> m_FactoryOrganizationId = new List<string>();
            m_FactoryOrganizationId.Add(myFactoryOrganizationId);
            GetMenualInputValue(myStaticsCycle, myStartTime, myEndTime, m_FactoryOrganizationId, ref m_ComprehensiveData, mySqlServerDataFactory);          //获得手动录入数值
            return m_ComprehensiveData;
        }
        public static Standard_GB16780_2012.Parameters_ComparableData SetComparableParametersEntity()
        {
            Standard_GB16780_2012.Parameters_ComparableData m_ComparableData = new Standard_GB16780_2012.Parameters_ComparableData();
            m_ComparableData.Clinker_ActualAltitude = 1020m;                         //熟料实际海拔高度
            m_ComparableData.Cement_ActualAltitude = 1020m;                          //水泥实际海拔高度
            m_ComparableData.Clinker_ActualAtmosphericPressure = 101325m;              //熟料实际大气压强
            m_ComparableData.Cement_ActualAtmosphericPressure = 101325m;               //水泥实际大气压强
            m_ComparableData.ClinkerOutsourcing_PowerConsumption = 65m;    //外购熟料综合电耗
            m_ComparableData.ClinkerOutsourcing_CoalConsumption = 100m;     //外购熟料综合煤耗
            m_ComparableData.ClinkerCompressiveStrength = 52.5m;             //熟料28d抗压强度

            m_ComparableData.CementCompressiveStrength = 42.5m;              //水泥强度

            m_ComparableData.CoalLowCalorificValue = 29307m;                  //煤粉低位发热量
            m_ComparableData.CoalWaterContent = 0m;                       //煤粉水分

            m_ComparableData.RecuperationExportHeat = 0m;                 //余热利用出口热量
            m_ComparableData.RecuperationImportHeat = 0m;                 //余热利用进口热量
            m_ComparableData.RecuperationLossHeat = 0m;                  //余热利用损失热量

            m_ComparableData.CorrectedAltitude = 1000;                      //修正海拔高度
            m_ComparableData.StandardAtmosphericPressure = 101325m;            //标准大气压强
            m_ComparableData.Cement_CorrectedCompressiveStrength = 42.5m;    //水泥修正强度
            m_ComparableData.Clinker_CorrectedCompressiveStrength = 52.5m;   //熟料修正强度
            m_ComparableData.ElectricityToCoalFactor = 0.1229m;                 //用电折合用煤系数
            m_ComparableData.StandardCalorificValue = 29307m;                //标准煤发热量
            return m_ComparableData;
        }
        public static Standard_GB16780_2012.Parameters_ComprehensiveData SetComprehensiveParametersEntity()
        {
            Standard_GB16780_2012.Parameters_ComprehensiveData m_ComprehensiveData = new Standard_GB16780_2012.Parameters_ComprehensiveData();
            
            m_ComprehensiveData.ClinkerOutsourcing_PowerConsumption = 65m;    //外购熟料综合电耗
            m_ComprehensiveData.ClinkerOutsourcing_CoalConsumption = 100m;     //外购熟料综合煤耗

            m_ComprehensiveData.CoalLowCalorificValue = 29307m;                  //煤粉低位发热量
            m_ComprehensiveData.CoalWaterContent = 0m;                       //煤粉水分

            m_ComprehensiveData.ElectricityToCoalFactor = 0.1229m;                 //用电折合用煤系数
            m_ComprehensiveData.StandardCalorificValue = 29307m;                //标准煤发热量
            return m_ComprehensiveData;
        }
        /// <summary>
        /// 设置可比综合能耗默认值
        /// </summary>
        /// <param name="myComparableData">可比综合能耗参数集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetDefaultParametersValue(ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            string m_Sql = @"Select
                                A.VariableId as VariableId,
                                A.OrganizationID as OrganizationId,
                                A.Type as Type, 
                                A.DefaultValue as DefaultValue 
                                from analyse_KPI_DefaultParametersValue A";
            try
            {
                DataTable m_Result = mySqlServerDataFactory.Query(m_Sql);
                if (m_Result != null)
                {
                    myComparableData.Clinker_ActualAltitude = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ActualAltitude");                         //熟料实际海拔高度
                    myComparableData.Cement_ActualAltitude = myComparableData.Clinker_ActualAltitude;                          //水泥实际海拔高度
                    myComparableData.Clinker_ActualAtmosphericPressure = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ActualAtmosphericPressure");              //熟料实际大气压强
                    myComparableData.Cement_ActualAtmosphericPressure = myComparableData.Clinker_ActualAtmosphericPressure;               //水泥实际大气压强
                    myComparableData.ClinkerOutsourcing_PowerConsumption = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerOutsourcing_PowerConsumption");    //外购熟料综合电耗
                    myComparableData.ClinkerOutsourcing_CoalConsumption = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerOutsourcing_CoalConsumption");     //外购熟料综合煤耗
                    myComparableData.ClinkerCompressiveStrength = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerCompressiveStrength");             //熟料28d抗压强度

                    myComparableData.CementCompressiveStrength = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CementCompressiveStrength");              //水泥强度

                    myComparableData.CoalLowCalorificValue = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CoalLowCalorificValue");                  //煤粉低位发热量
                    myComparableData.CoalWaterContent = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CoalWaterContent");                       //煤粉水分

                    myComparableData.RecuperationExportHeat = GetDefaultParametersValueByVariableId(ref m_Result, "Default_RecuperationExportHeat");                 //余热利用出口热量
                    myComparableData.RecuperationImportHeat = GetDefaultParametersValueByVariableId(ref m_Result, "Default_RecuperationImportHeat");                 //余热利用进口热量
                    myComparableData.RecuperationLossHeat = GetDefaultParametersValueByVariableId(ref m_Result, "Default_RecuperationLossHeat");                  //余热利用损失热量

                    myComparableData.CorrectedAltitude = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CorrectedAltitude");                      //修正海拔高度
                    myComparableData.StandardAtmosphericPressure = GetDefaultParametersValueByVariableId(ref m_Result, "Default_StandardAtmosphericPressure");            //标准大气压强
                    myComparableData.Cement_CorrectedCompressiveStrength = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CorrectedCementCompressiveStrength");    //水泥修正强度
                    myComparableData.Clinker_CorrectedCompressiveStrength = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CorrectedClinkerCompressiveStrength");   //熟料修正强度
                    myComparableData.ElectricityToCoalFactor = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ElectricityToCoalFactor");                 //用电折合用煤系数
                    myComparableData.StandardCalorificValue = GetDefaultParametersValueByVariableId(ref m_Result, "Default_StandardCalorificValue");                //标准煤发热量
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 获得水泥强度加权平均值
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂组织机构ID</param>
        /// <param name="myComparableData">可比数据</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetCementWeightedCompressiveStrength(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            string m_Sql = @"SELECT  
                                B.VariableId as VariableId, 
                                sum(B.TotalPeakValleyFlatB) as Value, 
                                sum(case when C.Intensity is null then 0 else C.Intensity end) as Intensity
                                FROM  tz_balance A, balance_Energy B, system_CementTypesAndConvertCoefficient C
                                where A.TimeStamp >='{1}'
                                and A.TimeStamp <= '{2}'
                                and A.StaticsCycle= '{3}'
                                and A.BalanceId = B.KeyID
                                and B.VariableId = C.CementTypes
                                and A.OrganizationID in ({0})
                                group by B.VariableId";
            string m_FactoryOrganizationId = "";
            if (myFactoryOrganizationId != null)
            {
                for (int i = 0; i < myFactoryOrganizationId.Count; i++)
                {
                    if (i == 0)
                    {
                        m_FactoryOrganizationId = "'" + myFactoryOrganizationId[i] + "'";
                    }
                    else
                    {
                        m_FactoryOrganizationId = m_FactoryOrganizationId + ",'" + myFactoryOrganizationId[i] + "'";
                    }
                }
            }
            try
            {
                m_Sql = string.Format(m_Sql, m_FactoryOrganizationId, myStartTime, myEndTime, myStaticsCycle);
                DataTable m_Result = mySqlServerDataFactory.Query(m_Sql);
                if (m_Result != null)
                {
                    //////////水泥强度加权平均值
                    DataRow[] m_CementCompressiveStrength = m_Result.Select("'VariableId <> ''");
                    myComparableData.CementCompressiveStrength = GetWeightedAverageValue(m_CementCompressiveStrength, "Intensity", "Value", myComparableData.CementCompressiveStrength);            //熟料实际大气压强      
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 工厂固定属性值(含按产量均摊)
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂级别组织机构</param>
        /// <param name="myComparableData">可比数据集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetFactoryPropertyFixedValue(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            GetCoefficientAltitude(myStaticsCycle, myStartTime, myEndTime, myFactoryOrganizationId, ref myComparableData, mySqlServerDataFactory);
        }
        /// <summary>
        /// 获得可比能耗手动录入参数的加权平均值
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂组织机构ID</param>
        /// <param name="myComparableData">可比数据</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetMenualInputValue(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            string m_Sql = @"SELECT D.VariableId as DataVariableId, 
                                F.VariableId as ManualInputVariableId, 
                                F.ManualInputValue as ManualInputValue,
                                D.Value as Value
                                FROM 
                                (select B.OrganizationID as OrganizationID, C.VariableId as VariableId, sum(C.TotalPeakValleyFlatB) as Value
					                 from tz_Balance B, balance_Energy C
						             where B.BalanceId = C.KeyID
						             and B.OrganizationID in ({0})
						             and B.StaticsCycle = '{1}'
						             and B.TimeStamp >= '{2}'
						             and B.TimeStamp <= '{3}'
						             and C.VariableId in ('clinker_clinkerOutput','cement_CementOutput','clinker_ClinkerOutsourcingInput','clinker_PulverizedCoalInput')
                                     group by B.OrganizationID, C.VariableId        
					            ) D,
                                (select E.OrganizationID as OrganizationID, E.VariableId as VariableId, sum(E.DataValue) as ManualInputValue
                                     from system_EnergyDataManualInput E
                                     where E.OrganizationID in ({0})
                                     and E.UpdateCycle = 'day'                  
                                     and E.TimeStamp >= '{2}'
                                     and E.TimeStamp <= '{3}'
                                     group by E.OrganizationID, E.VariableId
                                ) F
                                where D.OrganizationID = F.OrganizationID";
            string m_FactoryOrganizationId = "";
            if (myFactoryOrganizationId != null)
            {
                for (int i = 0; i < myFactoryOrganizationId.Count; i++)
                {
                    if (i == 0)
                    {
                        m_FactoryOrganizationId = "'" + myFactoryOrganizationId[i] + "'";
                    }
                    else
                    {
                        m_FactoryOrganizationId = m_FactoryOrganizationId + ",'" + myFactoryOrganizationId[i] + "'";
                    }
                }
            }
            try
            {
                m_Sql = string.Format(m_Sql, m_FactoryOrganizationId, myStartTime, myEndTime);
                DataTable m_Result = mySqlServerDataFactory.Query(m_Sql);
                if (m_Result != null)
                {
                    //////////熟料实际大气压加权平均值
                    DataRow[] m_Clinker_factory_AtmosphericPressureAvg = m_Result.Select("'DataVariableId = 'clinker_clinkerOutput' and ManualInputVariableId = 'factory_AtmosphericPressureAvg'");
                    myComparableData.Clinker_ActualAtmosphericPressure = GetWeightedAverageValue(m_Clinker_factory_AtmosphericPressureAvg, "ManualInputValue", "Value", myComparableData.Clinker_ActualAtmosphericPressure);            //熟料实际大气压强
                    //////////水泥实际大气压加权平均值
                    DataRow[] m_Cement_factory_AtmosphericPressureAvg = m_Result.Select("'DataVariableId = 'cement_CementOutput' and ManualInputVariableId = 'factory_AtmosphericPressureAvg'");
                    myComparableData.Cement_ActualAtmosphericPressure = GetWeightedAverageValue(m_Cement_factory_AtmosphericPressureAvg, "ManualInputValue", "Value", myComparableData.Cement_ActualAtmosphericPressure);

                    //////////外购熟料综合电耗加权平均值
                    DataRow[] m_ClinkerOutsourcing_PowerConsumption = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'ClinkerOutsourcing_PowerConsumption'");
                    myComparableData.ClinkerOutsourcing_PowerConsumption = GetWeightedAverageValue(m_ClinkerOutsourcing_PowerConsumption, "ManualInputValue", "Value", myComparableData.ClinkerOutsourcing_PowerConsumption);

                    //////////外购熟料综合煤耗加权平均值
                    DataRow[] m_ClinkerOutsourcing_CoalConsumption = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'ClinkerOutsourcing_CoalConsumption'");
                    myComparableData.ClinkerOutsourcing_CoalConsumption = GetWeightedAverageValue(m_ClinkerOutsourcing_CoalConsumption, "ManualInputValue", "Value", myComparableData.ClinkerOutsourcing_CoalConsumption);

                    //////////熟料28d抗压强度加权平均值
                    DataRow[] m_ClinkerCompressiveStrength = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'clinker_Strength28d'");
                    myComparableData.ClinkerCompressiveStrength = GetWeightedAverageValue(m_ClinkerCompressiveStrength, "ManualInputValue", "Value", myComparableData.ClinkerCompressiveStrength);

                    //////////煤粉低位发热量加权平均值
                    DataRow[] m_CoalLowCalorificValue = m_Result.Select("'DataVariableId = 'clinker_PulverizedCoalInput' and ManualInputVariableId = 'PulverizedCoal_LowCalorificValue'");
                    myComparableData.CoalLowCalorificValue = GetWeightedAverageValue(m_CoalLowCalorificValue, "ManualInputValue", "Value", myComparableData.CoalLowCalorificValue);
                    
                    //////////煤粉水分加权平均值
                    DataRow[] m_CoalWaterContent = m_Result.Select("'DataVariableId = 'clinker_PulverizedCoalInput' and ManualInputVariableId = 'PulverizedCoal_WaterContent'");
                    myComparableData.CoalWaterContent = GetWeightedAverageValue(m_CoalWaterContent, "ManualInputValue", "Value", myComparableData.CoalWaterContent);
                    
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 获得综合能耗手动录入参数的加权平均值
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂组织机构</param>
        /// <param name="myComprehensiveData">综合数据集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetMenualInputValue(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComprehensiveData myComprehensiveData, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            string m_Sql = @"SELECT D.VariableId as DataVariableId, 
                                F.VariableId as ManualInputVariableId, 
                                F.ManualInputValue as ManualInputValue,
                                D.Value as Value
                                FROM 
                                (select B.OrganizationID as OrganizationID, C.VariableId as VariableId, sum(C.TotalPeakValleyFlatB) as Value
					                 from tz_Balance B, balance_Energy C
						             where B.BalanceId = C.KeyID
						             and B.OrganizationID in ({0})
						             and B.StaticsCycle = '{1}'
						             and B.TimeStamp >= '{2}'
						             and B.TimeStamp <= '{3}'
						             and C.VariableId in ('clinker_clinkerOutput','cement_CementOutput','clinker_ClinkerOutsourcingInput','clinker_PulverizedCoalInput')
                                     group by B.OrganizationID, C.VariableId        
					            ) D,
                                (select E.OrganizationID as OrganizationID, E.VariableId as VariableId, sum(E.DataValue) as ManualInputValue
                                     from system_EnergyDataManualInput E
                                     where E.OrganizationID in ({0})
                                     and E.UpdateCycle = 'day'                  
                                     and E.TimeStamp >= '{2}'
                                     and E.TimeStamp <= '{3}'
                                     group by E.OrganizationID, E.VariableId
                                ) F
                                where D.OrganizationID = F.OrganizationID";
            string m_FactoryOrganizationId = "";
            if (myFactoryOrganizationId != null)
            {
                for (int i = 0; i < myFactoryOrganizationId.Count; i++)
                {
                    if (i == 0)
                    {
                        m_FactoryOrganizationId = "'" + myFactoryOrganizationId[i] + "'";
                    }
                    else
                    {
                        m_FactoryOrganizationId = m_FactoryOrganizationId + ",'" + myFactoryOrganizationId[i] + "'";
                    }
                }
            }
            try
            {
                m_Sql = string.Format(m_Sql, m_FactoryOrganizationId, myStartTime, myEndTime);
                DataTable m_Result = mySqlServerDataFactory.Query(m_Sql);
                if (m_Result != null)
                {
                    //////////外购熟料综合电耗加权平均值
                    DataRow[] m_ClinkerOutsourcing_PowerConsumption = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'ClinkerOutsourcing_PowerConsumption'");
                    myComprehensiveData.ClinkerOutsourcing_PowerConsumption = GetWeightedAverageValue(m_ClinkerOutsourcing_PowerConsumption, "ManualInputValue", "Value", myComprehensiveData.ClinkerOutsourcing_PowerConsumption);

                    //////////外购熟料综合煤耗加权平均值
                    DataRow[] m_ClinkerOutsourcing_CoalConsumption = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'ClinkerOutsourcing_CoalConsumption'");
                    myComprehensiveData.ClinkerOutsourcing_CoalConsumption = GetWeightedAverageValue(m_ClinkerOutsourcing_CoalConsumption, "ManualInputValue", "Value", myComprehensiveData.ClinkerOutsourcing_CoalConsumption);

                    //////////煤粉低位发热量加权平均值
                    DataRow[] m_CoalLowCalorificValue = m_Result.Select("'DataVariableId = 'clinker_PulverizedCoalInput' and ManualInputVariableId = 'PulverizedCoal_LowCalorificValue'");
                    myComprehensiveData.CoalLowCalorificValue = GetWeightedAverageValue(m_CoalLowCalorificValue, "ManualInputValue", "Value", myComprehensiveData.CoalLowCalorificValue);

                    //////////煤粉水分加权平均值
                    DataRow[] m_CoalWaterContent = m_Result.Select("clinker_PulverizedCoalInput' and ManualInputVariableId = 'PulverizedCoal_WaterContent'");
                    myComprehensiveData.CoalWaterContent = GetWeightedAverageValue(m_CoalWaterContent, "ManualInputValue", "Value", myComprehensiveData.CoalWaterContent);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 设置综合能耗默认值
        /// </summary>
        /// <param name="myComprehensiveData">综合能耗参数集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetDefaultParametersValue(ref Standard_GB16780_2012.Parameters_ComprehensiveData myComprehensiveData, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {
            string m_Sql = @"Select
                                A.VariableId as VariableId,
                                A.OrganizationID as OrganizationId,
                                A.Type as Type, 
                                A.DefaultValue as DefaultValue 
                                from analyse_KPI_DefaultParametersValue A";
            try
            {
                DataTable m_Result = mySqlServerDataFactory.Query(m_Sql);
                if (m_Result != null)
                {
                    myComprehensiveData.ClinkerOutsourcing_PowerConsumption = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerOutsourcing_PowerConsumption");    //外购熟料综合电耗
                    myComprehensiveData.ClinkerOutsourcing_CoalConsumption = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerOutsourcing_CoalConsumption");     //外购熟料综合煤耗
       
                    myComprehensiveData.CoalLowCalorificValue = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CoalLowCalorificValue");                  //煤粉低位发热量
                    myComprehensiveData.CoalWaterContent = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CoalWaterContent");                       //煤粉水分
  
                    myComprehensiveData.ElectricityToCoalFactor = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ElectricityToCoalFactor");                 //用电折合用煤系数
                    myComprehensiveData.StandardCalorificValue = GetDefaultParametersValueByVariableId(ref m_Result, "Default_StandardCalorificValue");                //标准煤发热量
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 计算海拔高度
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂级别组织机构</param>
        /// <param name="myComparableData">可比数据集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetCoefficientAltitude(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, SqlServerDataAdapter.ISqlServerDataFactory mySqlServerDataFactory)
        {   //计算海拔高度
            string m_FactoryOrganizationId = "";
            if (myFactoryOrganizationId != null)
            {
                for (int i = 0; i < myFactoryOrganizationId.Count; i++)
                {
                    if (i == 0)
                    {
                        m_FactoryOrganizationId = "'" + myFactoryOrganizationId[i] + "'";
                    }
                    else
                    {
                        m_FactoryOrganizationId = m_FactoryOrganizationId + ",'" + myFactoryOrganizationId[i] + "'";
                    }
                }
            }
            string m_Sql = @"Select
                                (case when A.CoefficientAltitude is null then 0 else A.CoefficientAltitude end) as CoefficientAltitude, 
                                A.OrganizationID as OrganizationId,
                                D.VariableId as VariableId, 
                                D.Value as Value
                                from system_Organization A, 
					            (select B.OrganizationID as OrganizationID, C.VariableId as VariableId, sum(C.TotalPeakValleyFlatB) as Value
					                from tz_Balance B, balance_Energy C
						            where B.BalanceId = C.KeyID
						            and B.OrganizationID in ({0})
						            and B.StaticsCycle = '{1}'
						            and B.TimeStamp >= '{2}'
						            and B.TimeStamp <= '{3}'
						            and C.VariableId in ('clinker_clinkerOutput','cement_CementOutput')
						            group by B.OrganizationID, C.VariableId
					            ) D
					            where A.OrganizationID in ({0})
					            and A.OrganizationID = D.OrganizationID";
            try
            {
                m_Sql = string.Format(m_Sql, m_FactoryOrganizationId, myStaticsCycle, myStartTime, myEndTime);
                DataTable m_Result = mySqlServerDataFactory.Query(m_Sql);
                if (m_Result != null)
                {
                    //////////////按熟料产量均摊海拔高度
                    DataRow[] m_clinkerOutput = m_Result.Select("'VariableId = 'clinker_clinkerOutput'");
                    myComparableData.Clinker_ActualAltitude = GetWeightedAverageValue(m_clinkerOutput, "CoefficientAltitude", "Value", myComparableData.Clinker_ActualAltitude);
                    //////////////按水泥产量均摊海拔高度
                    DataRow[] m_cementOutput = m_Result.Select("'VariableId = 'cement_cementOutput'");
                    myComparableData.Clinker_ActualAltitude = GetWeightedAverageValue(m_clinkerOutput, "CoefficientAltitude", "Value", myComparableData.Clinker_ActualAltitude);
                }

            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 根据VariableId查找参数值
        /// </summary>
        /// <param name="myDefaultParametersTable">参数值集合</param>
        /// <param name="myVariableId">变量ID</param>
        /// <returns>参数值</returns>
        private static decimal GetDefaultParametersValueByVariableId(ref DataTable myDefaultParametersTable, string myVariableId)
        {
            decimal m_DefaultParametersValue = 0.0m;
            for(int i=0;i< myDefaultParametersTable.Rows.Count;i++)
            {
                if(myDefaultParametersTable.Rows[i]["VariableId"].ToString() == myVariableId)
                {
                    m_DefaultParametersValue = (decimal)myDefaultParametersTable.Rows[i]["DefaultValue"];
                    myDefaultParametersTable.Rows.RemoveAt(i);
                    break;
                }
            }
            return m_DefaultParametersValue;
        }
        /// <summary>
        /// 获得加权平均值
        /// </summary>
        /// <param name="myValueRows">值集合</param>
        /// <param name="myTargetValueColumn">目标值字段</param>
        /// <param name="myWeightedValueColumn">加权字段</param>
        /// <param name="myDefaultValue">默认字段</param>
        /// <returns>加权平均值</returns>
        public static decimal GetWeightedAverageValue(DataRow[] myValueRows, string myTargetValueColumn, string myWeightedValueColumn, decimal myDefaultValue)
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




        ///////////////////另一种数据库查询方式
        /// <summary>
        /// 设置可比综合能耗默认值
        /// </summary>
        /// <param name="myComparableData">可比综合能耗参数集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetDefaultParametersValue(ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, mDbDataAdaper.mSqlServerDbDataAdaper mySqlServerDataFactory)
        {
            string m_Sql = @"Select
                                A.VariableId as VariableId,
                                A.OrganizationID as OrganizationId,
                                A.Type as Type, 
                                A.DefaultValue as DefaultValue 
                                from analyse_KPI_DefaultParametersValue A";
            try
            {
                DataTable m_Result = mySqlServerDataFactory.Fill(null, m_Sql, "Table").Tables["Table"];
                if (m_Result != null)
                {
                    myComparableData.Clinker_ActualAltitude = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ActualAltitude");                         //熟料实际海拔高度
                    myComparableData.Cement_ActualAltitude = myComparableData.Clinker_ActualAltitude;                          //水泥实际海拔高度
                    myComparableData.Clinker_ActualAtmosphericPressure = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ActualAtmosphericPressure");              //熟料实际大气压强
                    myComparableData.Cement_ActualAtmosphericPressure = myComparableData.Clinker_ActualAtmosphericPressure;               //水泥实际大气压强
                    myComparableData.ClinkerOutsourcing_PowerConsumption = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerOutsourcing_PowerConsumption");    //外购熟料综合电耗
                    myComparableData.ClinkerOutsourcing_CoalConsumption = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerOutsourcing_CoalConsumption");     //外购熟料综合煤耗
                    myComparableData.ClinkerCompressiveStrength = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerCompressiveStrength");             //熟料28d抗压强度

                    myComparableData.CementCompressiveStrength = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CementCompressiveStrength");              //水泥强度

                    myComparableData.CoalLowCalorificValue = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CoalLowCalorificValue");                  //煤粉低位发热量
                    myComparableData.CoalWaterContent = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CoalWaterContent");                       //煤粉水分

                    myComparableData.RecuperationExportHeat = GetDefaultParametersValueByVariableId(ref m_Result, "Default_RecuperationExportHeat");                 //余热利用出口热量
                    myComparableData.RecuperationImportHeat = GetDefaultParametersValueByVariableId(ref m_Result, "Default_RecuperationImportHeat");                 //余热利用进口热量
                    myComparableData.RecuperationLossHeat = GetDefaultParametersValueByVariableId(ref m_Result, "Default_RecuperationLossHeat");                  //余热利用损失热量

                    myComparableData.CorrectedAltitude = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CorrectedAltitude");                      //修正海拔高度
                    myComparableData.StandardAtmosphericPressure = GetDefaultParametersValueByVariableId(ref m_Result, "Default_StandardAtmosphericPressure");            //标准大气压强
                    myComparableData.Cement_CorrectedCompressiveStrength = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CorrectedCementCompressiveStrength");    //水泥修正强度
                    myComparableData.Clinker_CorrectedCompressiveStrength = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CorrectedClinkerCompressiveStrength");   //熟料修正强度
                    myComparableData.ElectricityToCoalFactor = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ElectricityToCoalFactor");                 //用电折合用煤系数
                    myComparableData.StandardCalorificValue = GetDefaultParametersValueByVariableId(ref m_Result, "Default_StandardCalorificValue");                //标准煤发热量
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 获得水泥强度加权平均值
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂组织机构ID</param>
        /// <param name="myComparableData">可比数据</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetCementWeightedCompressiveStrength(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, mDbDataAdaper.mSqlServerDbDataAdaper mySqlServerDataFactory)
        {
            string m_Sql = @"SELECT  
                                B.VariableId as VariableId, 
                                sum(B.TotalPeakValleyFlatB) as Value, 
                                sum(case when C.Intensity is null then 0 else C.Intensity end) as Intensity
                                FROM  tz_balance A, balance_Energy B, system_CementTypesAndConvertCoefficient C
                                where A.TimeStamp >='{1}'
                                and A.TimeStamp <= '{2}'
                                and A.StaticsCycle= '{3}'
                                and A.BalanceId = B.KeyID
                                and B.VariableId = C.CementTypes
                                and A.OrganizationID in ({0})
                                group by B.VariableId";
            string m_FactoryOrganizationId = "";
            if (myFactoryOrganizationId != null)
            {
                for (int i = 0; i < myFactoryOrganizationId.Count; i++)
                {
                    if (i == 0)
                    {
                        m_FactoryOrganizationId = "'" + myFactoryOrganizationId[i] + "'";
                    }
                    else
                    {
                        m_FactoryOrganizationId = m_FactoryOrganizationId + ",'" + myFactoryOrganizationId[i] + "'";
                    }
                }
            }
            try
            {
                m_Sql = string.Format(m_Sql, m_FactoryOrganizationId, myStartTime, myEndTime, myStaticsCycle);
                DataTable m_Result = mySqlServerDataFactory.Fill(null, m_Sql, "Table").Tables["Table"];
                if (m_Result != null)
                {
                    //////////水泥强度加权平均值
                    DataRow[] m_CementCompressiveStrength = m_Result.Select("'VariableId <> ''");
                    myComparableData.CementCompressiveStrength = GetWeightedAverageValue(m_CementCompressiveStrength, "Intensity", "Value", myComparableData.CementCompressiveStrength);            //熟料实际大气压强      
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 工厂固定属性值(含按产量均摊)
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂级别组织机构</param>
        /// <param name="myComparableData">可比数据集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetFactoryPropertyFixedValue(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, mDbDataAdaper.mSqlServerDbDataAdaper mySqlServerDataFactory)
        {
            GetCoefficientAltitude(myStaticsCycle, myStartTime, myEndTime, myFactoryOrganizationId, ref myComparableData, mySqlServerDataFactory);
        }
        /// <summary>
        /// 获得可比能耗手动录入参数的加权平均值
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂组织机构ID</param>
        /// <param name="myComparableData">可比数据</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetMenualInputValue(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, mDbDataAdaper.mSqlServerDbDataAdaper mySqlServerDataFactory)
        {
            string m_Sql = @"SELECT D.VariableId as DataVariableId, 
                                F.VariableId as ManualInputVariableId, 
                                F.ManualInputValue as ManualInputValue,
                                D.Value as Value
                                FROM 
                                (select B.OrganizationID as OrganizationID, C.VariableId as VariableId, sum(C.TotalPeakValleyFlatB) as Value
					                 from tz_Balance B, balance_Energy C
						             where B.BalanceId = C.KeyID
						             and B.OrganizationID in ({0})
						             and B.StaticsCycle = '{1}'
						             and B.TimeStamp >= '{2}'
						             and B.TimeStamp <= '{3}'
						             and C.VariableId in ('clinker_clinkerOutput','cement_CementOutput','clinker_ClinkerOutsourcingInput','clinker_PulverizedCoalInput')
                                     group by B.OrganizationID, C.VariableId        
					            ) D,
                                (select E.OrganizationID as OrganizationID, E.VariableId as VariableId, sum(E.DataValue) as ManualInputValue
                                     from system_EnergyDataManualInput E
                                     where E.OrganizationID in ({0})
                                     and E.UpdateCycle = 'day'                  
                                     and E.TimeStamp >= '{2}'
                                     and E.TimeStamp <= '{3}'
                                     group by E.OrganizationID, E.VariableId
                                ) F
                                where D.OrganizationID = F.OrganizationID";
            string m_FactoryOrganizationId = "";
            if (myFactoryOrganizationId != null)
            {
                for (int i = 0; i < myFactoryOrganizationId.Count; i++)
                {
                    if (i == 0)
                    {
                        m_FactoryOrganizationId = "'" + myFactoryOrganizationId[i] + "'";
                    }
                    else
                    {
                        m_FactoryOrganizationId = m_FactoryOrganizationId + ",'" + myFactoryOrganizationId[i] + "'";
                    }
                }
            }
            try
            {
                m_Sql = string.Format(m_Sql, m_FactoryOrganizationId, myStartTime, myEndTime);
                DataTable m_Result = mySqlServerDataFactory.Fill(null, m_Sql,"Table").Tables["Table"];
                if (m_Result != null)
                {
                    //////////熟料实际大气压加权平均值
                    DataRow[] m_Clinker_factory_AtmosphericPressureAvg = m_Result.Select("'DataVariableId = 'clinker_clinkerOutput' and ManualInputVariableId = 'factory_AtmosphericPressureAvg'");
                    myComparableData.Clinker_ActualAtmosphericPressure = GetWeightedAverageValue(m_Clinker_factory_AtmosphericPressureAvg, "ManualInputValue", "Value", myComparableData.Clinker_ActualAtmosphericPressure);            //熟料实际大气压强
                    //////////水泥实际大气压加权平均值
                    DataRow[] m_Cement_factory_AtmosphericPressureAvg = m_Result.Select("'DataVariableId = 'cement_CementOutput' and ManualInputVariableId = 'factory_AtmosphericPressureAvg'");
                    myComparableData.Cement_ActualAtmosphericPressure = GetWeightedAverageValue(m_Cement_factory_AtmosphericPressureAvg, "ManualInputValue", "Value", myComparableData.Cement_ActualAtmosphericPressure);

                    //////////外购熟料综合电耗加权平均值
                    DataRow[] m_ClinkerOutsourcing_PowerConsumption = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'ClinkerOutsourcing_PowerConsumption'");
                    myComparableData.ClinkerOutsourcing_PowerConsumption = GetWeightedAverageValue(m_ClinkerOutsourcing_PowerConsumption, "ManualInputValue", "Value", myComparableData.ClinkerOutsourcing_PowerConsumption);

                    //////////外购熟料综合煤耗加权平均值
                    DataRow[] m_ClinkerOutsourcing_CoalConsumption = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'ClinkerOutsourcing_CoalConsumption'");
                    myComparableData.ClinkerOutsourcing_CoalConsumption = GetWeightedAverageValue(m_ClinkerOutsourcing_CoalConsumption, "ManualInputValue", "Value", myComparableData.ClinkerOutsourcing_CoalConsumption);

                    //////////熟料28d抗压强度加权平均值
                    DataRow[] m_ClinkerCompressiveStrength = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'clinker_Strength28d'");
                    myComparableData.ClinkerCompressiveStrength = GetWeightedAverageValue(m_ClinkerCompressiveStrength, "ManualInputValue", "Value", myComparableData.ClinkerCompressiveStrength);

                    //////////煤粉低位发热量加权平均值
                    DataRow[] m_CoalLowCalorificValue = m_Result.Select("'DataVariableId = 'clinker_PulverizedCoalInput' and ManualInputVariableId = 'PulverizedCoal_LowCalorificValue'");
                    myComparableData.CoalLowCalorificValue = GetWeightedAverageValue(m_CoalLowCalorificValue, "ManualInputValue", "Value", myComparableData.CoalLowCalorificValue);

                    //////////煤粉水分加权平均值
                    DataRow[] m_CoalWaterContent = m_Result.Select("'DataVariableId = 'clinker_PulverizedCoalInput' and ManualInputVariableId = 'PulverizedCoal_WaterContent'");
                    myComparableData.CoalWaterContent = GetWeightedAverageValue(m_CoalWaterContent, "ManualInputValue", "Value", myComparableData.CoalWaterContent);

                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 获得综合能耗手动录入参数的加权平均值
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂组织机构</param>
        /// <param name="myComprehensiveData">综合数据集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetMenualInputValue(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComprehensiveData myComprehensiveData, mDbDataAdaper.mSqlServerDbDataAdaper mySqlServerDataFactory)
        {
            string m_Sql = @"SELECT D.VariableId as DataVariableId, 
                                F.VariableId as ManualInputVariableId, 
                                F.ManualInputValue as ManualInputValue,
                                D.Value as Value
                                FROM 
                                (select B.OrganizationID as OrganizationID, C.VariableId as VariableId, sum(C.TotalPeakValleyFlatB) as Value
					                 from tz_Balance B, balance_Energy C
						             where B.BalanceId = C.KeyID
						             and B.OrganizationID in ({0})
						             and B.StaticsCycle = '{1}'
						             and B.TimeStamp >= '{2}'
						             and B.TimeStamp <= '{3}'
						             and C.VariableId in ('clinker_clinkerOutput','cement_CementOutput','clinker_ClinkerOutsourcingInput','clinker_PulverizedCoalInput')
                                     group by B.OrganizationID, C.VariableId        
					            ) D,
                                (select E.OrganizationID as OrganizationID, E.VariableId as VariableId, sum(E.DataValue) as ManualInputValue
                                     from system_EnergyDataManualInput E
                                     where E.OrganizationID in ({0})
                                     and E.UpdateCycle = 'day'                  
                                     and E.TimeStamp >= '{2}'
                                     and E.TimeStamp <= '{3}'
                                     group by E.OrganizationID, E.VariableId
                                ) F
                                where D.OrganizationID = F.OrganizationID";
            string m_FactoryOrganizationId = "";
            if (myFactoryOrganizationId != null)
            {
                for (int i = 0; i < myFactoryOrganizationId.Count; i++)
                {
                    if (i == 0)
                    {
                        m_FactoryOrganizationId = "'" + myFactoryOrganizationId[i] + "'";
                    }
                    else
                    {
                        m_FactoryOrganizationId = m_FactoryOrganizationId + ",'" + myFactoryOrganizationId[i] + "'";
                    }
                }
            }
            try
            {
                m_Sql = string.Format(m_Sql, m_FactoryOrganizationId, myStartTime, myEndTime);
                DataTable m_Result = mySqlServerDataFactory.Fill(null,m_Sql,"Table").Tables["Table"];
                if (m_Result != null)
                {
                    //////////外购熟料综合电耗加权平均值
                    DataRow[] m_ClinkerOutsourcing_PowerConsumption = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'ClinkerOutsourcing_PowerConsumption'");
                    myComprehensiveData.ClinkerOutsourcing_PowerConsumption = GetWeightedAverageValue(m_ClinkerOutsourcing_PowerConsumption, "ManualInputValue", "Value", myComprehensiveData.ClinkerOutsourcing_PowerConsumption);

                    //////////外购熟料综合煤耗加权平均值
                    DataRow[] m_ClinkerOutsourcing_CoalConsumption = m_Result.Select("'DataVariableId = 'clinker_ClinkerOutsourcingInput' and ManualInputVariableId = 'ClinkerOutsourcing_CoalConsumption'");
                    myComprehensiveData.ClinkerOutsourcing_CoalConsumption = GetWeightedAverageValue(m_ClinkerOutsourcing_CoalConsumption, "ManualInputValue", "Value", myComprehensiveData.ClinkerOutsourcing_CoalConsumption);

                    //////////煤粉低位发热量加权平均值
                    DataRow[] m_CoalLowCalorificValue = m_Result.Select("'DataVariableId = 'clinker_PulverizedCoalInput' and ManualInputVariableId = 'PulverizedCoal_LowCalorificValue'");
                    myComprehensiveData.CoalLowCalorificValue = GetWeightedAverageValue(m_CoalLowCalorificValue, "ManualInputValue", "Value", myComprehensiveData.CoalLowCalorificValue);

                    //////////煤粉水分加权平均值
                    DataRow[] m_CoalWaterContent = m_Result.Select("clinker_PulverizedCoalInput' and ManualInputVariableId = 'PulverizedCoal_WaterContent'");
                    myComprehensiveData.CoalWaterContent = GetWeightedAverageValue(m_CoalWaterContent, "ManualInputValue", "Value", myComprehensiveData.CoalWaterContent);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 设置综合能耗默认值
        /// </summary>
        /// <param name="myComprehensiveData">综合能耗参数集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetDefaultParametersValue(ref Standard_GB16780_2012.Parameters_ComprehensiveData myComprehensiveData, mDbDataAdaper.mSqlServerDbDataAdaper mySqlServerDataFactory)
        {
            string m_Sql = @"Select
                                A.VariableId as VariableId,
                                A.OrganizationID as OrganizationId,
                                A.Type as Type, 
                                A.DefaultValue as DefaultValue 
                                from analyse_KPI_DefaultParametersValue A";
            try
            {
                DataTable m_Result = mySqlServerDataFactory.Fill(null,m_Sql,"Table").Tables["Table"];
                if (m_Result != null)
                {
                    myComprehensiveData.ClinkerOutsourcing_PowerConsumption = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerOutsourcing_PowerConsumption");    //外购熟料综合电耗
                    myComprehensiveData.ClinkerOutsourcing_CoalConsumption = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ClinkerOutsourcing_CoalConsumption");     //外购熟料综合煤耗

                    myComprehensiveData.CoalLowCalorificValue = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CoalLowCalorificValue");                  //煤粉低位发热量
                    myComprehensiveData.CoalWaterContent = GetDefaultParametersValueByVariableId(ref m_Result, "Default_CoalWaterContent");                       //煤粉水分

                    myComprehensiveData.ElectricityToCoalFactor = GetDefaultParametersValueByVariableId(ref m_Result, "Default_ElectricityToCoalFactor");                 //用电折合用煤系数
                    myComprehensiveData.StandardCalorificValue = GetDefaultParametersValueByVariableId(ref m_Result, "Default_StandardCalorificValue");                //标准煤发热量
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 计算海拔高度
        /// </summary>
        /// <param name="myStaticsCycle">统计周期</param>
        /// <param name="myStartTime">开始时间</param>
        /// <param name="myEndTime">结束时间</param>
        /// <param name="myFactoryOrganizationId">分厂级别组织机构</param>
        /// <param name="myComparableData">可比数据集合</param>
        /// <param name="mySqlServerDataFactory">数据库适配器</param>
        private static void GetCoefficientAltitude(string myStaticsCycle, string myStartTime, string myEndTime, List<string> myFactoryOrganizationId, ref Standard_GB16780_2012.Parameters_ComparableData myComparableData, mDbDataAdaper.mSqlServerDbDataAdaper mySqlServerDataFactory)
        {   //计算海拔高度
            string m_FactoryOrganizationId = "";
            if (myFactoryOrganizationId != null)
            {
                for (int i = 0; i < myFactoryOrganizationId.Count; i++)
                {
                    if (i == 0)
                    {
                        m_FactoryOrganizationId = "'" + myFactoryOrganizationId[i] + "'";
                    }
                    else
                    {
                        m_FactoryOrganizationId = m_FactoryOrganizationId + ",'" + myFactoryOrganizationId[i] + "'";
                    }
                }
            }
            string m_Sql = @"Select
                                (case when A.CoefficientAltitude is null then 0 else A.CoefficientAltitude end) as CoefficientAltitude, 
                                A.OrganizationID as OrganizationId,
                                D.VariableId as VariableId, 
                                D.Value as Value
                                from system_Organization A, 
					            (select B.OrganizationID as OrganizationID, C.VariableId as VariableId, sum(C.TotalPeakValleyFlatB) as Value
					                from tz_Balance B, balance_Energy C
						            where B.BalanceId = C.KeyID
						            and B.OrganizationID in ({0})
						            and B.StaticsCycle = '{1}'
						            and B.TimeStamp >= '{2}'
						            and B.TimeStamp <= '{3}'
						            and C.VariableId in ('clinker_clinkerOutput','cement_CementOutput')
						            group by B.OrganizationID, C.VariableId
					            ) D
					            where A.OrganizationID in ({0})
					            and A.OrganizationID = D.OrganizationID";
            try
            {
                m_Sql = string.Format(m_Sql, m_FactoryOrganizationId, myStaticsCycle, myStartTime, myEndTime);
                DataTable m_Result = mySqlServerDataFactory.Fill(null,m_Sql,"Table").Tables["Table"];
                if (m_Result != null)
                {
                    //////////////按熟料产量均摊海拔高度
                    DataRow[] m_clinkerOutput = m_Result.Select("'VariableId = 'clinker_clinkerOutput'");
                    myComparableData.Clinker_ActualAltitude = GetWeightedAverageValue(m_clinkerOutput, "CoefficientAltitude", "Value", myComparableData.Clinker_ActualAltitude);
                    //////////////按水泥产量均摊海拔高度
                    DataRow[] m_cementOutput = m_Result.Select("'VariableId = 'cement_cementOutput'");
                    myComparableData.Clinker_ActualAltitude = GetWeightedAverageValue(m_clinkerOutput, "CoefficientAltitude", "Value", myComparableData.Clinker_ActualAltitude);
                }

            }
            catch (Exception)
            {
            }
        }
    }
}
