using System;

namespace GraphElementGenerationSYS.Algorithm
{
    class TransformAlgo
    {
        /// <summary>
        /// 设置待平移的线的长度
        /// </summary>
        private static int TranslationLinelength;

        /// <summary>
        /// 设置待平移的距离
        /// </summary>
        private static int TranslationDistance;

        /// <summary>
        /// 设置平移的初态
        /// </summary>
        /// <param name="length">待平移的线的长度</param>
        /// <param name="distance">待平移的距离</param>
        public static void SetTranslationStartState(int length,int distance)
        {
            TranslationLinelength = length;
            TranslationDistance = distance;

            StraitLineAlgo.DrawStraitLineDDA(new pointLoc(0, 0), new pointLoc(0, length));            
        }

        /// <summary>
        /// 开始平移
        /// </summary>
        public static void BeginTranslation()
        {
            for (int i = 0; i < TranslationDistance; i++)
            {
                CSys.RefreshCordinateSys();
                StraitLineAlgo.DrawStraitLineDDA(new pointLoc(i + 1, 0), new pointLoc(i + 1, TranslationLinelength));
                CSys.DrawDots();
            }
        }

        /// <summary>
        /// 设置旋转初态。此演示项目的初态为一条水平的直线
        /// </summary>
        /// <param name="length">线的长度</param>
        public static void SetRotationStartState(int Linelength)
        {
            pointLoc[] points = new pointLoc[4];//声明若干个点

            points[0] = new pointLoc(20, 0);//为点赋值
            points[1] = new pointLoc(20, 10);
            points[2] = new pointLoc(35, 10);
            points[3] = new pointLoc(35, 0);

            PolygonAlgo.CreateGenericPolygon(points);
        }

        /// <summary>
        /// 开始旋转。旋转的方向为顺时针
        /// </summary>
        /// <param name="angle">旋转的角度</param>
        public static void BeginRotate(double angle)
        {
            for (int i = 0; i < CSys.CellNum; i++)
            {
                for (int j = 0; j < CSys.CellNum; j++)
                {
                    if (CSys.CanvasDotsArray[i,j]==1)
                    {
                        double x = i * Math.Cos(angle) - j * Math.Sin(angle);
                        double y = j * Math.Cos(angle) + i * Math.Sin(angle);
                        
                        CSys.SetDotLocInfor(new System.Windows.Point(Math.Floor(x), Math.Floor(y)));
                    }
                }
            }

            CSys.DrawDots();
        }
    }
}
