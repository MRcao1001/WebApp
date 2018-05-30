using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.webpages
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType ="text/html";
            //引入index的绝对路径
            string path = context.Request.MapPath("index.html");
            //读取index内容
            string html = System.IO.File.ReadAllText(path);
            //判断是否首次加载页面
            string _vs = context.Request.Form["_viewstate"];
            bool ispostback = !string.IsNullOrEmpty(_vs);

            if (ispostback)
            {
                string name = context.Request.Form["name"];
                string pwd = context.Request.Form["pwd"];
                if (name == "10086" && pwd == "123456")
                {
                    context.Response.Write("Hello World");
                }
                else
                {
                    context.Response.Write("filed");
                    //登录失败后返回登录界面
                    context.Response.Write(html);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}