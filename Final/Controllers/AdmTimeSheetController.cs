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
        [HttpGet]
        public async Task<IActionResult> GetAllEntitiesByFilter(
            [FromQuery(Name = "projectId")] string projectId,
            [FromQuery(Name = "createdDate")] string createdDate,
            [FromQuery(Name = "actualStartDate")] string actualStartDate,
            [FromQuery(Name = "status")] string status,
            [FromQuery(Name = "name")] string name,
            [FromQuery(Name = "actualPercentComplete")] string actualPercentComplete,
            [FromQuery(Name = "limit")] string limit
        )
        {
            try {
                var filterResult = new FilterResult(projectId, createdDate, actualStartDate, status, actualPercentComplete, name,limit);
                var result = await admTimeSheetService.GetAllEntitiesByFilter(filterResult);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityById(int id)
        {
            try
            {
                var result = await admTimeSheetService.GetEntityById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEntity(AdmTimeSheetModel entity)
        {
            try { 
                var result = await admTimeSheetService.AddEntity(entity);
                return Ok(result);
            
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEnity(AdmTimeSheetModel entity)
        {
            try {
                var result = await admTimeSheetService.UpdateEntity(entity);
                return Ok(result);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            try
            {
                var result = await admTimeSheetService.DeleteEntity(id);
                return Ok(result);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion

    }
}
