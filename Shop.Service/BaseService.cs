using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shop.IService;
using Shop.IRepository;//应用IDAL
namespace Shop.Service
{
    //BLL层，不能直接实例化DAL，应该依赖于IDAL
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        //声明一个IDAL的对象
        private IBaseRepository<TEntity> _ibaseRepository;//_ibaseRepository就相当于dal中的对象
        //写构造函数传参数
        public BaseService(IBaseRepository<TEntity> ibaseRepositroy)
        {
            this._ibaseRepository = ibaseRepositroy;
        }
        public bool Add(TEntity entity)
        {
            _ibaseRepository.Insert(entity);
            return _ibaseRepository.SaveChanges();
        }

        public object Exucutesqlcommand(string sql, params object[] para)
        {
            return _ibaseRepository.Exucutesqlcommand(sql, para);
        }

        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return _ibaseRepository.SelectEntities(whereLambda);
        }

        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
           return _ibaseRepository.SelectEntity(whereLambda);

        }

        public IEnumerable<TEntity> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, type>> OrderByLambda, Expression<Func<TEntity, bool>> WhereLambda)
        {
            return _ibaseRepository.SelectEntitiesByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }

        public bool Modify(TEntity entity)
        {
            _ibaseRepository.Update(entity);
            return _ibaseRepository.SaveChanges();
        }

        public bool Remove(TEntity entity)
        {
            _ibaseRepository.Delete(entity);
            return _ibaseRepository.SaveChanges();
        }

        
    }
}
