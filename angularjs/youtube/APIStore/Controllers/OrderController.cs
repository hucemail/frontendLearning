using APIStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using APIStore.Common;
using System.Web;
using System.Collections.Specialized;

namespace APIStore.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : BaseController
    {
        [Route("GetAllOrders")]
        [HttpGet]
        [HttpPost]
        public JsonMsg GetAllOrders()
        {
            //查询所有订单
            return JsonMsg(OrderFactory.Orders);
        }
        [Route("GetOrders/{pageindex:int?}")]
        [HttpGet]
        public JsonMsg GetOrders(int pageindex = 1)
        {
            //带条件的订单查询
            int pagesize = 10;
            IEnumerable<Order> orders = OrderFactory.Orders;
            //分页
            IEnumerable<Order> result = result =orders.Skip((pageindex - 1) * pagesize).Take(pagesize);
            return JsonMsg(result);
        }
        [Route("GetAllOrdersCount")]
        [HttpGet]
        [HttpPost]
        public JsonMsg GetAllOrdersCount()
        {
            //获取订单总量
            return JsonMsg(OrderFactory.Orders.Count);
        }
        [Route("UpdateStatus")]
        [HttpPost]
        public JsonMsg UpdateStatus(dynamic paras)
        {
            var content = Request.Properties["MS_HttpContext"] as HttpContextBase;
            paras.signature = content.Request.Headers["Signature"];
            //NameValueCollection val = content.Request.Form;
            return JsonMsg(paras);
        }
        [Route("CreateOrder")]
        [HttpPost]
        public JsonMsg CreateOrder(Order order)
        {
            //创建订单
           // OrderFactory.Orders.Add(order);
            return JsonMsg(order);
        }
    }
}
