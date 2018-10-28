using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MyProRes = WaveTable.Properties;
using System.Threading;


namespace WaveTable
{
    
    public partial class WTMainForm : Form
    {
        Bitmap bitmapStop, bitmapMsLeaveFinger,bitmapMsEnterFinger,bitmapMsEnterTable, bitmapMsLeaveTable;        
        Bitmap[] waveTableAct;
        Bitmap[] leimu = new Bitmap[53];

        int currentFrame = 0;
        bool isDrag = false;
        bool isMouseEnter=false;
        bool mouseEnterFinish = false;
        bool mouseLeaveFinish = true;
        bool isDownLoading = false;
        bool canColse = false;

        Point oldPostion,curPostion;
        IntPtr HWND = IntPtr.Zero;

        Thread mouseEnterThread, mouseLeaveThread,downLoadingThread;

        public WTMainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            Screen tmpScreen = Screen.PrimaryScreen;
            this.Left = tmpScreen.Bounds.Width * 4 / 5+10;
            this.Top = tmpScreen.Bounds.Height / 10-45;
        

            bitmapStop = ImageHandle.CutImage(MyProRes.Resources.Watch, 5, 4);
            ImageHandle.chushihua(MyProRes.Resources.Watch, 5, 4);
        
            bitmapMsEnterTable = ImageHandle.CutImage(MyProRes.Resources.Watch, 5, 0);
          //  bitmapMsEnterFinger = ImageHandle.CircumvolveImage(ImageHandle.CutImage(MyProRes.Resources.Watch, 5, 2),-140);
            bitmapMsLeaveTable = ImageHandle.CutImage(MyProRes.Resources.Watch, 5, 1);
           // bitmapMsLeaveFinger = ImageHandle.CircumvolveImage(ImageHandle.CutImage(MyProRes.Resources.Watch, 5, 3),-140);
            waveTableAct = MakeWTActFrame();
           
            for (int a = 0; a < 53; a++)
            {
                String name = "BadGirl" + a.ToString() + ".png";
                Console.WriteLine(name);
                Image img = Image.FromFile(name);
                leimu[a] = new Bitmap(img,50, 80);
               // leimu[a] = new Bitmap(name);
             
            }

            mouseEnterThread = null;
            mouseLeaveThread = null;
            downLoadingThread = null;
            
            HWND = this.Handle;
            curPostion.X = this.Left;
            curPostion.Y = this.Top;
        }
        
        /// <summary>
        /// Ԥ�����������ʱͼƬ        
        /// </summary>
        /// <returns></returns>
        Bitmap[] MakeWTActFrame()
        {
            Bitmap[] returnBitmap;
            Bitmap[] tmpWaveTableAct = ImageHandle.MakeZoomImageFrame(bitmapMsEnterTable, 5, 7);
            Bitmap[] tmpInfoTableAct = ImageHandle.MakeActImamgeFrame(MyProRes.Resources.WatchFlex, 12);
            returnBitmap = new Bitmap[tmpWaveTableAct.Length + tmpInfoTableAct.Length];
            for (int i = 0; i < tmpWaveTableAct.Length; i++)
                returnBitmap[i] = tmpWaveTableAct[i];
            for (int i = tmpWaveTableAct.Length; i < returnBitmap.Length; i++)
            {
                returnBitmap[i] = new Bitmap(tmpWaveTableAct[0].Width + tmpInfoTableAct[i - tmpWaveTableAct.Length].Width, tmpWaveTableAct[0].Height);
                Graphics tmpGraphics = Graphics.FromImage(returnBitmap[i]);
                tmpGraphics.DrawImage(tmpInfoTableAct[(tmpInfoTableAct.Length - 1) - (i - tmpWaveTableAct.Length)], tmpWaveTableAct[0].Width - 37,
                                     (returnBitmap[i].Height - tmpInfoTableAct[(tmpInfoTableAct.Length - 1) - (i - tmpWaveTableAct.Length)].Height) / 2);
                tmpGraphics.DrawImage(tmpWaveTableAct[0], 0, 0);
            }
            return returnBitmap;
        }

        /// <summary>
        /// �㿪ʼ����ʱ�߳̾���ִ�еĴ���
        /// ע�������и���Դ�޷��ͷŵ����⣬�Ҳ�֪����ô����
        /// </summary>
        void DownLoadingThreadFun()
        {
            while (isDownLoading == true)
            {
                if (mouseEnterFinish == true)
                {
                    Random tmpRandom = new Random();
                    int tmpAngle = tmpRandom.Next(280);

                    Bitmap tmpBitmap = new Bitmap(waveTableAct[waveTableAct.Length - 1].Width,
                                                  waveTableAct[waveTableAct.Length - 1].Height,
                                                  PixelFormat.Format32bppArgb);
                    Graphics tmpDrawCanvas = Graphics.FromImage(tmpBitmap);

                    /* �������DrawString������ʾ������ϸ��Ϣ
                     * 
                     * tmpRanAngle.Next(280)
                     * 
                     * */
                /*    for (int i = 0; i <= tmpAngle; i++)
                    {
                        if (isMouseEnter == true) 
                        {
                            tmpDrawCanvas.DrawImage(waveTableAct[waveTableAct.Length - 1], 0, 0);
                            tmpDrawCanvas.DrawImage(ImageHandle.CircumvolveImage(bitmapMsEnterFinger, i), 0, 0);
                            SetBitmap(tmpBitmap);
                            Thread.Sleep(17);
                            tmpDrawCanvas.Clear(Color.FromArgb(0, 0, 0, 0));
                        }
                        else
                        {
                            break;
                        }
                    }*/
                }
                if (mouseLeaveFinish == true)
                {
                    Random tmpRandom = new Random();
                    int tmpAngle = tmpRandom.Next(280);

                    Bitmap tmpBitmap = new Bitmap(bitmapMsLeaveTable.Width,
                                                  bitmapMsLeaveTable.Height,
                                                  PixelFormat.Format32bppArgb);
                    Graphics tmpDrawCanvas = Graphics.FromImage(tmpBitmap);

                    /* �������DrawString������ʾ������ϸ��Ϣ
                     * 
                     * 
                     * 
                     * */
                 /*   for (int i = 0; i <= tmpAngle; i++)
                    {
                        if (isMouseEnter == false)
                        {
                            tmpDrawCanvas.DrawImage(bitmapMsLeaveTable, 0, 0);
                            tmpDrawCanvas.DrawImage(ImageHandle.CircumvolveImage(bitmapMsLeaveFinger, i), 0, 0);
                            SetBitmap(tmpBitmap);
                            tmpDrawCanvas.Clear(Color.FromArgb(0, 0, 0, 0));
                            Thread.Sleep(17);
                        }
                        else
                        {
                            break;
                        }
                    }*/
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// �������ʱ�߳̾���ִ�д���
        /// </summary>
        void MouseEnterThreadFun()
        {           
            for (int i = 0; i < waveTableAct.Length; i++)
			{
                if (isMouseEnter == true)
                {
                    if (i <= 12)
                    {
                        SetBitmap(waveTableAct[i]);
                        Thread.Sleep(17);
                    }
                    else
                    {
                        SetBitmap(waveTableAct[i]);
                        Thread.Sleep(7);
                    }                    
                    if (i == waveTableAct.Length - 1)
                        mouseEnterFinish = true;
                    currentFrame = i;
                }
                else
                {
                    break;
                }
			}
        }


        /// <summary>
        /// ����Ƴ�ʱ���߳̾���ִ�д���
        /// </summary>
        void MouseLeaveThreadFun()
        {
            for (int i = currentFrame; i >= 0; i--)
            {
                if (isMouseEnter == false)
                {
                    if (i >= 13)
                    {
                        SetBitmap(waveTableAct[i]);
                        Thread.Sleep(7);
                    }
                    else
                    {
                        SetBitmap(waveTableAct[i]);
                        Thread.Sleep(17);
                    }
                    if (i == 0)
                        mouseLeaveFinish = true;
                }
                else
                {
                    break;
                }
            }
        }        

        #region AlphaForm Core Snippet
        /// <summary>
        /// ��������Alphaͨ����Form���Ĵ���
        /// </summary>
        protected override CreateParams CreateParams
        {
            //set form style
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000; // This form has to have the WS_EX_LAYERED extended style
                return cp;
            }
        }

        public void SetBitmap(Bitmap bitmap)
        {
            SetBitmap(bitmap, 255);
        }
        
        /// <summary>
        /// Alpha Form���Ĵ���
        /// bitmapΪһ�Ŵ���Alphaͨ����32λλͼ
        /// opacityָ�������͸����
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="opacity"></param>
        public void SetBitmap(Bitmap bitmap, byte opacity)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");
            
            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos = new Win32.Point(curPostion.X, curPostion.Y);
                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();

                /**/
                ////Construct Win32.BLENDFUNCTION
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                //The Alpha Form Core Function
                Win32.UpdateLayeredWindow(HWND, screenDc, ref topPos, ref size,
                                          memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                //Release Resource
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    //Windows.DeleteObject(hBitmap); 
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }

        #endregion


        #region �¼��������

        //��¼�¼�
        private void WTMainForm_Load(object sender, EventArgs e)
        {
            SetBitmap(leimu[0]);
            Thread t = new Thread(qiehuan);
            t.Start();
        }
        void qiehuan()
        {
            int lingshi = 1;
            while (true)
            {
                lingshi++;
                lingshi %= 50;
                SetBitmap(leimu[lingshi]);
                Thread.Sleep(60);

            }
        }
        private void WTMainForm_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            oldPostion.X = e.X;
            oldPostion.Y = e.Y;
        }

        private void WTMainForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        private void WTMainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (isDrag == true))
            {
                this.Left += e.X - oldPostion.X;
                this.Top += e.Y - oldPostion.Y;
                curPostion.X = this.Left;
                curPostion.Y = this.Top;
            }
        }

        private void WTMainForm_MouseEnter(object sender, EventArgs e)
        {
            if (isDownLoading == true)
            {
                isMouseEnter = true;
                mouseEnterFinish = false;
                mouseEnterThread = new Thread(new ThreadStart(MouseEnterThreadFun));
                mouseEnterThread.Start();
            }
                
        }

        private void WTMainForm_MouseLeave(object sender, EventArgs e)
        {
            if (isDownLoading == true)
            {
                isMouseEnter = false;
                mouseLeaveFinish = false;
                mouseLeaveThread = new Thread(new ThreadStart(MouseLeaveThreadFun));
                mouseLeaveThread.Start();
            }
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canColse = true;
            Environment.Exit(0);
        }       

        private void ���ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            /*
            if (isDownLoading == false)
            {
                isDownLoading = true;
                downLoadingThread = new Thread(new ThreadStart(DownLoadingThreadFun));
                downLoadingThread.Start();
            }*/
        }
        //ȫ��ֹͣ
        private void ��СToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if (isDownLoading == true)
            {
                isDownLoading = false;
                if (mouseLeaveThread != null)
                {
                    mouseLeaveThread.Abort();
                }
                if (downLoadingThread != null)
                {
                    downLoadingThread.Abort();
                }
                SetBitmap(bitmapStop);
            }
            */
            
        }
       
        private void WTMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canColse == false)
            {
                e.Cancel = true;
            }
        }

        #endregion
    }
}