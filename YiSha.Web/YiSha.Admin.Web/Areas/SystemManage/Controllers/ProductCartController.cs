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
    /// 日 期：2022-02-12 12:43
    /// 描 述：购物车控制器类
    /// </summary>
    [Area("SystemManage")]
    public class ProductCartController :  BaseController
    {
        private ProductCartBLL productCartBLL = new ProductCartBLL();

        #region 视图功能
        [AuthorizeFilter("system:productcart:view")]
        public ActionResult ProductCartIndex()
        {
            return View();
        }

        public ActionResult ProductCartForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("system:productcart:search")]
        public async Task<ActionResult> GetListJson(ProductCartListParam param)
        {
            TData<List<ProductCartEntity>> obj = await productCartBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("system:productcart:search")]
        public async Task<ActionResult> GetPageListJson(ProductCartListParam param, Pagination pagination)
        {
            TData<List<ProductCartEntity>> obj = await productCartBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ProductCartEntity> obj = await productCartBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("system:productcart:add,system:productcart:edit")]
        public async Task<ActionResult> SaveFormJson(ProductCartListParam entity)
        {
            TData<string> obj = await productCartBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:productcart:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await productCartBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
