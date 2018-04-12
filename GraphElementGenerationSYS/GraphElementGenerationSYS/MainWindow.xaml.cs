using GraphElementGenerationSYS.Algorithm;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;
using GraphElementGenerationSYS.Forms;
using System.Threading;

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
        /// 功能按钮点击事件
        /// </summary>
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var listBox =(ListBox)this.GetTemplateChild("FunctionList");//找到列表框    
            listBox.Items.Clear();//清空所有项
            if((sender as RadioButton).Name=="Home")
            {
                listBox.Visibility = Visibility.Hidden;

                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load("Data/FuncListItem.xml");

            var root = doc.SelectSingleNode("Root");
            var childs = root.ChildNodes;

            var funcName = (sender as RadioButton).Name;//获得点击的功能按钮值
            switch (funcName)
            {
                #region Case:Circle
                case "Circle":
                    listBox.Visibility=Visibility.Visible;
                    for (int i = 0; i < childs[0].ChildNodes.Count; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Style = FindResource("ListItemStyle") as Style;
                        item.Content = childs[0].ChildNodes.Item(i).InnerText;
                        item.Name = "Circle" + i.ToString();
                        item.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ListBoxItemPreviewMouseLeftButtonDown);

                        listBox.Items.Add(item);
                    }
                    break;
                #endregion

                #region Case:Square
                case "Square":
                    listBox.Visibility = Visibility.Visible;
                    for (int i = 0; i < childs[1].ChildNodes.Count; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Style = FindResource("ListItemStyle") as Style;
                        item.Content = childs[1].ChildNodes.Item(i).InnerText;
                        item.Name = "Square" + i.ToString();
                        item.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ListBoxItemPreviewMouseLeftButtonDown);

                        listBox.Items.Add(item);
                    }
                    break;
                #endregion

                #region Case:StraitLine
                case "StraitLine":
                    listBox.Visibility = Visibility.Visible;
                    for (int i = 0; i < childs[2].ChildNodes.Count; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Style = FindResource("ListItemStyle") as Style;
                        item.Content = childs[2].ChildNodes.Item(i).InnerText;
                        item.Name = "StraitLine" + i.ToString();
                        item.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ListBoxItemPreviewMouseLeftButtonDown);

                        listBox.Items.Add(item);
                    }
                    break;
                #endregion

                #region Case:Polygon
                case "Polygon":
                    listBox.Visibility = Visibility.Visible;
                    for (int i = 0; i < childs[3].ChildNodes.Count; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Style = FindResource("ListItemStyle") as Style;
                        item.Content = childs[3].ChildNodes.Item(i).InnerText;
                        item.Name = "Polygon" + i.ToString();
                        item.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ListBoxItemPreviewMouseLeftButtonDown);

                        listBox.Items.Add(item);
                    }
                    break;
                #endregion

                #region Case:Character
                case "Character":
                    listBox.Visibility = Visibility.Visible;
                    for (int i = 0; i < childs[4].ChildNodes.Count; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Style = FindResource("ListItemStyle") as Style;
                        item.Content = childs[4].ChildNodes.Item(i).InnerText;
                        item.Name = "Character" + i.ToString();
                        item.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ListBoxItemPreviewMouseLeftButtonDown);

                        listBox.Items.Add(item);
                    }
                    break;
                #endregion

                #region Case:Transform
                case "Transform":
                    listBox.Visibility = Visibility.Visible;
                    for (int i = 0; i < childs[5].ChildNodes.Count; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Style = FindResource("ListItemStyle") as Style;
                        item.Content = childs[5].ChildNodes.Item(i).InnerText;
                        item.Name = "Transform" + i.ToString();
                        item.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ListBoxItemPreviewMouseLeftButtonDown);

                        listBox.Items.Add(item);
                    }
                    break;
                #endregion

                #region Case:Setting
                case "Setting":
                    listBox.Visibility = Visibility.Visible;
                    for (int i = 0; i < childs[6].ChildNodes.Count; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Style = FindResource("ListItemStyle") as Style;
                        item.Content = childs[6].ChildNodes.Item(i).InnerText;
                        item.Name = "Setting" + i.ToString();
                        item.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ListBoxItemPreviewMouseLeftButtonDown);

                        listBox.Items.Add(item);
                    }
                    break;
                #endregion

                default:
                    break;
            }
        }

        public static string CheckedItemName="";//指示点击过的项的名称
        /// <summary>
        /// 功能列表项的点击回应事件
        /// </summary>
        private void ListBoxItemPreviewMouseLeftButtonDown(object sender,MouseButtonEventArgs e)
        {
            #region 项点击检测
            var canvas = (Canvas)this.GetTemplateChild("FuncShowCanvas");//找到功能演示面板           

            var itemName = (sender as ListBoxItem).Name;//判断此次点击的项是否是上次点击的，或是初次点击的项，如果不是则清空容器Canvas
            if (itemName != CheckedItemName && itemName!="")
            {
                canvas.Children.Clear();
            }
            CheckedItemName=itemName;//记录上次点击的项的名字

            if (canvas.Children.Count == 0)//判断，如果容器Canvas上没有子Canvas，则重绘子Canvas
            {
                canvas.Children.Add(CSys.canvas);
                CSys.CreateCoordinateSys();
                CSys.ClearCSys();
                CSys.ShowGrid(50);
            }

            #endregion

            switch (itemName)
            {
                #region 圆与椭圆
                #region 中点画圆算法
                case "Circle0":
                    CSys.ClearDotLocInfor();//清空点信息
                    CircleAlgo.MidpointCircleAlgo();
                    CSys.DrawDots();//画点
                    break;
                #endregion

                #region Bresenham画圆算法
                case "Circle1":
                    CSys.ClearDotLocInfor();
                    CircleAlgo.BresenhamCircleAlgo();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 正负判定画圆算法
                case "Circle2":
                    CSys.ClearDotLocInfor();
                    CircleAlgo.PosiAndNegaCircleAlgo();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 快速画圆算法
                case "Circle3":
                    CSys.ClearDotLocInfor();
                    CircleAlgo.QuickCircleAlgo();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 中点椭圆算法
                case "Circle4":
                    CSys.ClearDotLocInfor();
                    CircleAlgo.MidpointEllipseAlgo();
                    CSys.DrawDots();
                    break;
                #endregion

                #region Bresenham椭圆算法
                case "Circle5":
                    CSys.ClearDotLocInfor();
                    CircleAlgo.BresenhamEllipseAlgo();
                    CSys.DrawDots();
                    break;
                #endregion

                #endregion

                #region 矩形
                #region 矩形生成算法-不填充
                case "Square0":
                    CSys.ClearDotLocInfor();
                    RectangleAlgo.RectangleNoFillAlgo();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 矩形生成算法-填充
                case "Square1":
                    CSys.ClearDotLocInfor();
                    RectangleAlgo.RectangleFillAlgo();
                    CSys.DrawDots();
                    break;
                #endregion

                #endregion

                #region 直线
                #region DDA画线法
                case "StraitLine0"://DDA画线法
                    CSys.ClearDotLocInfor();
                    StraitLineAlgo.DrawStraitLineDDA();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 中点画线法
                case "StraitLine1"://中点画线法
                    CSys.ClearDotLocInfor();
                    StraitLineAlgo.CenterStraitLine();
                    CSys.DrawDots();
                    break;
                #endregion

                #region Bresenham画线
                case "StraitLine2"://Bresenham画线
                    CSys.ClearDotLocInfor();
                    StraitLineAlgo.BresenhamStraitLine();
                    CSys.DrawDots();
                    break;
                #endregion

                #endregion

                #region 多边形
                #region 正三角形
                case "Polygon0":
                    CSys.ClearDotLocInfor();
                    PolygonAlgo.RegularTriangle();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 正方形
                case "Polygon1":
                    CSys.ClearDotLocInfor();
                    PolygonAlgo.CreateSquare();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 任意个顶点的多边形
                case "Polygon2":
                    CSys.ClearDotLocInfor();
                    PolygonAlgo.CreateGenericPolygon();
                    CSys.DrawDots();
                    break;
                #endregion

                #endregion

                #region 字符
                #region 英文字符 A/a-Z/z
                #region A/G-Consolas字体
                case "Character0":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.A();
                    CSys.DrawDots();
                    break;

                case "Character1":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.B();
                    CSys.DrawDots();
                    break;

                case "Character2":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.C();
                    CSys.DrawDots();
                    break;

                case "Character3":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.D();
                    CSys.DrawDots();
                    break;

                case "Character4":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.E();
                    CSys.DrawDots();
                    break;

                case "Character5":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.F();
                    CSys.DrawDots();
                    break;

                case "Character6":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.G();
                    CSys.DrawDots();
                    break;

                #endregion

                #region H/n-Gabriola字体
                case "Character7":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.H();
                    CSys.DrawDots();
                    break;

                case "Character8":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.I();
                    CSys.DrawDots();
                    break;

                case "Character9":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.J();
                    CSys.DrawDots();
                    break;

                case "Character10":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.K();
                    CSys.DrawDots();
                    break;

                case "Character11":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.L();
                    CSys.DrawDots();
                    break;

                case "Character12":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.M();
                    CSys.DrawDots();
                    break;

                case "Character13":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.N();
                    CSys.DrawDots();
                    break;
                #endregion

                #region O/Q-Segoe Print字体
                case "Character14":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.O();
                    CSys.DrawDots();
                    break;

                case "Character15":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.P();
                    CSys.DrawDots();
                    break;
                case "Character16":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.Q();
                    CSys.DrawDots();
                    break;
                #endregion

                #region R/T-Hobo Std字体
                case "Character17":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.R();
                    CSys.DrawDots();
                    break;

                case "Character18":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.S();
                    CSys.DrawDots();
                    break;
                case "Character19":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.T();
                    CSys.DrawDots();
                    break;
                #endregion

                #region U/W-Segoe Print字体
                case "Character20":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.U();
                    CSys.DrawDots();
                    break;

                case "Character21":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.V();
                    CSys.DrawDots();
                    break;
                case "Character22":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.W();
                    CSys.DrawDots();
                    break;
                #endregion

                #region X/Z-Letter Gothic Std字体
                case "Character23":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.X();
                    CSys.DrawDots();
                    break;

                case "Character24":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.Y();
                    CSys.DrawDots();
                    break;

                case "Character25":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.Z();
                    CSys.DrawDots();
                    break;
                #endregion

                #endregion

                #region 特殊字符
                case "Character26":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.SpecialCharacters();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 汉字
                #region 富强民主 文明和谐
                case "Character27":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters0();
                    CSys.DrawDots();
                    break;
                case "Character28":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters1();
                    CSys.DrawDots();
                    break;
                case "Character29":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters2();
                    CSys.DrawDots();
                    break;
                case "Character30":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters3();
                    CSys.DrawDots();
                    break;
                case "Character31":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters4();
                    CSys.DrawDots();
                    break;
                case "Character32":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters5();
                    CSys.DrawDots();
                    break;
                case "Character33":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters6();
                    CSys.DrawDots();
                    break;
                case "Character34":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters7();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 自由平等 公正法治
                case "Character35":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters8();
                    CSys.DrawDots();
                    break;
                case "Character36":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters9();
                    CSys.DrawDots();
                    break;
                case "Character37":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters10();
                    CSys.DrawDots();
                    break;
                case "Character38":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters11();
                    CSys.DrawDots();
                    break;
                case "Character39":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters12();
                    CSys.DrawDots();
                    break;
                case "Character40":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters13();
                    CSys.DrawDots();
                    break;
                case "Character41":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters14();
                    CSys.DrawDots();
                    break;
                case "Character42":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters15();
                    CSys.DrawDots();
                    break;
                #endregion

                #region 爱国敬业 诚信友善
                case "Character43":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters16();
                    CSys.DrawDots();
                    break;
                case "Character44":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters17();
                    CSys.DrawDots();
                    break;
                case "Character45":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters18();
                    CSys.DrawDots();
                    break;
                case "Character46":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters19();
                    CSys.DrawDots();
                    break;
                case "Character47":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters20();
                    CSys.DrawDots();
                    break;
                case "Character48":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters21();
                    CSys.DrawDots();
                    break;
                case "Character49":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters22();
                    CSys.DrawDots();
                    break;
                case "Character50":
                    CSys.ClearDotLocInfor();
                    CharacterAlgo.ChineseCharacters23();
                    CSys.DrawDots();
                    break;
                #endregion

                #endregion

                #endregion

                case "Transform0":
                    CSys.ClearDotLocInfor();
                    TransformAlgo.Translation();
                    CSys.DrawDots();

                    break;

                default:
                    break;
            }

        }


        double ScaleSpeed = 0.05;//放缩比例,5%
        /// <summary>
        /// 鼠标滚轮滚动事件
        /// </summary>
        /// <function>上滑放大，下滑缩小</function>
        private void ShowFuncGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {            
            var canvas = (Canvas)this.GetTemplateChild("FuncShowCanvas");//找到功能演示面板   
            if (e.Delta>0)//上滑放大
            {
                if (canvas.Width>550)//550表示原Canvas大小的1.1倍
                {
                    return;
                }

                canvas.Width = canvas.Width * (1+ScaleSpeed);//改变容器Canvas的宽高
                canvas.Height = canvas.Height *(1 + ScaleSpeed);

                if (canvas.Children.Count != 0)//判断初始时是否有子Canvas，没有则不设定子Canvas宽高
                {
                    CSys.Width = canvas.Width;//设置子Canvas的宽高与容器Canvas的宽高一致
                    CSys.Height = canvas.Height;
                    CSys.ClearCSys();//清除子Canvas的子元素并重绘网格
                    CSys.ShowGrid(50);
                    CSys.DrawDots();
                }
            }
            else//下滑缩小
            {
                if (canvas.Width<250)//250表示原Canvas大小的0.5倍
                {
                    return;
                }

                canvas.Width = canvas.Width * (1 - ScaleSpeed);//改变容器Canvas的宽高
                canvas.Height = canvas.Height * (1 - ScaleSpeed);

                if (canvas.Children.Count!=0)//判断初始时是否有子Canvas，没有则不设定子Canvas宽高
                {
                    CSys.Width = canvas.Width;//设置子Canvas的宽高与容器Canvas的宽高一致
                    CSys.Height = canvas.Height;
                    CSys.ClearCSys();//清除子Canvas的子元素并重绘网格
                    CSys.ShowGrid(50);
                    CSys.DrawDots();
                }
            }
        }

        /// <summary>
        /// 该值指示显示代码窗口按钮是否点击过了。默认false，没点击过。
        /// </summary>
        public static bool CodeFormButtonClicked=false;

        /// <summary>
        /// 显示代码窗体按钮点击事件
        /// </summary>
        private void CodeButton_Checked(object sender, RoutedEventArgs e)
        {
            if (CodeFormButtonClicked)//点击过的话就不执行后面的窗体show操作
            {
                return;
            }

            CodeForm codeForm = new CodeForm();
            DoubleAnimation daV = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.4)));//设置动画-淡入效果
            codeForm.BeginAnimation(OpacityProperty, daV);
            codeForm.Show();//显示窗体

            CodeFormButtonClicked = true;//表明此按钮已经点击过

        }
    }
}
