using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IRepository
{
   public interface IBaseRepository<TEntity> where TEntity:class,new()
    {
        //接口中定义方法：
        ////泛型类的五大约束
        // 1. where T：struct  限定当前参数类型必须是值类型
        // 2. where T：class   限定当前类型参数类型必须是引用类型
        // 3. where T：new（） 限定当前参数类型必须有一个无参构造器
        // 4. where T：<base class name>   限定当前参数类型 必须是当前类  或者当前类为基类的类
        //父类名
        // 5. where T：<interface name>限定当前参数类型必须实现指定接口
        void Insert(TEntity entity);
        void Delete(TEntity entit);
        void Update(TEntity entit);
        bool SaveChanges();
        //单个查询
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wherelambda">表示输入一个lambda表达式即可</param>
        TEntity SelectEntity(Func<TEntity,bool> wherelambda);
        //查询集合,如果查询带有条件的集合，也要加where，
        IEnumerable<TEntity> SelectEntities(Func<TEntity, bool> wherelambda);
        //带有分页查询的集合，pagesize,pageIndex 
        //Expression<Func<TEntity, type>> OrderByLambda和Func<TEntity, bool> wherelambda
        //Expression 表达式树  优化查询性能
        IEnumerable<TEntity> SelectEntitiesByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, type>> OrderByLambda, Expression<Func<TEntity, bool>> WhereLambda);
    }
   
   
}
