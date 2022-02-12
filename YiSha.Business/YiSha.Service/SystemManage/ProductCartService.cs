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
    /// 日 期：2022-02-12 12:43
    /// 描 述：购物车服务类
    /// </summary>
    public class ProductCartService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ProductCartEntity>> GetList(ProductCartListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ProductCartEntity>> GetPageList(ProductCartListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ProductCartEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ProductCartEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ProductCartEntity entity)
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
            await this.BaseRepository().Delete<ProductCartEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ProductCartEntity, bool>> ListFilter(ProductCartListParam param)
        {
            var expression = LinqExtensions.True<ProductCartEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
