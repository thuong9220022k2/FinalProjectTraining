using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces.Service
{
    public interface IAdmTimeSheetService
    {
        public Task<ServiceResult> GetAllEntitiesByFilter(FilterResult filter);
        public Task<ServiceResult> GetEntityById(int id);
        public Task<ServiceResult> AddEntity(AdmTimeSheetModel entity);
        public Task<ServiceResult> UpdateEntity(AdmTimeSheetModel entity);
        public Task<ServiceResult> DeleteEntity(int id);
    }
}
