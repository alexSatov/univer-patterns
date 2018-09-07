using System.Collections.Generic;
using Example_04.Homework.Models.Interfaces;

namespace Example_04.Homework.FirstOrmLibrary
{
    public class FirstOrm : IFirstOrm<IDbEntity>
    {
        public readonly List<IDbEntity> Entities = new List<IDbEntity>();

        public void Create(IDbEntity entity)
        {
            Entities.Add(entity);
        }

        public IDbEntity Read(int id)
        {
            return Entities.Find(u => u.Id == id);
        }

        public void Update(IDbEntity entity)
        {
            var oldEntity = Read(entity.Id);
            Entities[Entities.IndexOf(oldEntity)] = entity;
        }

        public void Delete(IDbEntity entity)
        {
            Entities.Remove(entity);
        }
    }
}
