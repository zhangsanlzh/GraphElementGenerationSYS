using System.Windows;

namespace GraphElementGenerationSYS.Algorithm
{
    class StraitLineAlgo
    {
        /// <summary>
        /// DDA画线
        /// </summary>
        public static void DrawStraitLineDDA()
        {
            //斜率为0的，自上往下画出的线
            DrawStraitLineDDA(10, 10, 10, 50);
            //斜率为0的，自下往上画出的线
            DrawStraitLineDDA(20, 20, 20, 0);

            //斜率为0的，自左往右画出的线
            DrawStraitLineDDA(10, 10, 50, 10);
            //斜率为0的，自右往左画出的线
            DrawStraitLineDDA(20, 20, 0, 20);

            //左上到右下画出的线
            DrawStraitLineDDA(5, 0, 20, 20);
            DrawStraitLineDDA(0, 5, 20, 20);
            //右下到左上画出的线
            DrawStraitLineDDA(20, 20, 0, 10);
            DrawStraitLineDDA(20, 20, 10, 0);

            //左下到右上画出的线
            DrawStraitLineDDA(0, 5, 5, 0);
            //右上到左下画出的线
            DrawStraitLineDDA(10, 0, 0, 10);

            //对角线-左上到右下
            DrawStraitLineDDA(0, 49, 49, 0);
            DrawStraitLineDDA(0, 55, 55, 0);

        }

        /// <summary>
        /// 双步画线
        /// </summary>
        public static void TwoStepsDrawStraitLine()
        {
            //斜率为0的，自上往下画出的线
            TwoStepsDrawStraitLine(10, 10, 10, 50);
            //斜率为0的，自下往上画出的线
            //TwoStepsDrawStraitLine(20, 0, 20, 20);
            TwoStepsDrawStraitLine(20, 20, 20, 0);

            //斜率为0的，自左往右画出的线
            TwoStepsDrawStraitLine(10, 10, 50, 10);
            //斜率为0的，自右往左画出的线
            TwoStepsDrawStraitLine(20, 20, 0, 20);

            //对角线-左上到右下
            TwoStepsDrawStraitLine(0, 0, 20, 20);
            //对角线-右下到左上
            TwoStepsDrawStraitLine(40, 40,20, 20);

            //斜率小于1的，左上到右下画出的线
            TwoStepsDrawStraitLine(0,5,20,20);
            //斜率小于1的，右下到左上画出的线
            TwoStepsDrawStraitLine(20,20,0,10);

        }

        /// <summary>
        /// Bresenham画线
        /// </summary>
        public static void BresenhamStraitLine()
        {
            BresenhamStraitLine(0, 0, 20, 30);
        }

        /// <summary>
        /// DDA画线
        /// </summary>
        /// <param name="StartPoint">起点</param>
        /// <param name="EndPoint">终点</param>
        public static void DrawStraitLineDDA(pointLoc StartPoint, pointLoc EndPoint)
        {
            DrawStraitLineDDA(StartPoint.x, StartPoint.y, EndPoint.x, EndPoint.y);
        }

        /// <summary>
        /// DDA画线法
        /// </summary>
        /// <param name="Sx">起点横坐标</param>
        /// <param name="Sy">起点纵坐标</param>
        /// <param name="Ex">终点横坐标</param>
        /// <param name="Ey">终点纵坐标</param>
        public static void DrawStraitLineDDA(double Sx, double Sy, double Ex, double Ey)
        {
            if (Sx<Ex)//直线趋势向右
            {
                double y = Sy, k;
                k = (Ey - Sy) / (Ex - Sx);
                for (double x = Sx; x <= Ex; x++)
                {
                    CSys.SetDotLocInfor(new Point(x, y));
                    y = y + k;
                }
            }
            else if(Sx > Ex)//直线趋势向左
            {
                double k,tmpX,tmpY;
                tmpX = Sx;//互换输入起点终点的横坐标
                Sx = Ex;                    
                Ex = tmpX;
                tmpY = Sy;//互换输入起点终点的纵坐标
                Sy = Ey;
                Ey = tmpY;
                double y = Sy;
                k = (Ey - Sy) / (Ex - Sx);
                for (double x = Sx; x <= Ex; x++)
                {
                    CSys.SetDotLocInfor(new Point(x, y));
                    y = y + k;
                }
            }
            else//直线竖直
            {
                if (Sy<Ey)//从上往下画线
                {
                    double x = Sx;
                    for (double y = Sy; y <= Ey; y++)
                    {
                        CSys.SetDotLocInfor(new Point(x, y));
                    }
                }
                else//从下往上画线
                {
                    double tmpX, tmpY;
                    tmpX = Sx;//互换输入起点终点的横坐标
                    Sx = Ex;
                    Ex = tmpX;
                    tmpY = Sy;//互换输入起点终点的纵坐标
                    Sy = Ey;
                    Ey = tmpY;
                    double x = Sx;
                    for (double y = Sy; y <= Ey; y++)
                    {
                        CSys.SetDotLocInfor(new Point(x, y));
                    }
                }
            }
        }

        /// <summary>
        /// 双步画线法
        /// </summary>
        /// <param name="Sx">起点横坐标</param>
        /// <param name="Sy">起点纵坐标</param>
        /// <param name="Ex">终点横坐标</param>
        /// <param name="Ey">终点纵坐标</param>
        public static void TwoStepsDrawStraitLine(double Sx, double Sy, double Ex, double Ey)
        {
            double dx, dy, x=Sx, f,y=Sy,k;
            dx = Ex - Sx;
            dy = Ey - Sy;
            k = dy / dx;

            if (k>0 && !double.IsInfinity(k))//包含从左上到右下画线，右下到左上画线
            {
                if (dx>0 && dy>0)//从左上到右下画线
                {                        
                    #region k>0, dy>0, dx>0
                    if (k>0 && k<=0.5)
                    {
                        f = 4 * dy - dx;
                        CSys.SetDotLocInfor(new Point(Sx, Sy));
                        while (x < Ex)
                        {
                            if (f < 0)
                            {
                                CSys.SetDotLocInfor(new Point(x + 1, y));
                                CSys.SetDotLocInfor(new Point(x + 2, y));
                                f += 4 * dy;
                            }
                            else
                            {
                                if (f < 2 * dy)
                                {
                                    CSys.SetDotLocInfor(new Point(x + 1, y));
                                    CSys.SetDotLocInfor(new Point(x + 2, y + 1));
                                    y += 1;
                                }
                                else
                                {
                                    CSys.SetDotLocInfor(new Point(x + 1, y + 1));
                                    CSys.SetDotLocInfor(new Point(x + 2, y + 1));
                                    y += 1;
                                }
                                f += 4 * dy - 2 * dx;
                            }
                            x += 2;
                        }

                    }
                    else if(k<=1)
                    {
                        f = 4 * dy - 3 * dx;
                        CSys.SetDotLocInfor(new Point(Sx, Sy));

                        while (x < Ex)
                        {
                            if (f >= 0)
                            {
                                CSys.SetDotLocInfor(new Point(x + 1, y + 1));
                                CSys.SetDotLocInfor(new Point(x + 2, y + 2));
                                f += 4 * (dy - dx);
                                y += 2;
                            }
                            else
                            {
                                if (f < 2 * (dy - dx))
                                {
                                    CSys.SetDotLocInfor(new Point(x + 1, y));
                                    CSys.SetDotLocInfor(new Point(x + 2, y + 1));
                                    y += 1;
                                }
                                else
                                {
                                    CSys.SetDotLocInfor(new Point(x + 1, y + 1));
                                    CSys.SetDotLocInfor(new Point(x + 2, y + 1));
                                    y += 1;
                                }
                                f += 4 * dy - 2 * dx;
                            }
                            x += 2;
                        }
                    }
                    else//k>1
                    {

                    }
                    #endregion        
                }
                else//从右下到左上画线
                {
                    #region k>0, dy<0, dx<0
                    double tmpX, tmpY;
                    tmpX = Sx;//互换输入起点终点的横坐标
                    Sx = Ex;
                    Ex = tmpX;
                    tmpY = Sy;//互换输入起点终点的纵坐标
                    Sy = Ey;
                    Ey = tmpY;

                    dx = Ex - Sx;//重新给各个变量赋值
                    dy = Ey - Sy;
                    x = Sx;
                    y = Sy;
                    k = dy / dx;

                    if (k>=0 && k<=0.5)
                    {
                        f = 4 * dy - dx;
                        CSys.SetDotLocInfor(new Point(Sx, Sy));
                        while (x < Ex)
                        {
                            if (f < 0)
                            {
                                CSys.SetDotLocInfor(new Point(x + 1, y));
                                CSys.SetDotLocInfor(new Point(x + 2, y));
                                f += 4 * dy;
                            }
                            else
                            {
                                if (f < 2 * dy)
                                {
                                    CSys.SetDotLocInfor(new Point(x + 1, y));
                                    CSys.SetDotLocInfor(new Point(x + 2, y + 1));
                                    y += 1;
                                }
                                else
                                {
                                    CSys.SetDotLocInfor(new Point(x + 1, y + 1));
                                    CSys.SetDotLocInfor(new Point(x + 2, y + 1));
                                    y += 1;
                                }
                                f += 4 * dy - 2 * dx;
                            }
                            x += 2;
                        }
                    }
                    else if(k<=1)
                    {
                        f = 4 * dy - 3 * dx;
                        CSys.SetDotLocInfor(new Point(Sx, Sy));

                        while (x < Ex)
                        {
                            if (f >= 0)
                            {
                                CSys.SetDotLocInfor(new Point(x + 1, y + 1));
                                CSys.SetDotLocInfor(new Point(x + 2, y + 2));
                                f += 4 * (dy - dx);
                                y += 2;
                            }
                            else
                            {
                                if (f < 2 * (dy - dx))
                                {
                                    CSys.SetDotLocInfor(new Point(x + 1, y));
                                    CSys.SetDotLocInfor(new Point(x + 2, y + 1));
                                    y += 1;
                                }
                                else
                                {
                                    CSys.SetDotLocInfor(new Point(x + 1, y + 1));
                                    CSys.SetDotLocInfor(new Point(x + 2, y + 1));
                                    y += 1;
                                }
                                f += 4 * dy - 2 * dx;
                            }
                            x += 2;
                        }
                    }
                    else//k>1
                    {

                    }
                    #endregion
                }
            }
            else if(k<0 && !double.IsNegativeInfinity(k))//包含从左下到右上画线、右上到左下画线
            {
                if (dx>0 && dy<0)//从左下到右上画线
                {

                }
                else//从右上到左下画线
                {

                }
            }
            else if(k==0)//直线水平
            {
                if (Sx<=Ex)//自左往右画线
                {
                    for (x=Sx; x < Ex; x++)
                    {
                        CSys.SetDotLocInfor(new Point(x, y));
                    }
                }
                else//自右往左画线
                {
                    double tmpX;
                    tmpX = Sx;//互换输入起点终点的横坐标
                    Sx = Ex;
                    Ex = tmpX;

                    for (x = Sx; x < Ex; x++)
                    {
                        CSys.SetDotLocInfor(new Point(x, y));
                    }
                }
            }
            else//直线竖直
            {
                if (Sy<Ey)//自上往下画线
                {
                    for (y = Sy; y < Ey; y++)
                    {
                        CSys.SetDotLocInfor(new Point(x, y));
                    }
                }
                else//自下往上画线
                {
                    double tmpY;
                    tmpY = Sy;//互换输入起点终点的纵坐标
                    Sy = Ey;
                    Ey = tmpY;

                    x = Sx;
                    for (y = Sy; y < Ey; y++)
                    {
                        CSys.SetDotLocInfor(new Point(x, y));
                    }
                }
            }
        }

        /// <summary>
        /// Bresenham画线算法
        /// </summary>
        /// <param name="Sx">起点横坐标</param>
        /// <param name="Sy">起点纵坐标</param>
        /// <param name="Ex">终点横坐标</param>
        /// <param name="Ey">终点纵坐标</param>
        private static void BresenhamStraitLine(double Sx, double Sy, double Ex, double Ey)
        {
            double dx=Ex-Sx, dy=Ey-Sy, x=Sx, y=Sy, f=2*dy-dx , k=dy/dx;
            CSys.SetDotLocInfor(new Point(x, y));
            while(x < Ex)
            {
                if (f < 0)
                {
                    f += 2 * dy;
                }
                else
                {
                    f += 2 * (dy - dx);
                    y+=k;
                }
                x++;
                CSys.SetDotLocInfor(new Point(x, y));
            }
        }
    }
}
