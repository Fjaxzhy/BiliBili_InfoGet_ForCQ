using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.Interface;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;

namespace me.cqp.fjaxzhy.bilibili.UI
{
    public class Menu_SetupWindow : IMenuCall
    {
        private MainWindow _mainWindow = null;
        public void MenuCall (object sender ,CQMenuCallEventArgs e)
        {
            if (_mainWindow == null)
            {
                _mainWindow = new MainWindow();
                _mainWindow.Show();	
                _mainWindow.Closing += MainWindow_Closing;
            }
            else
            {
                _mainWindow.Activate();	
            }
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow = null;
        }
    }
}
