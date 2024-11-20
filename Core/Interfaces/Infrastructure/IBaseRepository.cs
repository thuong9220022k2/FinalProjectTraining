using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Infrastructure
{
    internal interface IBaseRepository<Entity> where Entity : class
    {
        public Task<IEnumerable<Entity>> GetAllEntities();
        public Task<Entity> GetEntityById(int id);
        public Task<Entity> AddEntity(Entity entity);
        public Task<Entity> UpdateEntity(Entity entity);
        public Task<Entity> DeleteEntity(int id);

    }
}
