using System;
using Core.Interfaces.Service;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Models;
namespace Final.Controllers
{
    [Route("api/v1/adm-time-sheet")]
    [ApiController]
    public class AdmTimeSheetController :ControllerBase
    {
        #region fields;
        public IAdmTimeSheetService admTimeSheetService;
        #endregion

        #region constructor
        public AdmTimeSheetController(IAdmTimeSheetService admTimeSheetService)
        {
            this.admTimeSheetService = admTimeSheetService;
        }
        #endregion

        #region methods
        [HttpGet("filter")]
        public async Task<IActionResult> GetAllEntitiesByFilter(
            [FromQuery(Name = "projectId")] string projectId,
            [FromQuery(Name = "createdDate")] string createdDate,
            [FromQuery(Name = "actualStartDate")] string actualStartDate,
            [FromQuery(Name = "status")] string status,
            [FromQuery(Name = "name")] string name,
            [FromQuery(Name = "actualPercentComplete")] string actualPercentComplete,
            [FromQuery(Name = "offset")] string offset,
            [FromQuery(Name = "limit")] string limit
        )
        {
            try {
                var filterResult = new FilterResult(projectId, createdDate, actualStartDate, status, name, actualPercentComplete,offset,limit);
                var result = await admTimeSheetService.GetAllEntitiesByFilter(filterResult);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion



    }
}
