using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphElementGenerationSYS.Algorithm
{
    class CircleAlgo//圆和椭圆
    {
        #region 圆
        /// <summary>
        /// 中点画圆算法-可被显式调用
        /// </summary>
        public static void MidpointCircleAlgo()
        {
            MidpointCircleAlgo(3, 4, 4);
        }

        /// <summary>
        /// Bresenham画圆算法-可被显式调用
        /// </summary>
        public static void BresenhamCircleAlgo()
        {
            BresenhamCircleAlgo(3, 4, 4);
        }

        /// <summary>
        /// 正负判定画圆算法--可被显式调用
        /// </summary>
        public static void PosiAndNegaCircleAlgo()
        {
            PosiAndNegaCircleAlgo(3, 4, 4);

        }

        /// <summary>
        /// 快速画圆算法--可被显式调用
        /// </summary>
        public static void QuickCircleAlgo()
        {
            QuickCircleAlgo(3, 4, 4);
        }

        #region 画圆算法-不被显式调用
        /// <summary>
        /// 中点画圆算法
        /// </summary>
        /// <param name="r">圆半径</param>
        /// <param name="Cx">圆心横坐标</param>
        /// <param name="Cy">圆心纵坐标</param>
        private static void MidpointCircleAlgo(double r, double Cx, double Cy)
        {
            double x = 0;
            double y = r;
            double d = 1 - r;
            SetPointsLocInfor(Cx, Cy, x, y);
            while (x < y)
            {
                x++;
                if (d < 0)
                {
                    d += 2 * x + 1;
                }
                else
                {
                    y--;
                    d += 2 * (x - y) + 1;
                }
                SetPointsLocInfor(Cx, Cy, x, y);
            }
        }

        /// <summary>
        /// Bresenham画圆算法-改进的中点画圆算法
        /// </summary>
        /// <param name="r">圆半径</param>
        /// <param name="Cx">圆心横坐标</param>
        /// <param name="Cy">圆心纵坐标</param>
        private static void BresenhamCircleAlgo(double r, double Cx, double Cy)
        {
            double x = 0;
            double y = r;
            double d = 3 - 2 * r;
            SetPointsLocInfor(Cx, Cy, x, y);
            while (x < y)
            {
                if (d < 0)
                {
                    d += 4 * x + 6;
                }
                else
                {
                    d += 4 * (x - y) + 10;
                    y--;
                }
                x++;
                SetPointsLocInfor(Cx, Cy, x, y);
            }
        }

        /// <summary>
        /// 正负判定画圆算法
        /// </summary>
        /// <param name="r">圆半径</param>
        /// <param name="Cx">圆心横坐标</param>
        /// <param name="Cy">圆心纵坐标</param>
        private static void PosiAndNegaCircleAlgo(double r, double Cx, double Cy)
        {
            double x = 0;
            double y = r;
            double f = 0;
            while (x <= y)
            {
                SetPointsLocInfor(Cx, Cy, x, y);
                if (f <= 0)
                {
                    f += 2 * x + 1;
                    x++;
                }
                else
                {
                    f -= 2 * y + 1;
                    y--;
                }
            }
        }

        /// <summary>
        /// 快速画圆算法-无任何乘法操作的画圆算法
        /// </summary>
        /// <param name="r">圆半径</param>
        /// <param name="Cx">圆心横坐标</param>
        /// <param name="Cy">圆心纵坐标</param>
        private static void QuickCircleAlgo(double r, double Cx, double Cy)
        {
            double x = 0;
            double y = r;
            double d = -r/2;
            SetPointsLocInfor(Cx, Cy, x, y);

            if (r%2==0)
            {
                while (x < y)
                {
                    x++;
                    if (d < 0)
                    {
                        d +=  x;
                    }
                    else
                    {
                        y--;
                        d += x- y;
                    }
                    SetPointsLocInfor(Cx, Cy, x, y);
                }
            }
            else
            {
                while (x < y)
                {
                    x++;
                    if (d < 0)
                    {
                        d += x+1;
                    }
                    else
                    {
                        y--;
                        d += x - y+1;
                    }
                    SetPointsLocInfor(Cx, Cy, x, y);
                }
            }
        }

        #endregion

        #region 画圆算法内部调用-不被显式调用
        /// <summary>
        /// 中点画圆算法设置点的位置信息
        /// </summary>
        /// <param name="Cx">圆心横坐标</param>
        /// <param name="Cy">圆心纵坐标</param>
        private static void SetPointsLocInfor(double Cx, double Cy, double x, double y)
        {
            CSys.SetDotLocInfor(new Point(Cx,Cy));
            CSys.SetDotLocInfor(new Point(Cx + x, Cy + y));
            CSys.SetDotLocInfor(new Point(Cx - x, Cy + y));
            CSys.SetDotLocInfor(new Point(Cx + x, Cy - y));
            CSys.SetDotLocInfor(new Point(Cx - x, Cy - y));
            CSys.SetDotLocInfor(new Point(Cx + y, Cy + x));
            CSys.SetDotLocInfor(new Point(Cx - y, Cy + x));
            CSys.SetDotLocInfor(new Point(Cx + y, Cy - x));
            CSys.SetDotLocInfor(new Point(Cx - y, Cy - x));
        }
        #endregion

        #endregion

        #region 椭圆
        /// <summary>
        /// 中点椭圆算法-可被外部显式调用
        /// </summary>
        public static void MidpointEllipseAlgo()
        {
            MidpointEllipseAlgo(4,4,4,2);
        }

        /// <summary>
        /// Bresenham椭圆算法-可被外部显式调用
        /// </summary>
        public static void BresenhamEllipseAlgo()
        {
            BresenhamEllipseAlgo(4,4,4,2);
        }


        /// <summary>
        /// 中点椭圆算法-不可被外部显式调用
        /// </summary>
        /// <param name="Cx">椭圆中心横坐标</param>
        /// <param name="Cy">椭圆中心纵坐标</param>
        /// <param name="a">椭圆长半轴-（横轴上）</param>
        /// <param name="b">椭圆短半轴-（纵轴上）</param>
        private static void MidpointEllipseAlgo(double Cx,double Cy,double a,double b)
        {
            double sqa = a * a;
            double sqb = b * b;
            double d = sqb + sqa * (-b + 0.25);
            double x = 0;
            double y = b;
            EllipsePlot(Cx, Cy, x, y);
            while (sqb * (x + 1) < sqa * (y - 0.5))
            {
                if (d < 0)
                {
                    d += sqb * (2 * x + 3);
                }
                else  
                {
                    d += (sqb * (2 * x + 3) + sqa * (-2 * y + 2));
                    y--;
                }
                x++;
                EllipsePlot(Cx, Cy, x, y);
            }
            d = (b * (x + 0.5)) * 2 + (a * (y - 1)) * 2 - (a * b) * 2;
            while (y > 0)
            {
                if (d < 0)
                {
                    d += sqb * (2 * x + 2) + sqa * (-2 * y + 3);
                    x++;
                }
                else  
                {
                    d += sqa * (-2 * y + 3);
                }
                y--;
                EllipsePlot(Cx, Cy, x, y);
            }
        }

        /// <summary>
        /// Bresenham椭圆算法-不可被外部显式调用
        /// </summary>
        /// <param name="Cx">椭圆中心横坐标</param>
        /// <param name="Cy">椭圆中心纵坐标</param>
        /// <param name="a">椭圆长半轴-（横轴上）</param>
        /// <param name="b">椭圆短半轴-（纵轴上）</param>
        private static void BresenhamEllipseAlgo(double Cx, double Cy, double a, double b)
        {
            double sqa = a * a;
            double sqb = b * b;
            double x = 0;
            double y = b;
            double d = 2 * sqb - 2 * b * sqa + sqa;
            EllipsePlot(Cx, Cy, x, y);
            while (x<=(sqa / Math.Sqrt(sqa + sqb)))
            {
                if (d < 0)
                {
                    d += 2*sqb * (2 * x + 3);
                }
                else
                {
                    d += 2*sqb * (2 * x + 3) - 4*sqa * ( y - 1);
                    y--;
                }
                x++;
                EllipsePlot(Cx, Cy, x, y);
            }
            d = sqb * (x * x + x) + sqa * (y * y - y) - sqa * sqb;
            while (y >= 0)
            {
                EllipsePlot(Cx, Cy, x, y);
                y--;
                if (d < 0)
                {
                    x++;
                    d = d - 2 * sqa * y - sqa + 2 * sqb * x + 2 * sqb;
                }
                else
                {
                    d = d - 2 * sqa * y - sqa;
                }
            }
        }

        #region 椭圆生成算法内部调用-不被外部显式调用
        private static void EllipsePlot(double cx, double cy, double x, double y)
        {
            CSys.SetDotLocInfor(new Point(cx, cy));
            CSys.SetDotLocInfor(new Point(cx + x, cy + y));
            CSys.SetDotLocInfor(new Point(cx - x, cy + y));
            CSys.SetDotLocInfor(new Point(cx + x, cy - y));
            CSys.SetDotLocInfor(new Point(cx - x, cy - y));
        }
        #endregion

        #endregion
    }
}
