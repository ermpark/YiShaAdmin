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
    public class ProductCartService : RepositoryFactory
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
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ProductCartEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ProductCartEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ProductCartListParam param)
        {
            //产品的id
            var p = await this.BaseRepository().FindEntity<ProductInfoEntity>(param.ProductId.Value);
            //根据产品id找到价格 赋值entity 参与计算 加入购物车列表，结算的时候调用打印并收款
            var entity = new ProductCartEntity();
            entity.ProductName = p.Name;
            entity.ProductId = p.Id;
            entity.SalePrice = p.SalePrice;
            entity.TotalPrice = p.SalePrice * param.Count;
            entity.Fac = p.Fac;
            entity.Spec = p.Spec;
            entity.Count = param.Count;
            //如果有重复的，累加，否则就新增
            var dao = await this.BaseRepository().FindEntity<ProductCartEntity>(l => l.ProductId == param.ProductId.Value);
            if (dao != null)
            {
                dao.Count = dao.Count + param.Count;
                dao.TotalPrice = p.SalePrice * dao.Count;
                await this.BaseRepository().Update(dao);
            }
            else
            {
                entity.Create();
                await this.BaseRepository().Insert(entity);
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
