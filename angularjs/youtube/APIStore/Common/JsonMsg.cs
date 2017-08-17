using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace APIStore.Common
{
    /// <summary>
    /// 接口返回对象
    /// </summary>
    [Serializable]
    [DataContract]
    public class JsonMsg
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [DataMember]
        public int status { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        [DataMember]
        public object data { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        [DataMember]
        public string msg { get; set; }
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns></returns>
        public JsonMsg Clone()
        {
            //需要加Serializable特性
            //加了Serializable特性后序列化json会出现k__BackingField，所以还需要加入DataContract
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, this);
                ms.Position = 0;
                return (JsonMsg)bf.Deserialize(ms);
            }
        }
    }
    /// <summary>
    /// JsonMsg工厂
    /// </summary>
    public class JsonMsgFactory
    {
        private static Dictionary<int, JsonMsg> msgs;

        static JsonMsgFactory()
        {
            msgs = new Dictionary<int, JsonMsg>();
            string path = GetMapPath("~/common/jsonmsg.json"), json = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            List<JsonMsg> jsonmsgs = JsonConvert.DeserializeObject<List<JsonMsg>>(json);
            foreach (var item in jsonmsgs)
            {
                msgs.Add(item.status, item);
            }
            
        }
        /// <summary>
        /// 获取文件物理路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string GetMapPath(string path)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(path);
            }
            else
            {
                return System.Web.Hosting.HostingEnvironment.MapPath(path);
            }
        }
        public static JsonMsg GetJsonMsg(int status)
        {
            return msgs[status].Clone();
        }
    }
}