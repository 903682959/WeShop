using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IService
{
    public interface IBaseService<TEntity> where TEntity:class,new()
    {
        bool Add(TEntity entity);
        bool Remove(TEntity entity);
        bool Modify(TEntity entity);
       
       
        //查询单个
        TEntity GetEntity(Func<TEntity, bool> whereLambda);
        //查询多个
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda);
        //查询分页
        IEnumerable<TEntity> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
           Expression<Func<TEntity, type>> OrderByLambda, Expression<Func<TEntity, bool>> WhereLambda);
    }
}
