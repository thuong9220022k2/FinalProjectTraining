using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
namespace Core.Interfaces.Infrastructure
{
    public interface IAdmTimeSheetRepo
    {
        public Task<IEnumerable<AdmTimeSheetModel>> GetAllEntitiesByFilter(FilterResult filter);
        //public Task<Entity> GetEntityById(int id);
        //public Task<Entity> AddEntity(AdmSystemParameter entity);
        //public Task<Entity> UpdateEntity(AdmSystemParameter entity);
        //public Task<Entity> DeleteEntity(int id);

    }
}
