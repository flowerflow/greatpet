/***********************************************************************/
//
//      名称：  WaveTable
//      功能：  模仿FlashGet MINI波表板式悬浮窗
//      作者：  UCan
//      日期：  二〇〇八年十月十八日
//      Email： 551881869@QQ.com
//      未经允许，严禁用于商业用途
//
/***********************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WaveTable
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WTMainForm());
        }
    }
}