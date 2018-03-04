using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GraphElementGenerationSYS
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        protected void FormClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected void FormMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        protected void WindowMenu(object sender, RoutedEventArgs e)
        {
            SystemCommands.ShowSystemMenu(this, GetMousePosition());
        }

        protected Point GetMousePosition()
        {
            var position = Mouse.GetPosition(this);
            return new Point(position.X + this.Left, position.Y + this.Top);
        }


    }
}
