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
        /// 待旋转的线的长度
        /// </summary>
        private static int RotationLinelength;

        /// <summary>
        /// 设置旋转初态。此演示项目的初态为一条水平的直线
        /// </summary>
        /// <param name="length">线的长度</param>
        public static void SetRotationStartState(int Linelength)
        {
            RotationLinelength = Linelength;
            StraitLineAlgo.DrawStraitLineDDA(new pointLoc(0, 0), new pointLoc(Linelength, 0));
        }

        /// <summary>
        /// 开始旋转。旋转的方向为顺时针
        /// </summary>
        /// <param name="angle">旋转的角度</param>
        public static void BeginRotate(double angle)
        {
            CSys.RefreshCordinateSys();
            double Ex = RotationLinelength * Math.Round(Math.Cos(angle));
            double Ey = RotationLinelength * Math.Round(Math.Sin(angle));
            StraitLineAlgo.DrawStraitLineDDA(new pointLoc(0, 0), new pointLoc(Ex, Ey));
            CSys.DrawDots();
        }
    }
}
