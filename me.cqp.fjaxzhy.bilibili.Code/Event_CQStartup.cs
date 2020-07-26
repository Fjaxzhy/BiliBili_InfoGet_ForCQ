using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using Native.Sdk.Cqp.Model;

namespace me.cqp.fjaxzhy.bilibili.Code
{
    public class Event_CQStartup : ICQStartup
    {
        /// <summary>
        /// CQ启动事件
        /// </summary>
        /// <param name="sender">事件来源</param>
        /// <param name="e">事件参数</param>
        public void CQStartup(object sender,CQStartupEventArgs e)
        {
            e.CQLog.Info("Tips","哔哩哔哩信息获取插件已经装载");
            if(File.Exists(e.CQApi.AppDirectory+"HistorySearch.txt") != true)
            {
                File.Create(e.CQApi.AppDirectory+"HistorySearch.txt");
            }
        }
    }
}
