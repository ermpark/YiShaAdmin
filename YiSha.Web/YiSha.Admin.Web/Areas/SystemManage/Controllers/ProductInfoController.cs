using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.SystemManage;
using YiSha.Business.SystemManage;
using YiSha.Model.Param.SystemManage;

namespace YiSha.Admin.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-02-11 18:44
    /// 描 述：产品明细表控制器类
    /// </summary>
    [Area("SystemManage")]
    public class ProductInfoController :  BaseController
    {
        private ProductInfoBLL productInfoBLL = new ProductInfoBLL();

        #region 视图功能
        [AuthorizeFilter("system:productinfo:view")]
        public ActionResult ProductInfoIndex()
        {
            return View();
        }

        public ActionResult ProductInfoForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("system:productinfo:search")]
        public async Task<ActionResult> GetListJson(ProductInfoListParam param)
        {
            TData<List<ProductInfoEntity>> obj = await productInfoBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("system:productinfo:search")]
        public async Task<ActionResult> GetPageListJson(ProductInfoListParam param, Pagination pagination)
        {
            TData<List<ProductInfoEntity>> obj = await productInfoBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ProductInfoEntity> obj = await productInfoBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("system:productinfo:add,system:productinfo:edit")]
        public async Task<ActionResult> SaveFormJson(ProductInfoEntity entity)
        {
            TData<string> obj = await productInfoBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:productinfo:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await productInfoBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
