using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DrawStraitLineDDA(4, 0, 0, 4);
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
        /// 中点画线
        /// </summary>
        public static void CenterStraitLine()
        {
            CenterStraitLine(0, 0, 5, 5);
        }

        /// <summary>
        /// 中点画线法
        /// </summary>
        /// <param name="Sx">起点横坐标</param>
        /// <param name="Sy">起点纵坐标</param>
        /// <param name="Ex">终点横坐标</param>
        /// <param name="Ey">终点纵坐标</param>
        public static void CenterStraitLine(double Sx, double Sy, double Ex, double Ey)
        {
            if (Sx < Ex)//直线趋势向右
            {
                double x, y, d0, d1, d2, a, b;
                y = Sy;
                a = Sy - Ey;          //直线方程中的a的算法
                b = Ex - Sx;          //直线方程中的b的算法
                d0 = 2 * a + b;         //增量初始值
                d1 = 2 * a;           //当>=0时的增量
                d2 = 2 * (a + b);       //当<0时的增量
                for (x = Sx; x <= Ex; x++)
                {
                    CSys.SetDotLocInfor(new Point(x, y));
                    if (d0 < 0)
                    {
                        y++;
                        d0 += d2;
                    }
                    else
                    {
                        d0 += d1;
                    }
                }
            }
            else
            {
                double tmpX, tmpY;
                tmpX = Sx;//互换输入起点终点的横坐标
                Sx = Ex;
                Ex = tmpX;
                tmpY = Sy;//互换输入起点终点的纵坐标
                Sy = Ey;
                Ey = tmpY;

                double x, y, d0, d1, d2, a, b;
                y = Sy;
                a = Sy - Ey;          //直线方程中的a的算法
                b = Ex - Sx;          //直线方程中的b的算法
                d0 = 2 * a + b;         //增量初始值
                d1 = 2 * a;           //当>=0时的增量
                d2 = 2 * (a + b);       //当<0时的增量
                for (x = Sx; x <= Ex; x++)
                {
                    CSys.SetDotLocInfor(new Point(x, y));
                    if (d0 < 0)
                    {
                        y++;
                        d0 += d2;
                    }
                    else
                    {
                        d0 += d1;
                    }
                }
            }
        }

        /// <summary>
        /// Bresenham画线
        /// </summary>
        public static void BresenhamStraitLine()
        {
            BresenhamStraitLine(0, 0, 5, 5);
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
            double x, y, dx, dy, d;
            y = Sy;
            dx = Ex - Sx;
            dy = Ey - Sy;
            d = 2 * dy - dx;        //增量d的初始值
            for (x = Sx; x <= Ex; x++)
            {
                CSys.SetDotLocInfor(new Point(x, y));
                if (d < 0)
                {
                    d += 2 * dy;
                }
                else
                {
                    y++;
                    d += 2 * dy - 2 * dx;
                }
            }
        }


    }
}
