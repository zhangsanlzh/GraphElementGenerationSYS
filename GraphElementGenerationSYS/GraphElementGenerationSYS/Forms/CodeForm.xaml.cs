using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphElementGenerationSYS.Forms
{
    /// <summary>
    /// CodeForm.xaml 的交互逻辑
    /// </summary>
    public partial class CodeForm : Window
    {
        public CodeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 拖动窗体
        /// </summary>
        protected void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        protected void FormClose(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow.CodeFormButtonClicked = false;//表明此窗体已关闭，可以继续点击 MainForm 右侧的显示代码窗口按钮
        }

        /// <summary>
        /// 窗体最小化
        /// </summary>
        protected void FormMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 显示系统菜单，当点击Icon的时候
        /// </summary>
        protected void WindowMenu(object sender, RoutedEventArgs e)
        {
            SystemCommands.ShowSystemMenu(this, GetMousePosition());//弹出系统菜单            
        }

        /// <summary>
        /// 设置菜单弹出的位置为鼠标点击的地方
        /// </summary>
        /// <returns>返回一个点</returns>
        protected Point GetMousePosition()
        {
            var position = Mouse.GetPosition(this);
            return new Point(position.X + this.Left, position.Y + this.Top);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void CodeForm_Loaded(object sender, RoutedEventArgs e)
        {
            switch (MainWindow.CheckedItemName)
            {
                case "Circle0":
                    Pages.Circle0 xx = new Pages.Circle0();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = xx;
                    break;

                case "Circle1":
                    MessageBox.Show("I am here");
                    break;

                default:
                    break;
            }
            
        }
    }

}
