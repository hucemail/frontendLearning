using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIStore.Models
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 未支付
        /// </summary>
        UnPaid,
        /// <summary>
        /// 已取消
        /// </summary>
        Cancel,
        /// <summary>
        /// 已支付未发货
        /// </summary>
        UnShipping,
        /// <summary>
        /// 已发货未收货
        /// </summary>
        UnReceipt,
        /// <summary>
        /// 已收货
        /// </summary>
        Receipt,
        /// <summary>
        /// 退款中
        /// </summary>
        RefundPeriod,
        /// <summary>
        /// 退款完成
        /// </summary>
        RefundComplete
    }
}