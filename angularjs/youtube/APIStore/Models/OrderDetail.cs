using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIStore.Models
{
    /// <summary>
    /// 订单明细实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class OrderDetail
    {
        /// <summary>
        /// 所属订单号
        /// </summary>
        [DataMember]
        public string OrderNo { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        [DataMember]
        public double Price { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        [DataMember]
        public int Number { get; set; }
    }
}