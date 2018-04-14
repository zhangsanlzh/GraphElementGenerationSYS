using System;
using System.Windows;
using System.Windows.Controls;

namespace GraphElementGenerationSYS.Pages
{
    /// <summary>
    /// Circle5.xaml 的交互逻辑
    /// </summary>
    public partial class Circle5 : Page
    {
        public Circle5()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://blog.csdn.net/orbit/article/details/7496008");
            }
            catch (Exception)
            {

            }
        }
    }
}
