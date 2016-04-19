using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace Pencil
{
    public unsafe partial class FrmTest : Form
    {
        enum IS_DEPTH
        {
            IS_DEPTH_8U = 0,
            IS_DEPTH_8S = 1,
            IS_DEPTH_16S = 2,
            IS_DEPTH_32S = 3,
            IS_DEPTH_32F = 4,
            IS_DEPTH_64F = 5,
        };

        enum IS_RET
        {
            RET_OK,
            RET_ERR_OUTOFMEMORY,
            RET_ERR_NULLREFERENCE,
            RET_ERR_ARGUMENTOUTOFRANGE,
            RET_ERR_PARAMISMATCH,
            RET_ERR_DIVIDEBYZERO,
            RET_ERR_NOTSUPPORTED,
            RET_ERR_UNKNOWN
        };
  
        [StructLayout(LayoutKind.Sequential)]   
        public unsafe struct TMatrix
        {

            public int Width;				//	矩阵的宽度
	        public int Height;				//	矩阵的高度
	        public int Channel;		    	//	矩阵通道数
	        public int Depth;				//	矩阵元素的类型
	        public int WidthStep;			//	矩阵一行元素的占用的字节数
	        public int RowAligned;			//	是否使用四字节对齐
            public byte* Data;	//	矩阵的数据
            public TMatrix(int Width, int Height, int WidthStep, int Depth, int Channel, byte* Scan0)
            {
                this.Width = Width;
                this.Height = Height;
                this.WidthStep = WidthStep;
                this.Depth = Depth;
                this.Channel = Channel;
                this.Data = Scan0;
                this.RowAligned = 1;
            }
        };
        
        // dll的代码中用的是StdCall，这里也要用StdCall，如果用Cdecl，则会出现对 PInvoke 函数“....”的调用导致堆栈不对称错误，再次按F5又可以运行


        [DllImport("BoxBlur.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern IS_RET BoxBlur(ref TMatrix Src, ref TMatrix Dest, int Radius, int Edge) ;

        [DllImport("BoxBlur.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern IS_RET BoxBlurSSE(ref TMatrix Src, ref TMatrix Dest, int Radius, int Edge);

        Bitmap SrcBmp, DstBmp;
        TMatrix SrcImg, DestImg;
        private bool Busy = false;

        public FrmTest()
        {
            InitializeComponent();
        }
     

        private void CmdOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*) |*.*|Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap Bmp = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                SrcBmp = (Bitmap)Bmp.Clone();
                DstBmp = (Bitmap)Bmp.Clone();
                Bmp.Dispose();
                PicSrc.Image = SrcBmp;
                PicDest.Image = DstBmp;
                GetImageData();
            }
        }
            


        private void FrmTest_Load(object sender, EventArgs e)
        {

            SrcBmp = (Bitmap)PicSrc.Image;
            DstBmp = (Bitmap)PicDest.Image;
            GetImageData();
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            saveFileDialog.FilterIndex = 3;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                else if (saveFileDialog.FilterIndex == 2)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                else if (saveFileDialog.FilterIndex == 3)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }


        void GetImageData()
        {
            BitmapData SrcBmpData = SrcBmp.LockBits(new Rectangle(0, 0, SrcBmp.Width, SrcBmp.Height), ImageLockMode.ReadWrite, SrcBmp.PixelFormat);
            BitmapData DstBmpData = DstBmp.LockBits(new Rectangle(0, 0, DstBmp.Width, DstBmp.Height), ImageLockMode.ReadWrite, DstBmp.PixelFormat);

            int ImgWidth = SrcBmp.Width;
            int ImgHeight = SrcBmp.Height;
            int ImgStride = SrcBmpData.Stride;
            byte * Src = (byte*)SrcBmpData.Scan0;
            byte * Dest = (byte*)DstBmpData.Scan0;

            if (SrcBmpData.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                SrcImg = new TMatrix(ImgWidth, ImgHeight, ImgStride, (int)IS_DEPTH.IS_DEPTH_8U, 1, Src);
                DestImg = new TMatrix(ImgWidth, ImgHeight, ImgStride, (int)IS_DEPTH.IS_DEPTH_8U, 1, Dest);
            }
            else if (SrcBmpData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                SrcImg = new TMatrix(ImgWidth, ImgHeight, ImgStride, (int)IS_DEPTH.IS_DEPTH_8U, 3, Src);
                DestImg = new TMatrix(ImgWidth, ImgHeight, ImgStride, (int)IS_DEPTH.IS_DEPTH_8U, 3, Dest);
            }
            else if (SrcBmpData.PixelFormat == PixelFormat.Format32bppArgb && DstBmpData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                SrcImg = new TMatrix(ImgWidth, ImgHeight, ImgStride, (int)IS_DEPTH.IS_DEPTH_8U, 4, Src);
                DestImg = new TMatrix(ImgWidth, ImgHeight, ImgStride, (int)IS_DEPTH.IS_DEPTH_8U, 4, Dest);
            }
            SrcBmp.UnlockBits(SrcBmpData);
            DstBmp.UnlockBits(DstBmpData);
        }


        private void KerSize_Scroll(object sender, ScrollEventArgs e)
        {
            LblKerSize.Text = KerSize.Value.ToString();
        }

        private void CmdPureC_Click(object sender, EventArgs e)
        {
            Stopwatch Sw = new Stopwatch();
            Sw.Start();
            for (int i = 0; i < 100; i++)
                BoxBlur(ref SrcImg, ref DestImg, KerSize.Value, 0);
            Sw.Stop();
            LblInfo.Text = "迭代100次用时：" + Sw.ElapsedMilliseconds.ToString() + "ms.";
            PicDest.Refresh();
        }

        private void CmdSSE_Click(object sender, EventArgs e)
        {
            Stopwatch Sw = new Stopwatch();
            Sw.Start();
            for (int i = 0; i < 100; i++)
                BoxBlurSSE(ref SrcImg, ref DestImg, KerSize.Value, 0);
            Sw.Stop();
            LblInfo.Text = "迭代100次用时：" + Sw.ElapsedMilliseconds.ToString() + "ms.";
            PicDest.Refresh();
        }
    }
}
