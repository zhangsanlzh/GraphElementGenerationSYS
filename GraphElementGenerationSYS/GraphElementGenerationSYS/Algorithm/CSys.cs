using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphElementGenerationSYS.Algorithm
{
    class CSys
    {
        public Canvas canvas = new Canvas();//待返回的Canvas对象

        public double Width//Canvas的宽
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

        public double Height//Canvas的高
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

        public int CellNum { get; set; }//单元格个数

        /// <summary>
        /// 创建坐标系
        /// </summary>
        /// <returns>Canvas对象</returns>
        public Canvas CreateCoordinateSys()
        {
            canvas.Background = new SolidColorBrush(Color.FromRgb(255,255,0));
            canvas.Width = (canvas.Parent as Canvas).Width;
            canvas.Height = (canvas.Parent as Canvas).Height;

            return canvas;
        }

        /// <summary>
        /// 显示坐标网格
        /// </summary>
        public void ShowGrid(int CellNum)
        {
            this.CellNum = CellNum;

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
        /// 清空Canvas
        /// </summary>
        /// 
        public void ClearCSys()
        {
            canvas.Children.Clear();
        }

        public void DrawDot(Point location)
        {
            int x = (int)location.X;
            int y = (int)location.Y;

            if (x >= this.CellNum || y >= this.CellNum || x < 0 || y < 0)//如果图像越界，则不描点
            {
                return;
            }
            Point CenterXY = new Point();
            CenterXY.X = (x + 0.5) * this.Width / this.CellNum;
            CenterXY.Y = (y + 0.5) * this.Height / this.CellNum;

            //if (MainWindow.SYSMODE == 0)//完全填充模式
            //{
                DrawRectangle(location);
            //}
            //else//内切圆填充模式
            //{
            //    DrawCircle(CenterXY, RADIUS);//描点
            //}
        }


        #region CSys内部引用
        private void DrawLine(Point startPt, Point endPt)//画一条线
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

        private void DrawRectangle(Point rectLoc)//画矩形
        {
            DoubleCollection dCollection = new DoubleCollection();//设置线型为虚线
            dCollection.Add(2);
            dCollection.Add(3);

            RectangleGeometry myRectangleGeometry = new RectangleGeometry();//设置矩形属性
            Rect myRect = new Rect();
            myRect.X = rectLoc.X * this.Width / this.CellNum;
            myRect.Y = rectLoc.Y * this.Height / this.CellNum;
            myRect.Width = this.Width / this.CellNum;
            myRect.Height = this.Height / this.CellNum;
            myRectangleGeometry.Rect = myRect;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Gray;//边线颜色为灰色
            myPath.StrokeThickness = 1;//边线宽为1
            myPath.Data = myRectangleGeometry;
            myPath.StrokeDashArray = dCollection;
            //if (isFill)
            //{
                myPath.Fill = Brushes.Black;//填充为黑色
            //}

            canvas.Children.Add(myPath);//把图像添加到待返回的临时canvas对象上
        }

        #endregion
    }
}

