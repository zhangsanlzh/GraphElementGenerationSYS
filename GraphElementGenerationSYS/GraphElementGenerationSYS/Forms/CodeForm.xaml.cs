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
                #region 圆与椭圆
                case "Circle0":
                    Pages.Circle0 circle0 = new Pages.Circle0();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = circle0;
                    break;

                case "Circle1":
                    Pages.Circle1 circle1 = new Pages.Circle1();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = circle1;
                    break;

                case "Circle2":
                    Pages.Circle2 circle2 = new Pages.Circle2();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = circle2;
                    break;

                case "Circle3":
                    Pages.Circle3 circle3 = new Pages.Circle3();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = circle3;
                    break;

                case "Circle4":
                    Pages.Circle4 circle4 = new Pages.Circle4();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = circle4;
                    break;

                case "Circle5":
                    Pages.Circle5 circle5 = new Pages.Circle5();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = circle5;
                    break;

                #endregion

                #region 矩形
                case "Square0":
                    Pages.Square0 square0 = new Pages.Square0();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = square0;
                    break;

                case "Square1":
                    Pages.Square1 square1 = new Pages.Square1();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = square1;
                    break;

                #endregion

                #region 直线
                case "StraitLine0":
                    Pages.StraitLine0 StraitLine0 = new Pages.StraitLine0();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = StraitLine0;
                    break;

                case "StraitLine1":
                    Pages.StraitLine1 StraitLine1 = new Pages.StraitLine1();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = StraitLine1;
                    break;

                case "StraitLine2":
                    Pages.StraitLine2 StraitLine2 = new Pages.StraitLine2();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = StraitLine2;
                    break;
                #endregion

                #region 多边形
                case "Polygon0":
                    Pages.Polygon0 Polygon0 = new Pages.Polygon0();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = Polygon0;
                    break;

                case "Polygon1":
                    Pages.Polygon1 Polygon1 = new Pages.Polygon1();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = Polygon1;
                    break;

                case "Polygon2":
                    Pages.Polygon2 Polygon2 = new Pages.Polygon2();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = Polygon2;
                    break;
                #endregion

                #region 字符
                case "Character0":
                case "Character1":
                case "Character2":
                case "Character3":
                case "Character4":
                case "Character5":
                case "Character6":
                case "Character7":
                case "Character8":
                case "Character9":
                case "Character10":
                case "Character11":
                case "Character12":
                case "Character13":
                case "Character14":
                case "Character15":
                case "Character16":
                case "Character17":
                case "Character18":
                case "Character19":
                case "Character20":
                case "Character21":
                case "Character22":
                case "Character23":
                case "Character24":
                case "Character25":
                case "Character26":
                case "Character27":
                case "Character28":
                case "Character29":
                case "Character30":
                case "Character31":
                case "Character32":
                case "Character33":
                case "Character34":
                case "Character35":
                case "Character36":
                case "Character37":
                case "Character38":
                case "Character39":
                case "Character40":
                case "Character41":
                case "Character42":
                case "Character43":
                case "Character44":
                case "Character45":
                case "Character46":
                case "Character47":
                case "Character48":
                case "Character49":
                case "Character50":
                case "Character51":
                    Pages.Character CharacterPage = new Pages.Character();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = CharacterPage;
                    break;
                #endregion

                default:
                    Pages.DefaultPage defaultPage = new Pages.DefaultPage();
                    (this.GetTemplateChild("CodeFrame") as Frame).Content = defaultPage;
                    break;
            }
            
        }
    }

}
