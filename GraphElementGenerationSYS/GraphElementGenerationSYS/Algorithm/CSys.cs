using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphElementGenerationSYS.Algorithm
{
    class CSys
    {
        public static Canvas canvas = new Canvas();//待返回的Canvas对象

        public static double Width//Canvas的宽
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

        public static double Height//Canvas的高
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

        public static int CellNum { get; set; }//单元格个数

        private static int[,] CanvasDotsArray=new int[50,50];//用于保存单元格点的数组，1代表某格有点

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
        /// 使演示面板回到启动时状态
        /// </summary>
        public static void CanvasToDefault()
        {
            canvas.Background = new SolidColorBrush(Color.FromRgb(67, 67, 70));
            ClearCSys();
            ClearDotLocInfor();
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
        /// 在Canvas上保存点
        /// </summary>
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
            //if (isFill)
            //{
                myPath.Fill = Brushes.Orange;//填充为黑色
            //}

            canvas.Children.Add(myPath);//把图像添加到待返回的临时canvas对象上
        }

        #endregion
    }
}

