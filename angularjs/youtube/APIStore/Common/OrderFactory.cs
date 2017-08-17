using APIStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIStore.Common
{
    public class OrderFactory
    {
        private static List<Order> orders;
        static OrderFactory()
        {
            string[] goodsname = { "AngularJS实战", "CLR via C#", "深入理解C#", "Java编程思想", "JavaScript编程宝典" };
            Random rd = new Random();
            orders = new List<Order>();
            for (int i = 0; i < 100; i++)
            {
                Order order = new Order();
                order.CreateTime = DateTime.Now.AddDays(-(rd.Next(0, 100)));
                order.Status = OrderStatus.UnPaid;
                order.Details = new List<OrderDetail>();
                //随意生成的订单号，实际情况中考虑到高并发，服务器数据库等集群操作，需要使用radis或 MongoDB的ObjectId 来生成保证全局唯一性
                //http://www.cnblogs.com/haoxinyue/p/5208136.html
                order.OrderNo = DateTime.Now.AddHours(i).ToString("mmssyyyyddHHMM");
                for (int j = 0; j < rd.Next(1, 5); j++)
                {
                    int price = rd.Next(1, 100);
                    int number = rd.Next(1, 10);
                    order.Amount += (price * number);
                    order.Details.Add(new OrderDetail()
                    {
                        Number = number,
                        Price = price,
                        GoodsName = goodsname[rd.Next(0, 5)],
                        OrderNo = order.OrderNo
                    });
                }
                orders.Add(order);
            }
        }
        public static List<Order> Orders=>orders;
    }
}