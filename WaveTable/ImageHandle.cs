/***********************************************************************/
//
//      ���ƣ�  WaveTable
//      ���ܣ�  ģ��FlashGet MINI�����ʽ������
//      ���ߣ�  UCan
//      ���ڣ�  ����������ʮ��ʮ����
//      Email�� 551881869@QQ.com
//      δ�������Ͻ�������ҵ��;
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
        /// ���и���ͼƬ
        /// sourceBitmapָ������Ҫ���е�ͼƬ
        /// imageNumbersָ��������Ҫ���е�ͼƬ��Ϊ����
        /// indexָ�����ؼ��к�ͼƬ�������ţ�ע�������Ŵ�0��ʼ
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
                throw new Exception("��������ȷ,����ܵò�������Ҫ�ļ���Ч����");
            }
            /*Old Version Snippet
             * return sourceBitmap.Clone(new Rectangle(sourceBitmap.Width * index / imageNumbers, 0,
                                                      sourceBitmap.Width / imageNumbers, sourceBitmap.Height),
             *                          PixelFormat.Format32bppArgb);*/
        }


        /// <summary>
        /// ��ͼƬ����Ϊ�ο�������ͼƬ�������ı�ԭʼͼƬ�����
        /// sourceBitmapָ������Ҫ������ͼƬ
        /// newWidthָ��������ͼƬ�µĿ��
        /// newHeightָ�����ź�ͼƬ�µĸ߶ȣ�ע���µĿ�ȸ߶Ȳ���С���㣬������׳��쳣
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
                throw new Exception("ͼƬ�ֱ��ʲ���С�ڵ����㣡");
            }
        }


        /// <summary>
        /// ��ͼƬ���ֳ����ɷݣ�ÿһ�ݳ�Ϊһ֡
        /// sourceBitmapָ��Ҫ���ֵ�ͼƬ
        /// frameNumbersָ��Ҫ���ֳɶ��ٷݣ�ע��֡������С��0
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
                throw new Exception("ͼƬ֡�����٣�");
            }
            
        }

        /// <summary>
        /// �������ŵĶ���֡
        /// sourceBitmapָ����������֡��ԭʼͼƬ
        /// pixָ��ÿһ֮֡������ز��pix����0ʱ��ֻ��С�Ķ���֡��pixС��0ʱ�������ǷŴ�Ķ���֡
        /// frameNumbersָ���ж���֡
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
                throw new Exception("֡��̫�٣���ĳһ֡������Ϊ�㣡");
            }

        }



        /// <summary>
        /// ��ԭͼƬ����Ϊ����ԭ�㣬��תͼƬ
        /// sourceBitmapָ������Ҫ��ת��ͼƬ
        /// angleָ����ת�ĽǶ�
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
