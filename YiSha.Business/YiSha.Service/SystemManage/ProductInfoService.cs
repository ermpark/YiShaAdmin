using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.SystemManage;
using YiSha.Model.Param.SystemManage;

namespace YiSha.Service.SystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-02-11 18:44
    /// 描 述：产品明细表服务类
    /// </summary>
    public class ProductInfoService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ProductInfoEntity>> GetList(ProductInfoListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ProductInfoEntity>> GetPageList(ProductInfoListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ProductInfoEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ProductInfoEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ProductInfoEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<ProductInfoEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ProductInfoEntity, bool>> ListFilter(ProductInfoListParam param)
        {
            var expression = LinqExtensions.True<ProductInfoEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
