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
        //public ServiceResult GetEntityById(int id);
        //public ServiceResult AddEntity(Entity entity);
        //public ServiceResult UpdateEntity(Entity entity);
        //public ServiceResult DeleteEntity(int id);
    }
}
