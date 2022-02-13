using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.SystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-02-12 12:43
    /// 描 述：购物车实体类
    /// </summary>
    [Table("ProductCart")]
    public class ProductCartEntity : BaseEntity
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        /// <returns></returns>
        public long? ProductId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        public int? Count { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        /// <returns></returns>
        public decimal? SalePrice { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        /// <returns></returns>
        public decimal? TotalPrice { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        /// <returns></returns>
        public string TradeNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        /// <returns></returns>
        public string ProductName { get; set; }
        public string Spec { get; set; }
        public string Fac { get; set; }
    }
}
