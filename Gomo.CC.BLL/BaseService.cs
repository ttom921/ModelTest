using Gomo.CC.IBLL;
using Gomo.CC.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Gomo.CC.BLL
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        public IBaseDal<T> CurrentDal { get; set; }
        public BaseService(IBaseDal<T> baseDal)
        {
            CurrentDal = baseDal;
        }

        #region 查詢
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {

            return CurrentDal.GetEntities(whereLambda);
        }
        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
                                                 Expression<Func<T, bool>> whereLambda,
                                                 Expression<Func<T, S>> orderByLamba,
                                                 bool isAsc
                                                 )
        {
            return CurrentDal.GetPageEntities(pageSize, pageIndex, out total, whereLambda, orderByLamba, isAsc);
        }
        #endregion
        #region cud

        #endregion
        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            CurrentDal.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return CurrentDal.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return CurrentDal.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            CurrentDal.Delete(id);
            return CurrentDal.SaveChanges() > 0;
        }
        //批量刪除
        public int DeleteList(List<int> ids)
        {
            foreach (var id in ids)
            {
                CurrentDal.Delete(id);
            }
            return CurrentDal.SaveChanges();
        }
    }
}
