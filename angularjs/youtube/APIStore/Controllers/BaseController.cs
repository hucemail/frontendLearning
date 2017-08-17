using APIStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIStore.Controllers
{
    public class BaseController : ApiController
    {
        #region 获取返回对象
        protected JsonMsg JsonMsgStatus(int status)
        {
            return JsonMsgFactory.GetJsonMsg(status);
        }
        protected JsonMsg JsonMsg(object data)
        {
            JsonMsg msg = JsonMsgFactory.GetJsonMsg(200);
            msg.data = data;
            return msg;
        }
        protected JsonMsg JsonMsg(int status, object data)
        {
            JsonMsg msg = JsonMsgFactory.GetJsonMsg(status);
            msg.data = data;
            return msg;
        } 
        #endregion
    }
}
