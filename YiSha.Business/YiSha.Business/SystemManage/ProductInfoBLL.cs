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
    /// 日 期：2022-02-11 18:44
    /// 描 述：产品明细表业务类
    /// </summary>
    public class ProductInfoBLL
    {
        private ProductInfoService productInfoService = new ProductInfoService();

        #region 获取数据
        public async Task<TData<List<ProductInfoEntity>>> GetList(ProductInfoListParam param)
        {
            TData<List<ProductInfoEntity>> obj = new TData<List<ProductInfoEntity>>();
            obj.Data = await productInfoService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ProductInfoEntity>>> GetPageList(ProductInfoListParam param, Pagination pagination)
        {
            TData<List<ProductInfoEntity>> obj = new TData<List<ProductInfoEntity>>();
            obj.Data = await productInfoService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ProductInfoEntity>> GetEntity(long id)
        {
            TData<ProductInfoEntity> obj = new TData<ProductInfoEntity>();
            obj.Data = await productInfoService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ProductInfoEntity entity)
        {
            TData<string> obj = new TData<string>();
            await productInfoService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await productInfoService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
