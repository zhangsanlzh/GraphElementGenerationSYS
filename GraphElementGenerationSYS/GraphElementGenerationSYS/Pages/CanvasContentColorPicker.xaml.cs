using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace GraphElementGenerationSYS.Pages
{
    /// <summary>
    /// CanvasContentColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class CanvasContentColorPicker : Page
    {
        public CanvasContentColorPicker()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 指示用户选择了哪种颜色。此值由一临时变量的值决定。
        /// 用户未点击确定按钮时，该值不变。
        /// </summary>
        public static string ColorUserDefintion= "Orange";

        /// <summary>
        /// 此变量临时保存用户点击的颜色项。只要用户点击了颜色项，
        /// 该值就发生变化。
        /// </summary>
        private static string ColorUserDefintionTemp = "";

        /// <summary>
        /// 计时的对象
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ColorUserDefintion = ColorUserDefintionTemp;//点击确定按钮才真正改变用户选择的颜色

            //设置定时器
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(10000000);   //时间间隔为一秒
            timer.Tick += new EventHandler(timer_Tick);

            //渐入动画
            DoubleAnimation animationShow = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.4)));

            switch (ColorUserDefintionTemp)
            {
                case "Orange":
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "已设为橙黄色~";
                    break;

                case "Black":
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "已设为黑色~";
                    break;

                case "Red":
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "已设为红色~";
                    break;

                case "Pink":
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "已设为粉色~";
                    break;

                case "Green":
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "已设为绿色~";
                    break;

                case "Purple":
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "已设为紫色~";
                    break;

                case "Gray":
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "已设为灰色~";
                    break;

                case "Blue":
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "已设为蓝色~";
                    break;

                default:
                    timer.Start();//开始计时
                    OkMessage.BeginAnimation(OpacityProperty, animationShow);
                    OkMessage.Visibility = Visibility.Visible;
                    MessageBoxTextBlock.Text = "默认颜色是橙色~";
                    break;

            }

        }

        /// <summary>
        /// 此值每隔设定时长便增一
        /// </summary>
        private int count = 0;

        /// <summary>
        /// 此事件为Timer按设定的时间间隔定时发生的事件
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count<2)
            {
                return;
            }
            count = 0;
            timer.Stop();//停止计时
            OkMessage.Visibility = Visibility.Hidden;
            MessageBoxTextBlock.Text = "";
        }

        /// <summary>
        /// RadioButton点击事件
        /// </summary>
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            ColorUserDefintionTemp = (sender as RadioButton).Name;
        }

        /// <summary>
        /// 加载此页面时判断当前选择的颜色，并选中对应的RadioButton项
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            switch (ColorUserDefintion)
            {
                case "Orange":
                    Orange.IsChecked = true;
                    break;

                case "Black":
                    Black.IsChecked = true;
                    break;

                case "Red":
                    Red.IsChecked = true;
                    break;

                case "Pink":
                    Pink.IsChecked = true;
                    break;

                case "Green":
                    Green.IsChecked = true;
                    break;

                case "Purple":
                    Purple.IsChecked = true;
                    break;

                case "Gray":
                    Gray.IsChecked = true;
                    break;

                case "Blue":
                    Blue.IsChecked = true;
                    break;

                default:
                    break;

            }
        }
    }
}
