using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces.Service
{
    internal interface IBaseService<Entity> where Entity : class
    {
        public ServiceResult GetAllEntities();
        public ServiceResult GetEntityById(int id);
        public ServiceResult AddEntity(Entity entity);
        public ServiceResult UpdateEntity(Entity entity);
        public ServiceResult DeleteEntity(int id);
    }
}
