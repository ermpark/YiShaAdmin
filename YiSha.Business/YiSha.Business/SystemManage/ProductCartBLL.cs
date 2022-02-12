using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.SystemManage;
using YiSha.Model.Param.SystemManage;
using YiSha.Service.SystemManage;

namespace YiSha.Business.SystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-02-12 12:43
    /// 描 述：购物车业务类
    /// </summary>
    public class ProductCartBLL
    {
        private ProductCartService productCartService = new ProductCartService();

        #region 获取数据
        public async Task<TData<List<ProductCartEntity>>> GetList(ProductCartListParam param)
        {
            TData<List<ProductCartEntity>> obj = new TData<List<ProductCartEntity>>();
            obj.Data = await productCartService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ProductCartEntity>>> GetPageList(ProductCartListParam param, Pagination pagination)
        {
            TData<List<ProductCartEntity>> obj = new TData<List<ProductCartEntity>>();
            obj.Data = await productCartService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ProductCartEntity>> GetEntity(long id)
        {
            TData<ProductCartEntity> obj = new TData<ProductCartEntity>();
            obj.Data = await productCartService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ProductCartEntity entity)
        {
            TData<string> obj = new TData<string>();
            await productCartService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await productCartService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
