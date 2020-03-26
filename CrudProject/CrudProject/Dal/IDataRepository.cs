using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProject.Dal
{
   public interface IDataRepositoy<TEntity, T>
    {

        List<TEntity> GetAll();


        TEntity GetById(T id);


        void Add(TEntity user);


        void Update(TEntity user);


        void Delete(T id);
    }
}
