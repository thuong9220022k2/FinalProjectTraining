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
using Microsoft.VisualBasic;
namespace Infra.Repos
{
    public class AdmTimeSheetRepo : IAdmTimeSheetRepo
    {
        #region fields
        private string connection_string = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.207)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=sm_training)));User Id=trainingteam;Password=12345;";

        #endregion
        public Task<IEnumerable<AdmTimeSheetModel>> GetAllEntitiesByFilter(FilterResult filter)
        {
            var queryParams = filter.GetType().GetProperties();
            var conditionQueries = new List<string>();
            string limitConditionQuery = null;
            var parameters = new DynamicParameters();
            foreach (var queryParam in queryParams)
            {
                var value = queryParam.GetValue(filter);
                if (value != null)
                {
                    if (queryParam.Name != "limit")
                    {
                        conditionQueries.Add($"ads.{queryParam.Name} = :{queryParam.Name}");
                        parameters.Add($":{queryParam.Name}", value);
                    }
                    limitConditionQuery = $"FETCH NEXT :{queryParam.Name} ROWS ONLY";
                    parameters.Add($":{queryParam.Name}", value);
                }
                limitConditionQuery = $"FETCH NEXT 5 ROWS ONLY";
            }
            string conditionFilter = conditionQueries.Any() ? string.Join(" AND ", conditionQueries) : null;
            string conditionSql = conditionFilter != null ?
                $"SELECT * FROM adm_time_sheet ads WHERE {conditionFilter} ORDER BY ads.time_sheet_id OFFSET 0 ROWS {limitConditionQuery}" :
                $"SELECT * FROM adm_time_sheet ads ORDER BY ads.time_sheet_id OFFSET 0 ROWS {limitConditionQuery}";

            using (var conn = new OracleConnection(connection_string))
            {
                var result = conn.QueryAsync<AdmTimeSheetModel>(conditionSql, parameters);
                return result;
            }
        }

        public async Task<AdmTimeSheetModel> GetEntityById(int id)
        {
            var sql = "SELECT * FROM adm_time_sheet ads WHERE ads.time_sheet_id = :time_sheet_id";
            var parameters = new DynamicParameters();
            parameters.Add(":time_sheet_id", id);
            using (var conn = new OracleConnection(connection_string))
            {
                var result = await conn.QueryFirstOrDefaultAsync<AdmTimeSheetModel>(sql, parameters);
                return result;
            }
        }
        public async Task<bool> AddEntity(AdmTimeSheetModel entity)
        {
            var insertQuery = @"INSERT INTO adm_time_sheet ( project_id, module, code, name,total_duration,actual_start_date,actual_percent_complete,issue,current_state,deleted,version) 
                      VALUES (:project_id, :module, :code, :name, :total_duration,:actual_start_date,:actual_percent_complete,:issue,:current_state,:deleted, :version)";
            var parameters = new DynamicParameters();
            parameters.Add(":project_id", entity?.project_id);
            parameters.Add(":module", entity?.module);
            parameters.Add(":code", entity?.code);
            parameters.Add(":name", entity?.name);
            parameters.Add(":total_duration", entity?.total_duration);
            parameters.Add(":actual_start_date", entity?.actual_start_date);
            parameters.Add(":actual_percent_complete", entity?.actual_percent_complete);
            parameters.Add(":issue", entity?.issue);
            parameters.Add(":current_state", entity?.current_state);
            parameters.Add(":deleted", entity?.deleted);
            parameters.Add(":version", entity?.version);
            using (var conn = new OracleConnection(connection_string))
            {
                var result = await conn.ExecuteAsync(insertQuery, parameters);
                return result > 0;
            }
        }
        public async Task<bool> UpdateEntity(AdmTimeSheetModel entity)
        {
            //var updateQuery = @"UPDATE adm_time_sheet SET "
            var updateQuery = @"UPDATE adm_time_sheet SET 
                                                 project_id = :project_id, 
                                                 module = :module, 
                                                 code = :code, 
                                                 name = :name, 
                                                 total_duration = :total_duration, 
                                                 actual_start_date = :actual_start_date, 
                                                 actual_percent_complete = :actual_percent_complete, 
                                                 issue = :issue,
                                                 current_state = :current_state, 
                                                 deleted = :deleted, 
                                                 version = :version 
                              WHERE time_sheet_id = :time_sheet_id";
            var parameters = new DynamicParameters();
            parameters.Add(":time_sheet_id", entity.time_sheet_id);
            parameters.Add(":project_id", entity.project_id);
            parameters.Add(":module", entity.module);
            parameters.Add(":code", entity.code);
            parameters.Add(":name", entity.name);
            parameters.Add(":total_duration", entity.total_duration);
            parameters.Add(":actual_start_date", entity.actual_start_date);
            parameters.Add(":actual_percent_complete", entity.actual_percent_complete);
            parameters.Add(":issue", entity.issue);
            parameters.Add(":current_state", entity.current_state);
            parameters.Add(":deleted", entity.deleted);
            parameters.Add(":version", entity.version);

            using(var con = new OracleConnection(connection_string))
            {
                var result = await con.ExecuteAsync(updateQuery, parameters);
                return result > 0;
            }
        }

        public async Task<bool> DeleteEntity(int id)
        {
            var deleteQuery = @" DELETE FROM adm_time_sheet WHERE time_sheet_id = :TimeSheetId";
            var parameters = new DynamicParameters();
            parameters.Add(":TimeSheetId", id);

            using (var con = new OracleConnection(connection_string))
            {
                var result = await con.ExecuteAsync(deleteQuery, parameters);
                return result > 0;
            }
        }
    }

}