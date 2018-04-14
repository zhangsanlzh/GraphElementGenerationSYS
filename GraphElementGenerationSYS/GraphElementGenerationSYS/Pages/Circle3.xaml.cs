using System;
using System.Windows;
using System.Windows.Controls;

namespace GraphElementGenerationSYS.Pages
{
    /// <summary>
    /// Circle3.xaml 的交互逻辑
    /// </summary>
    public partial class Circle3 : Page
    {
        public Circle3()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://blog.csdn.net/u013044116/article/details/49305017");
            }
            catch (Exception)
            {

            }
        }

    }
}
