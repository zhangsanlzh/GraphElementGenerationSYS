using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphElementGenerationSYS.Algorithm
{
    class RectangleAlgo
    {
        public static void RectangleNoFillAlgo()
        {
            RectangleNoFillAlgo(2, 2,5, 4);
        }

        public static void RectangleFillAlgo()
        {
            RectangleFillAlgo(2, 2, 5, 4);
        }

        /// <summary>
        /// 矩形生成算法-不填充
        /// </summary>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="Sx">矩形左上角点横坐标</param>
        /// <param name="Sy">矩形左上角点纵坐标</param>
        public static void RectangleNoFillAlgo(int Sx, int Sy,int width,int height)
        {
            CSys.SetDotLocInfor(new Point(Sx,Sy));
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (j==0||j==height-1||i==0||i==width-1)
                    {
                        CSys.SetDotLocInfor(new Point(Sx+i, Sy+j));
                    }
                }                        
            }
        }

        /// <summary>
        /// 矩形生成算法-填充
        /// </summary>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="Sx">矩形左上角点横坐标</param>
        /// <param name="Sy">矩形左上角点纵坐标</param>
        public static void RectangleFillAlgo(int Sx, int Sy, int width, int height)
        {
            CSys.SetDotLocInfor(new Point(Sx, Sy));
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    CSys.SetDotLocInfor(new Point(Sx + i, Sy + j));
                }
            }
        }


    }
}
