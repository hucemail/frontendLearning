using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Web.Http.Cors;

namespace APIStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            // config.SuppressDefaultHostAuthentication();
            // config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            #region 跨域配置
            //webapi 跨域的支持请参考：http://www.cnblogs.com/moretry/p/4154479.html  http://www.cnblogs.com/landeanfen/p/5177176.html
            //nuget 安装Microsoft.AspNet.WebApi.Cors
            //Install-Package Microsoft.AspNet.WebApi.Cors
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));//允许所有跨域

            var allowOrigins = "http://localhost:11105";//获取允许访问资源的源。http://www.baidu.com,http://www.taobao.com
            var allowHeaders = "*";//获取资源支持的标头。
            var allowMethods = "*";//获取资源支持的方法。
            var globalCors = new EnableCorsAttribute(allowOrigins, allowHeaders, allowMethods);
            config.EnableCors(globalCors);
            #endregion


            #region 默认返回json类型配置
            // Web API configuration and services
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //默认返回 json  
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("datatype", "json", "application/json"));
            //返回格式选择 datatype 可以替换为任何参数   
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("datatype", "xml", "application/xml"));
            #endregion

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
