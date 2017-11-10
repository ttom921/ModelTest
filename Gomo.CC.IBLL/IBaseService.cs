using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Gomo.CC.IBLL
{
    public interface IBaseService<T> 
    {
        #region 查詢
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        //IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
        //                                         Expression<Func<T, bool>> whereLambda,
        //                                         Expression<Func<T, S>> orderByLamba,
        //                                         bool isAsc
        //                                         );

        #endregion

        #region cud
        T Add(T entity);

        bool Update(T entity);


        bool Delete(T entity);

        bool Delete(int id);

        //批量刪除
        //int DeleteList(List<int> ids);
        ////邏輯刪除
        //int DeleteListByLogical(List<int> ids);
        ////邏輯未刪除
        //int UnDeleteListByLogical(List<int> ids);

        #endregion
    }
}
