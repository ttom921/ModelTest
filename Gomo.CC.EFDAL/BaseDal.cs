using Gomo.CC.IDAL;
using Gomo.CC.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Gomo.CC.EFDal
{
    /// <summary>
    /// 職責:封裝所有的Dal的公共的crud的方法
    /// 類的責任要單一
    /// </summary>
    public class BaseDal<T> : IBaseDal<T> where T : class
    {
        protected readonly DbContext dbContext;
        protected DbSet<T> DbSet;

        public BaseDal(BloggingContext context)
        {
            dbContext = context;
            DbSet = dbContext.Set<T>();
        }
        #region 查詢
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {

            return DbSet.Where(whereLambda).AsQueryable();
        }
        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
                                                 Expression<Func<T, bool>> whereLambda,
                                                 Expression<Func<T, S>> orderByLamba,
                                                 bool isAsc
                                                 )
        {
            total = DbSet.Where(whereLambda).Count();
            if (isAsc)
            {
                var temp = DbSet.Where(whereLambda)
                      .OrderBy<T, S>(orderByLamba)
                      .Skip(pageSize * (pageIndex - 1))
                      .Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = DbSet.Where(whereLambda)
                      .OrderByDescending<T, S>(orderByLamba)
                      .Skip(pageSize * (pageIndex - 1))
                      .Take(pageSize).AsQueryable();
                return temp;
            }

        }
        #endregion
        #region cud
        public T Add(T entity)
        {
            DbSet.Add(entity);

            //Db.SaveChanges();
            this.SaveChanges();
            return entity;
        }
        public bool Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return this.SaveChanges()>0;
        }
        public bool Delete(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            return this.SaveChanges()>0;
        }
        public bool Delete(int id)
        {
            var entity = DbSet.Find(id);
            dbContext.Set<T>().Remove(entity);
            if (entity == null) return false;
            return true;
        }
        //邏輯刪除
        //public int DeleteListByLogical(List<int> ids)
        //{
        //    try
        //    {
        //        foreach (var id in ids)
        //        {
        //            var entity = DbSet.Find(id);
        //            Db.Entry(entity).Property("DelFlag").CurrentValue = (int)Model.Enum.DelFlagEnum.Deleted;
        //            Db.Entry(entity).Property("DelFlag").IsModified = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog("DeleteListByLogical 無DelFlag的屬性在資料庫中 ex=" + ex.Message);
        //        return 0;

        //    }

        //    return ids.Count;
        //}
        //邏輯未刪除
        //public int UnDeleteListByLogical(List<int> ids)
        //{
        //    try
        //    {
        //        foreach (var id in ids)
        //        {
        //            var entity = Db.Set<T>().Find(id);
        //            Db.Entry(entity).Property("DelFlag").CurrentValue = (int)Model.Enum.DelFlagEnum.Normal;
        //            Db.Entry(entity).Property("DelFlag").IsModified = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog("DeleteListByLogical 無DelFlag的屬性在資料庫中 ex=" + ex.Message);
        //        return 0;

        //    }

        //    return ids.Count;
        //}
        #endregion
        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

    }
}
