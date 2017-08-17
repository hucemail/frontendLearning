using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace APIStore.Models
{
    /// <summary>
    /// 订单实体对象
    /// </summary>
    [Serializable]
    [DataContract]
    public class Order
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [DataMember]
        public string OrderNo { get; set; }
        /// <summary>
        /// 订单创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        [DataMember]
        public double Amount { get; set; }
        /// <summary>
        /// 订单明细
        /// </summary>
        [DataMember]
        public List<OrderDetail> Details { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [DataMember]
        public OrderStatus Status { get; set; }

    }
}