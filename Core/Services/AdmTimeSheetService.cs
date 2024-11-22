using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Service;
using Core.Interfaces.Infrastructure;
using Core.Models;
namespace Core.Services
{
    public class AdmTimeSheetService : IAdmTimeSheetService
    {
        #region fields
        public IAdmTimeSheetRepo admTimeSheetRepo;
        public ServiceResult serviceResult;
        #endregion

        #region constructor
        public AdmTimeSheetService(IAdmTimeSheetRepo admTimeSheetRepo)
        {
            this.admTimeSheetRepo = admTimeSheetRepo;
            serviceResult = new ServiceResult();
        }
        #endregion

        #region methods
        public async Task<ServiceResult> GetAllEntitiesByFilter(FilterResult filter)
        {
            try
            {
                var result = await admTimeSheetRepo.GetAllEntitiesByFilter(filter);
                if (result != null)
                {
                    serviceResult.success = true;
                    serviceResult.message = "Success";
                    serviceResult.data = result;
                }
                else
                {
                    serviceResult.success = false;
                    serviceResult.message = "No data found";
                    serviceResult.data = null;
                }
            }
            catch (Exception ex)
            {
                serviceResult.success = false;
                serviceResult.message = ex.Message;
                serviceResult.data = null;
            }
            return serviceResult;
        }

        public async Task<ServiceResult> GetEntityById(int id)
        {
            try
            {
                var result = await admTimeSheetRepo.GetEntityById(id);
                if (result != null)
                {
                    serviceResult.success = true;
                    serviceResult.message = "Success";
                    serviceResult.data = result;
                }
                else
                {
                    serviceResult.success = false;
                    serviceResult.message = "No data found";
                    serviceResult.data = null;
                }

            }
            catch (Exception ex)
            {
                serviceResult.success = false;
                serviceResult.message = ex.Message;
                serviceResult.data = null;
            }
            return serviceResult;
        }
        public async Task<ServiceResult> AddEntity(AdmTimeSheetModel entity)
        {
            try
            {
                bool result = await admTimeSheetRepo.AddEntity(entity);
                if (result)
                {
                    serviceResult.success = true;
                    serviceResult.message = "Insert Success";
                }
                else
                {
                    serviceResult.success = false;
                    serviceResult.message = "Insert Fail";
                }

            }
            catch (Exception ex)
            {
                serviceResult.success = false;
                serviceResult.message = ex.Message;
            }
            return serviceResult;
        }
        public async Task<ServiceResult> UpdateEntity(AdmTimeSheetModel entity)
        {
            try {
                var result = await admTimeSheetRepo.UpdateEntity(entity);
                if (result)
                {
                    serviceResult.success = true;
                    serviceResult.message = "Update Success";
                }
                else
                {
                    serviceResult.success = false;
                    serviceResult.message = "Update Fail";
                }
            }catch(Exception ex)
            {
                serviceResult.success = false;
                serviceResult.message = ex.Message;
            }
            return serviceResult;
        }

        public async Task<ServiceResult> DeleteEntity(int id)
        {
            try {
                var result = await admTimeSheetRepo.DeleteEntity(id);
                if (result)
                {
                    serviceResult.success=true;
                    serviceResult.message = "Delete Success";
                }
                else
                {
                    serviceResult.success=false;
                    serviceResult.message = "Delete Fail";
                }
            
            }catch(Exception ex)
            {
                serviceResult.success = false;
                serviceResult.message = ex.Message;
            }
            return serviceResult;
        }
        #endregion
    }
}