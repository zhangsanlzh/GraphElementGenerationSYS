using System;
using System.Windows;
using System.Windows.Controls;

namespace GraphElementGenerationSYS.Pages
{
    /// <summary>
    /// CanvasContentsMFrmLoad.xaml 的交互逻辑
    /// </summary>
    public partial class CanvasContentsMFrmLoad : Page
    {
        public CanvasContentsMFrmLoad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 去Github
        /// </summary>
        private void GotoGithub(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/zhangsanlzh/GraphElementGenerationSYS-ING");
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 去CSDN博客
        /// </summary>
        private void GotoCSDN(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://blog.csdn.net/qq_33712555");
            }
            catch (Exception)
            {

            }
        }
    }
}
