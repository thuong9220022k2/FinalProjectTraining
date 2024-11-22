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
        public Task<AdmTimeSheetModel> GetEntityById(int id);
        public Task<bool> AddEntity(AdmTimeSheetModel entity);
        public Task<bool> UpdateEntity(AdmTimeSheetModel entity);
        public Task<bool> DeleteEntity(int id);

    }
}
