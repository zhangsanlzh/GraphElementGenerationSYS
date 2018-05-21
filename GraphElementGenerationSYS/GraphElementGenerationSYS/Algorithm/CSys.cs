using GraphElementGenerationSYS.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphElementGenerationSYS.Algorithm
{
    /// <summary>
    /// 坐标系类。包含一系列操作坐标系相关的属性与方法。
    /// </summary>
    class CSys
    {
        /// <summary>
        /// 待返回的画布对象
        /// </summary>
        public static Canvas canvas = new Canvas();

        /// <summary>
        /// 画布的宽
        /// </summary>
        public static double Width
        {
            set
            {
                canvas.Width = value;
            }

            get
            {
                return canvas.Width;
            }

        }

        /// <summary>
        /// 画布的高
        /// </summary>
        public static double Height
        {
            set
            {
                canvas.Height = value;
            }

            get
            {
                return canvas.Height;
            }

        }

        /// <summary>
        /// 坐标系中单元格的个数
        /// </summary>
        public static int CellNum { get; set; }

        /// <summary>
        /// 用于保存单元格点的数组。大小为50×50。
        /// 数组任一元素值为1代表某格有点,0表示没有。
        /// </summary>
        public static int[,] CanvasDotsArray=new int[50,50];

        /// <summary>
        /// 创建坐标系
        /// </summary>
        /// <returns>Canvas对象</returns>
        public static Canvas CreateCoordinateSys()
        {
            canvas.Background = new SolidColorBrush(Color.FromRgb(255,255,0));
            canvas.Width = (canvas.Parent as Canvas).Width;
            canvas.Height = (canvas.Parent as Canvas).Height;

            return canvas;
        }

        /// <summary>
        /// 刷新坐标系
        /// </summary>
        public static void RefreshCordinateSys()
        {
            CSys.ClearCSys();//清除子Canvas的子元素
            CSys.ShowGrid(50);//重绘网格
            CSys.ClearDotLocInfor();//清除点信息
        }

        /// <summary>
        /// 显示坐标网格
        /// </summary>
        /// <param name="CellNum">单元格数,此值非负</param>
        public static void ShowGrid(int CellNum)
        {
            if (CellNum<0)//如果参数值有误，直接返回
            {
                return;
            }

            CSys.CellNum= CellNum;
            Point StartPoint = new Point();//起点
            Point EndPoint = new Point();//终点
            StartPoint.X = 0;
            StartPoint.Y = 0;
            EndPoint.X = 0;
            EndPoint.Y = 0;

            #region 绘制横线
            StartPoint.X = 0;
            for (int j = 0; j <= CellNum; j++)
            {
                StartPoint.Y = j * (canvas.Width / CellNum);
                EndPoint.X = canvas.Width;
                EndPoint.Y = StartPoint.Y;
                DrawLine(StartPoint, EndPoint);
            }
            #endregion

            #region 绘制纵线
            StartPoint.Y = 0;
            for (int j = 0; j <= CellNum; j++)
            {
                StartPoint.X = j * (canvas.Width / CellNum);
                EndPoint.X = StartPoint.X;
                EndPoint.Y = canvas.Width;
                DrawLine(StartPoint, EndPoint);
            }
            #endregion
        }

        /// <summary>
        /// 释放演示面板上所有对象
        /// </summary>
        public static void ClearCSys()
        {
            canvas.Children.Clear();//清空画布上所有对象
        }

        /// <summary>
        /// 画一个点
        /// </summary>
        public static void DrawDot(Point location)
        {
            int x = (int)location.X;
            int y = (int)location.Y;

            if (x >= CellNum || y >= CellNum || x < 0 || y < 0)//如果图像越界，则不描点
            {
                return;
            }
            Point CenterXY = new Point();
            CenterXY.X = (x + 0.5) * Width / CellNum;
            CenterXY.Y = (y + 0.5) * Height / CellNum;

            DrawRectangle(location);
            CanvasDotsArray[(int)location.X, (int)location.Y] = 1;//表明此处有点
        }

        /// <summary>
        /// 一次在画多个点
        /// </summary>
        public static void DrawDots()
        {
            for (int i = 0; i < CellNum; i++)
            {
                for (int j = 0; j < CellNum; j++)
                {
                    if (j > CellNum-1 || i > CellNum-1)//检测到[Length-1,Length-1],包含这个点
                    {
                        continue;
                    }
                    if (CanvasDotsArray[i, j] != 0)
                    {
                        DrawDot(new Point(i, j));
                    }
                }
            }
        }

        /// <summary>
        /// 调用此方法以表明画布上某处有点。
        /// </summary>
        /// <param name="location">点的坐标。</param>
        public static void SetDotLocInfor(Point location)
        {
            if (location.Y<0||location.X<0||location.Y>CellNum-1||location.X>CellNum-1)
            {
                return;
            }
            CanvasDotsArray[(int)location.X, (int)location.Y] = 1;//表明此处有点
        }

        /// <summary>
        /// //清空点信息
        /// </summary>
        public static void ClearDotLocInfor()
        {
            if (!(CanvasDotsArray is null))
            {
                for (int i = 0; i < CellNum; i++)//清空当前画布上储存的点的位置信息
                {
                    for (int j = 0; j < CellNum; j++)
                    {
                        if (j > CellNum-1 || i > CellNum-1)//检测到[Length-1,Length-1],包含这个点
                        {
                            continue;
                        }
                        if (CanvasDotsArray[i, j] != 0)
                        {
                            CanvasDotsArray[i, j] = 0;
                        }
                    }
                }
            }
        }

        #region CSys内部引用
        /// <summary>
        /// 画一条线。此方法用于网格的绘制
        /// </summary>
        /// <param name="startPt">线的起点</param>
        /// <param name="endPt">线的终点</param>
        private static void DrawLine(Point startPt, Point endPt)//画一条线
        {
            //设置线型为虚线
            DoubleCollection dCollection = new DoubleCollection();
            dCollection.Add(2);
            dCollection.Add(3);

            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = startPt;
            myLineGeometry.EndPoint = endPt;
            Path myPath = new Path();
            myPath.Stroke = Brushes.Gray;
            myPath.StrokeThickness = 1;
            myPath.Data = myLineGeometry;
            myPath.StrokeDashArray = dCollection;

            canvas.Children.Add(myPath);//把图像添加到待返回的Canvas对象上

        }

        /// <summary>
        /// 画一个矩形。此方法用于填充网格的交叉线围成的矩形
        /// </summary>
        private static void DrawRectangle(Point rectLoc)//画矩形
        {
            DoubleCollection dCollection = new DoubleCollection();//设置线型为虚线
            dCollection.Add(2);
            dCollection.Add(3);

            RectangleGeometry myRectangleGeometry = new RectangleGeometry();//设置矩形属性
            Rect myRect = new Rect();
            myRect.X = rectLoc.X * Width / CellNum;
            myRect.Y = rectLoc.Y * Height / CellNum;
            myRect.Width = Width / CellNum;
            myRect.Height = Height / CellNum;
            myRectangleGeometry.Rect = myRect;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Gray;//边线颜色为灰色
            myPath.StrokeThickness = 1;//边线宽为1
            myPath.Data = myRectangleGeometry;
            myPath.StrokeDashArray = dCollection;

            //根据设定的颜色确定填充点的颜色
            switch(CanvasContentColorPicker.ColorUserDefintion)
            {
                case "Orange":
                    myPath.Fill = Brushes.Orange;//填充为Orange色
                    break;

                case "Black":
                    myPath.Fill = Brushes.Black;//填充为Black色
                    break;

                case "Red":
                    myPath.Fill = Brushes.Red;//填充为Red色
                    break;

                case "Pink":
                    myPath.Fill = Brushes.Pink;//填充为Pink色
                    break;

                case "Green":
                    myPath.Fill = Brushes.Green;//填充为Green色
                    break;

                case "Purple":
                    myPath.Fill = Brushes.Purple;//填充为Purple色
                    break;

                case "Gray":
                    myPath.Fill = Brushes.Gray;//填充为Gray色
                    break;

                case "Blue":
                    myPath.Fill = Brushes.Blue;//填充为Blue色
                    break;

                default:
                    break;
            }

            canvas.Children.Add(myPath);//把图像添加到待返回的临时canvas对象上
        }

        #endregion
    }
}

