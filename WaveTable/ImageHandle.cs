/***********************************************************************/
//
//      名称：  WaveTable
//      功能：  模仿FlashGet MINI波表板式悬浮窗
//      作者：  UCan
//      日期：  二〇〇八年十月十八日
//      Email： 551881869@QQ.com
//      未经允许，严禁用于商业用途
//
/***********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace WaveTable
{
    class ImageHandle
    {
     static   int  Width,Height;
        public static void chushihua(Bitmap sourceBitmap,int imageNumbers, int index)
        {
          Width = sourceBitmap.Width / imageNumbers;
          Height = sourceBitmap.Height;
        }
        public static Bitmap Image(Bitmap sourceBitmap)
        {
                Bitmap returnBitMap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                Graphics drawCanvas = Graphics.FromImage(returnBitMap);
                //#warning Just For a Test
                //                drawCanvas.Clear(Color.FromArgb(255, 0, 0, 0));
               //drawCanvas.DrawImage(sourceBitmap, new Rectangle(0, 0, Width, Height),new Rectangle(Width , 0, Width, Height), GraphicsUnit.Pixel);
                return (returnBitMap);     
        }




        /// <summary>
        /// 剪切给定图片
        /// sourceBitmap指定所需要剪切的图片
        /// imageNumbers指定将所需要剪切的图片分为几份
        /// index指定返回剪切后图片的索引号，注：索引号从0开始
        /// </summary>
        /// <param name="sourcebitmap"></param>
        /// <param name="imagenumbers"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Bitmap CutImage(Bitmap sourceBitmap, int imageNumbers, int index)
        {
            if ((imageNumbers > 0) && (index >= 0) && (index < imageNumbers))
            {
                int cutImageWidth, cutImageHeight;
                cutImageWidth = sourceBitmap.Width / imageNumbers;
                cutImageHeight = sourceBitmap.Height;

                Bitmap returnBitMap = new Bitmap(cutImageWidth, cutImageHeight, PixelFormat.Format32bppArgb);
                Graphics drawCanvas = Graphics.FromImage(returnBitMap);
//#warning Just For a Test
//                drawCanvas.Clear(Color.FromArgb(255, 0, 0, 0));
                drawCanvas.DrawImage(sourceBitmap, new Rectangle(0, 0, cutImageWidth, cutImageHeight),
                                     new Rectangle(cutImageWidth * index, 0, cutImageWidth, cutImageHeight), GraphicsUnit.Pixel);
                return (returnBitMap);
            }
            else
            {
                throw new Exception("参数不正确,你可能得不到所需要的剪切效果！");
            }
            /*Old Version Snippet
             * return sourceBitmap.Clone(new Rectangle(sourceBitmap.Width * index / imageNumbers, 0,
                                                      sourceBitmap.Width / imageNumbers, sourceBitmap.Height),
             *                          PixelFormat.Format32bppArgb);*/
        }


        /// <summary>
        /// 以图片中心为参考点缩放图片，并不改变原始图片长宽比
        /// sourceBitmap指定所需要放缩的图片
        /// newWidth指定放缩后图片新的宽度
        /// newHeight指定缩放后图片新的高度，注：新的宽度高度不能小于零，否则会抛出异常
        /// </summary>
        /// <param name="sourceimage"></param>
        /// <param name="newwidth"></param>
        /// <param name="newheight"></param>
        /// <returns></returns>
        public static Bitmap ZoomImage(Bitmap sourceBitmap, int newWidth, int newHeight)
        {
            Bitmap returnBitMap = new Bitmap(sourceBitmap.Width,sourceBitmap.Height, PixelFormat.Format32bppArgb);
            Graphics drawCanvas = Graphics.FromImage(returnBitMap);
//#warning Just For a Test
//            drawCanvas.Clear(Color.FromArgb(255, 0, 0, 0));
            if ((newWidth > 0) && (newHeight > 0))
            {
                drawCanvas.DrawImage(sourceBitmap,
                                     new Rectangle((sourceBitmap.Width - newWidth) / 2, (sourceBitmap.Height - newHeight) / 2, 
                                                   newWidth, newHeight));
                return (returnBitMap);
            }
            else
            {
                throw new Exception("图片分辨率不能小于等于零！");
            }
        }


        /// <summary>
        /// 将图片均分成若干份，每一份成为一帧
        /// sourceBitmap指定要均分的图片
        /// frameNumbers指定要均分成多少份，注：帧数不能小于0
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <param name="frameNumbers"></param>
        /// <returns></returns>
        public static Bitmap[] MakeActImamgeFrame(Bitmap sourceBitmap, int frameNumbers)
        {
            if (frameNumbers>0)
            {
                Bitmap[] returnBitmap = new Bitmap[frameNumbers];
                for (int i = 0; i < frameNumbers; i++)
                    returnBitmap[i] = CutImage(sourceBitmap, frameNumbers, i);
                return returnBitmap;
            }
            else
            {
                throw new Exception("图片帧数过少！");
            }
            
        }

        /// <summary>
        /// 制作缩放的动画帧
        /// sourceBitmap指定制作动画帧的原始图片
        /// pix指定每一帧之间的像素差，当pix大于0时，只缩小的动画帧；pix小于0时制作的是放大的动画帧
        /// frameNumbers指定有多少帧
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <param name="pix"></param>
        /// <param name="frameNumbers"></param>
        /// <returns></returns>
        public static Bitmap[] MakeZoomImageFrame(Bitmap sourceBitmap, int pix, int frameNumbers)
        {
            if ((sourceBitmap.Width - (frameNumbers - 1) * pix > 0) && (sourceBitmap.Height - (frameNumbers - 1) * pix > 0) && (frameNumbers > 1) && (pix != 0))
            {
                Bitmap[] returnBitmap = new Bitmap[2 * frameNumbers - 1];

                for (int i = 0; i < frameNumbers; i++)
                {
                    returnBitmap[i] = ImageHandle.ZoomImage(sourceBitmap, sourceBitmap.Width - i * pix, sourceBitmap.Height - i * pix);
                }
                for (int i = frameNumbers; i < 2 * frameNumbers - 1; i++)
                {
                    returnBitmap[i] = ImageHandle.ZoomImage(sourceBitmap, sourceBitmap.Width - (frameNumbers - 1) * pix + (i - frameNumbers + 1) * pix,
                                                            sourceBitmap.Height - (frameNumbers - 1) * pix + (i - frameNumbers + 1) * pix);
                }
                return returnBitmap;
            }
            else
            {
                throw new Exception("帧数太少，或某一帧中像素为零！");
            }

        }



        /// <summary>
        /// 以原图片中心为坐标原点，旋转图片
        /// sourceBitmap指定所需要旋转的图片
        /// angle指定旋转的角度
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Bitmap CircumvolveImage(Bitmap sourceBitmap, float angle)
        {
            float widthMove=Convert.ToSingle(sourceBitmap.Width) / 2;
            float heightMove=Convert.ToSingle(sourceBitmap.Height) / 2;

            Bitmap returnBitMap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);
            Graphics drawCanvas = Graphics.FromImage(returnBitMap);
//#warning Just For a Test
//            drawCanvas.Clear(Color.FromArgb(255, 0, 0, 0));

            drawCanvas.TranslateTransform(widthMove, heightMove);
            drawCanvas.RotateTransform(angle);

            drawCanvas.DrawImage(sourceBitmap, -widthMove, -heightMove);            
            return returnBitMap;
        }
    }
}
