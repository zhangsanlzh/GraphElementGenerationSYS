using System.Drawing;
using System.IO;
using System.Windows;

namespace GraphElementGenerationSYS.Algorithm
{
    class CharacterAlgo
    {
        #region 英文字符
        #region A/G-Consolas
        /// <summary>
        /// 生成字母A/a
        /// </summary>
        public static void A()
        {
            LoadBmpFile(@"images/Aa.bmp");
        }

        /// <summary>
        /// 生成字母B/b
        /// </summary>
        public static void B()
        {
            LoadBmpFile(@"images/Bb.bmp");
        }

        /// <summary>
        /// 生成字母C/c
        /// </summary>
        public static void C()
        {
            LoadBmpFile(@"images/Cc.bmp");
        }

        /// <summary>
        /// 生成字母D/d
        /// </summary>
        public static void D()
        {
            LoadBmpFile(@"images/Dd.bmp");
        }

        /// <summary>
        /// 生成字母E/e
        /// </summary>
        public static void E()
        {
            LoadBmpFile(@"images/Ee.bmp");
        }

        /// <summary>
        /// 生成字母F/f
        /// </summary>
        public static void F()
        {
            LoadBmpFile(@"images/Ff.bmp");
        }

        /// <summary>
        /// 生成字母G/g
        /// </summary>
        public static void G()
        {
            LoadBmpFile(@"images/Gg.bmp");
        }

        #endregion

        #region H/N-Gabriola
        /// <summary>
        /// 生成字母H/h
        /// </summary>
        public static void H()
        {
            LoadBmpFile(@"images/Hh.bmp");
        }
        /// <summary>
        /// 生成字母I/i
        /// </summary>
        public static void I()
        {
            LoadBmpFile(@"images/Ii.bmp");
        }
        /// <summary>
        /// 生成字母J/j
        /// </summary>
        public static void J()
        {
            LoadBmpFile(@"images/Jj.bmp");
        }
        /// <summary>
        /// 生成字母K/k
        /// </summary>
        public static void K()
        {
            LoadBmpFile(@"images/Kk.bmp");
        }
        /// <summary>
        /// 生成字母L/l
        /// </summary>
        public static void L()
        {
            LoadBmpFile(@"images/Ll.bmp");
        }
        /// <summary>
        /// 生成字母M/m
        /// </summary>
        public static void M()
        {
            LoadBmpFile(@"images/Mm.bmp");
        }
        /// <summary>
        /// 生成字母N/n
        /// </summary>
        public static void N()
        {
            LoadBmpFile(@"images/Nn.bmp");
        }
        #endregion

        #region O/Q-Segoe Print字体
        /// <summary>
        /// 生成字母O/o
        /// </summary>
        public static void O()
        {
            LoadBmpFile(@"images/Oo.bmp");
        }

        /// <summary>
        /// 生成字母P/p
        /// </summary>
        public static void P()
        {
            LoadBmpFile(@"images/Pp.bmp");
        }

        /// <summary>
        /// 生成字母Q/q
        /// </summary>
        public static void Q()
        {
            LoadBmpFile(@"images/Qq.bmp");
        }

        #endregion

        #region R/T-Hobo Std字体
        /// <summary>
        /// 生成字母R/r
        /// </summary>
        public static void R()
        {
            LoadBmpFile(@"images/Rr.bmp");
        }

        /// <summary>
        /// 生成字母S/s
        /// </summary>
        public static void S()
        {
            LoadBmpFile(@"images/Ss.bmp");
        }

        /// <summary>
        /// 生成字母T/t
        /// </summary>
        public static void T()
        {
            LoadBmpFile(@"images/Tt.bmp");
        }

        #endregion

        #region U/W-Verdana字体
        /// <summary>
        /// 生成字母U/u
        /// </summary>
        public static void U()
        {
            LoadBmpFile(@"images/Uu.bmp");
        }

        /// <summary>
        /// 生成字母V/v
        /// </summary>
        public static void V()
        {
            LoadBmpFile(@"images/Vv.bmp");
        }

        /// <summary>
        /// 生成字母W/w
        /// </summary>
        public static void W()
        {
            LoadBmpFile(@"images/Ww.bmp");
        }

        #endregion

        #region X/Z-Letter Gothic Std字体
        /// <summary>
        /// 生成字母X/x
        /// </summary>
        public static void X()
        {
            LoadBmpFile(@"images/Xx.bmp");
        }

        /// <summary>
        /// 生成字母Y/y
        /// </summary>
        public static void Y()
        {
            LoadBmpFile(@"images/Yy.bmp");
        }

        /// <summary>
        /// 生成字母Z/z
        /// </summary>
        public static void Z()
        {
            LoadBmpFile(@"images/Zz.bmp");
        }

        #endregion

        #endregion

        #region 特殊字符
        /// <summary>
        /// 特殊字符
        /// </summary>
        public static void SpecialCharacters()
        {
            LoadBmpFile(@"images/SpecialCharacters.bmp");
        }
        #endregion

        #region 汉字

        #region 富强民主 文明和谐
        public static void ChineseCharacters0()
        {
            LoadBmpFile(@"images\ChineseCharacters0.bmp");
        }
        public static void ChineseCharacters1()
        {
            LoadBmpFile(@"images\ChineseCharacters1.bmp");
        }
        public static void ChineseCharacters2()
        {
            LoadBmpFile(@"images\ChineseCharacters2.bmp");
        }
        public static void ChineseCharacters3()
        {
            LoadBmpFile(@"images\ChineseCharacters3.bmp");
        }
        public static void ChineseCharacters4()
        {
            LoadBmpFile(@"images\ChineseCharacters4.bmp");
        }
        public static void ChineseCharacters5()
        {
            LoadBmpFile(@"images\ChineseCharacters5.bmp");
        }
        public static void ChineseCharacters6()
        {
            LoadBmpFile(@"images\ChineseCharacters6.bmp");
        }
        public static void ChineseCharacters7()
        {
            LoadBmpFile(@"images\ChineseCharacters7.bmp");
        }

        #endregion

        #region 自由平等 公正法制
        public static void ChineseCharacters8()
        {
            LoadBmpFile(@"images\ChineseCharacters8.bmp");
        }
        public static void ChineseCharacters9()
        {
            LoadBmpFile(@"images\ChineseCharacters9.bmp");
        }
        public static void ChineseCharacters10()
        {
            LoadBmpFile(@"images\ChineseCharacters10.bmp");
        }
        public static void ChineseCharacters11()
        {
            LoadBmpFile(@"images\ChineseCharacters11.bmp");
        }
        public static void ChineseCharacters12()
        {
            LoadBmpFile(@"images\ChineseCharacters12.bmp");
        }
        public static void ChineseCharacters13()
        {
            LoadBmpFile(@"images\ChineseCharacters13.bmp");
        }
        public static void ChineseCharacters14()
        {
            LoadBmpFile(@"images\ChineseCharacters14.bmp");
        }
        public static void ChineseCharacters15()
        {
            LoadBmpFile(@"images\ChineseCharacters15.bmp");
        }

        #endregion

        #region 爱国敬业 诚信友善
        public static void ChineseCharacters16()
        {
            LoadBmpFile(@"images\ChineseCharacters16.bmp");
        }
        public static void ChineseCharacters17()
        {
            LoadBmpFile(@"images\ChineseCharacters17.bmp");
        }
        public static void ChineseCharacters18()
        {
            LoadBmpFile(@"images\ChineseCharacters18.bmp");
        }
        public static void ChineseCharacters19()
        {
            LoadBmpFile(@"images\ChineseCharacters19.bmp");
        }
        public static void ChineseCharacters20()
        {
            LoadBmpFile(@"images\ChineseCharacters20.bmp");
        }
        public static void ChineseCharacters21()
        {
            LoadBmpFile(@"images\ChineseCharacters21.bmp");
        }
        public static void ChineseCharacters22()
        {
            LoadBmpFile(@"images\ChineseCharacters22.bmp");
        }
        public static void ChineseCharacters23()
        {
            LoadBmpFile(@"images\ChineseCharacters23.bmp");
        }

        #endregion


        #endregion

        /// <summary>
        /// 加载指定图像文件,此函数仅供内部类调用
        /// </summary>
        /// <param name="fileName">文件路径。如@"xx/xx/xx.bmp"</param>
        private static void LoadBmpFile(string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);
            Color color;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);

                    if (color.Name != "ffffffff")
                    {
                        CSys.SetDotLocInfor(new System.Windows.Point(i, j));
                    }
                }
            }
        }
    }
}
