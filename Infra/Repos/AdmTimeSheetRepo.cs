using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Infrastructure;
using Core.Models;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using System.Xml.Linq;
namespace Infra.Repos
{
    public class AdmTimeSheetRepo : IAdmTimeSheetRepo
    {
        #region fields
        private string connection_string = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.207)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=sm_training)));User Id=trainingteam;Password=12345;";

        #endregion
        public Task<IEnumerable<AdmTimeSheetModel>> GetAllEntitiesByFilter(FilterResult filter)
        {
            using (var conn = new OracleConnection(connection_string))
            {             
                var queryParams = filter.GetType().GetProperties();
                string conditionAggregate = null;
                string offsetConditionQuery = null;
                string limitConditionQuery = null;
                foreach (var queryParam in queryParams)
                {
                    if (queryParam.GetValue(filter) != null && queryParam.Name != "offset" && queryParam.Name != "limit")
                    {
                        var conditionQueries = new List<string>();
                        var conditionQuery = $"ads.{queryParam.Name} = {queryParam.GetValue(filter)}";
                        conditionQueries.Add(conditionQuery);
                        foreach (var condition in conditionQueries)
                        {
                            // plus AND for each condition except the first one and last one and return a string 
                            conditionAggregate = conditionQueries.Aggregate((a, b) => a + " AND " + b);
                        }
                    }
                    if (queryParam.Name == "offset")
                    {
                        offsetConditionQuery = $"OFFSET {queryParam.GetValue(filter)} ROWS";
                    }
                    if (queryParam.Name == "limit")
                    {
                        limitConditionQuery = $"FETCH NEXT {queryParam.GetValue(filter)} ROWS ONLY";
                    }

                }

                if (conditionAggregate != null)
                {
                    var conditionSql = $"SELECT * FROM adm_time_sheet ads WHERE {conditionAggregate} ORDER BY ads.time_sheet_id {offsetConditionQuery} {limitConditionQuery}";
                    var conditionResult = conn.QueryAsync<AdmTimeSheetModel>(conditionSql);
                    return conditionResult;
                }
                else
                {
                    var noConditionSql = $"SELECT * FROM adm_time_sheet ads ORDER BY ads.time_sheet_id {offsetConditionQuery} {limitConditionQuery}";
                    var noConditionResult = conn.QueryAsync<AdmTimeSheetModel>(noConditionSql);
                    return noConditionResult;
                }
            }
        }
    }
}