using System;

namespace GraphElementGenerationSYS.Algorithm
{
    /// <summary>
    /// 用于存储点坐标信息的结构
    /// </summary>
    struct pointLoc
    {
        public double x;//点的横坐标
        public double y;//点的纵坐标

        public pointLoc(double x,double y)//构造方法
        {
            this.x = x;
            this.y = y;
        }
    }

    class PolygonAlgo
    {
        /// <summary>
        /// 创建正三角形
        /// </summary>
        public static void RegularTriangle()
        {
            RegularTriangleFixedTopPoint(25, 25, 10);
        }

        /// <summary>
        /// 创建正方形
        /// </summary>
        public static void CreateSquare()
        {
            CreateSquare(25, 15, 10);
        }

        /// <summary>
        /// 创建任意个定点的多边形
        /// </summary>
        public static void CreateGenericPolygon()
        {
            pointLoc [] points = new pointLoc[4];//声明若干个点

            points[0]=new pointLoc(15,10);//为点赋值
            points[1]=new pointLoc(35,10);
            points[2]=new pointLoc(15,35);
            points[3]=new pointLoc(35,35);

            CreateGenericPolygon(points);//创建示例多边形
        }

        #region 内部方法
        /// <summary>
        /// 顶点画三角形法。此方法画出的三角形边长比需得到的底边略长。
        /// </summary>
        /// <param name="edgeLength">待画的三角形边长</param>
        /// <param name="Sx">顶点横坐标</param>
        /// <param name="Sy">顶点横坐标</param>
        private static void RegularTriangleFixedTopPoint(double edgeLength,double Sx,double Sy)
        {
            double length=Math.Round(edgeLength);//得到最接近输入边长的近似边长

            double x1, y1, x2, y2;//x1,y1是左侧点的横纵坐标值，x2,y2是右侧点的横纵坐标值。左右是相对于正三角形顶点而言的
            x1 = Math.Round(Sx - length / 2);//计算另外两个点的坐标,并将其转换为最接近的整数坐标值
            y1 = Math.Round(Sy + Math.Sqrt(3) * length / 2);
            x2 = Math.Round(Sx + length / 2);
            y2 = Math.Round(Sy + Math.Sqrt(3) * length / 2);

            StraitLineAlgo.DrawStraitLineDDA(Sx, Sy, x1, y1);//逆时针方向连接三点
            StraitLineAlgo.DrawStraitLineDDA(x1, y1, x2, y2);
            StraitLineAlgo.DrawStraitLineDDA(x2, y2, Sx, Sy);
        }

        /// <summary>
        /// 固定底边画三角形法。
        /// </summary>
        /// <param name="edgeLength">待画的三角形边长</param>
        /// <param name="Sx">底边左端定点横坐标</param>
        /// <param name="Sy">底边左端定点纵坐标</param>
        private static void RegularTriangleFixedBottomEdge(double edgeLength,double Sx,double Sy)
        {
            double length = Math.Round(edgeLength);//得到最接近输入边长的近似边长

            double x0, y0, x2, y2;//x0,y0是顶点的横纵坐标值，x2,y2是右侧顶点的横纵坐标值。左右是相对于正三角形顶点而言的
            x0 = Math.Round(Sx + length / 2);//计算另外两个点的坐标,并将其转换为最接近的整数坐标值

            y0 = Math.Round(Sy - Math.Sqrt(3) * length / 2);
            x2 = Math.Round(Sx + length);
            y2 = Sy;

            StraitLineAlgo.DrawStraitLineDDA(Sx, Sy, x2, y2);//逆时针方向连接三点
            StraitLineAlgo.DrawStraitLineDDA(x2, y2, x0, y0);
            StraitLineAlgo.DrawStraitLineDDA(x0, y0, Sx, Sy);
        }

        /// <summary>
        /// 画正方形。
        /// </summary>
        /// <param name="edgeLength">正方形边长</param>
        /// <param name="Sx">正方形左上角横坐标</param>
        /// <param name="Sy">正方形左上角纵坐标</param>
        private static void CreateSquare(int edgeLength, int Sx, int Sy)
        {
            //因为正方形是特殊的矩形，故此方法调用RectangleAlgo类，但增加了耦合程度。
            RectangleAlgo.RectangleNoFillAlgo(Sx,Sy,edgeLength,edgeLength);
        }

        /// <summary>
        /// 画任意个定点的多边形
        /// </summary>
        /// <param name="pointLoc">存储了多个定点信息的pointLoc型数组</param>
        public static void CreateGenericPolygon(pointLoc[] pointLocArr) 
        {
            int polyNum = pointLocArr.Length;//顶点数

            //连接各个点
            for (int i = 0; i < pointLocArr.Length; i++)
            {
                if (i + 1 < pointLocArr.Length)
                {
                    StraitLineAlgo.DrawStraitLineDDA(pointLocArr[i], pointLocArr[i + 1]);
                }
                else
                {
                    StraitLineAlgo.DrawStraitLineDDA(pointLocArr[i], pointLocArr[0]);//闭合首尾
                }
            }
        }

        #endregion

    }
}
