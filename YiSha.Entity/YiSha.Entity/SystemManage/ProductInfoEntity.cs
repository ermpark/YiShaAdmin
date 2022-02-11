using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.SystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-02-11 18:44
    /// 描 述：产品明细表实体类
    /// </summary>
    [Table("ProductInfo")]
    public class ProductInfoEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Spec { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Fac { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? SalePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? CostPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CreateTime { get; set; }
    }
}
