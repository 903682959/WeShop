using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shop.IRepository;//引用接口层
//using Shop.Model;

using System.Data.Entity;
using Shop.Model;

namespace Shop.Repository
{
    //Dal层要实现IDAL 实现接口
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        //1:上下文对象  new 用工厂模式来代替
        private readonly WeShop dbcontext = DbContextFactory.CreateDbContext();
        //2；设置实体集DbSet
        public DbSet<TEntity> dbSet;
        public BaseRepository()
        {
            dbSet = dbcontext.Set<TEntity>();//构造一个实体集
        }
        public void Delete(TEntity entit)
        {
            //1:删除指定的实体，先从集合中查找到该实体，然后再删除
            dbSet.Attach(entit);
            dbSet.Remove(entit);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<TEntity> SelectEntities(Func<TEntity, bool> wherelambda)
        {
            return dbSet.Where(wherelambda);
        }

        public IEnumerable<TEntity> SelectEntitiesByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, type>> OrderByLambda, Expression<Func<TEntity, bool>> WhereLambda)
        {
            var result = dbSet.Where(WhereLambda);
            result = isAsc ? result.OrderBy(OrderByLambda) : result.OrderByDescending(OrderByLambda);
            result = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return result.ToList();
        }

        public TEntity SelectEntity(Func<TEntity, bool> wherelambda)
        {
            return dbSet.FirstOrDefault(wherelambda);
        }

        public void Update(TEntity entit)
        {
            //更新：先查找到要更新的实体，然后在覆盖原有的
            dbSet.Attach(entit);
            //需要修改状态
            dbcontext.Entry(entit).State = EntityState.Modified;
        }

        public bool SaveChanges()
        {
           return dbcontext.SaveChanges() > 0;
        }

        public object Exucutesqlcommand(string sql, params object[] para)
        {
            return dbcontext.Database.ExecuteSqlCommand(sql,para);
        }
    }
}
