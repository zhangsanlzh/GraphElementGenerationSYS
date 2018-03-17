using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;

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
            doc.Load("../../Data/FuncListItem.xml");

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

                #region Case:Curve
                case "Curve":
                    listBox.Visibility = Visibility.Visible;
                    for (int i = 0; i < childs[3].ChildNodes.Count; i++)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Style = FindResource("ListItemStyle") as Style;
                        item.Content = childs[3].ChildNodes.Item(i).InnerText;
                        item.Name = "Curve" + i.ToString();
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

        /// <summary>
        /// 功能列表项的点击回应事件
        /// </summary>
        private void ListBoxItemPreviewMouseLeftButtonDown(object sender,MouseButtonEventArgs e)
        {            
            MessageBox.Show((sender as ListBoxItem).Name);
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

                canvas.Width = canvas.Width * (1+ScaleSpeed);
                canvas.Height = canvas.Height *(1 + ScaleSpeed);
            }
            else//下滑缩小
            {
                if (canvas.Width<250)//250表示原Canvas大小的0.5倍
                {
                    return;
                }

                canvas.Width = canvas.Width * (1 - ScaleSpeed);
                canvas.Height = canvas.Height * (1 - ScaleSpeed);
            }
        }
    }
}
