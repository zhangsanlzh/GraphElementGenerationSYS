using System;
using System.Windows;
using System.Windows.Controls;

namespace GraphElementGenerationSYS.Pages
{
    /// <summary>
    /// StraitLine2.xaml 的交互逻辑
    /// </summary>
    public partial class StraitLine2 : Page
    {
        public StraitLine2()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.cnblogs.com/llsq/p/7506597.html");
            }
            catch (Exception)
            {

            }

        }

    }
}
