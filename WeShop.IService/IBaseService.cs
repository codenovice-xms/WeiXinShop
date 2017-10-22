using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeShop.IService
{
    public interface IBaseService<TEntity> where TEntity:class ,new()
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="tEntity">实体模型</param>
        /// <returns></returns>
        bool Add(TEntity tEntity);
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="tEntity">实体模型</param>
        /// <returns></returns>
        bool Remove(TEntity tEntity);
        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="tEntity">实体模型</param>
        /// <returns></returns>
        bool Modify(TEntity tEntity);

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        int GetCount(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        TEntity GetEntity(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 获取多个数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns>实体</returns>
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TType">实体类型</typeparam>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="isAsc">是否倒序</param>
        /// <param name="whereLambda">Lambda表达式</param>
        /// <param name="orderByLambda"></param>
        /// <returns>可遍历的实体</returns>
        IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda);
    }
}
