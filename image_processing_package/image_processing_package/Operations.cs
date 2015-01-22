using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using image_processing_packages;
using System.Drawing.Imaging;

namespace image_processing_packages
{
    class Operations
    {
        
        /*
        public static Bitmap pic_2;
        public static Graphics g;
        public static Matrix X = new Matrix();
         * */
        public void drawHistogram(Graphics g, Bitmap pic , int[] hist, int max)
        {
            int histHeight = 1;
            Bitmap img = new Bitmap(800, histHeight + 500);
            
            for (int i = 0; i < hist.Length; i++)
            {
                float pct = hist[i] / (float)max;   // What percentage of the max is this value?
                g.DrawLine(Pens.Black,
                    new Point(i, img.Height - 1),
                    new Point(i, img.Height - 1 - (int)(pct * histHeight)));
            }

            g.DrawImage(pic, 650, 200, pic.Width, pic.Height);
            
        }

        public void drawHistogram_logicOperations(Graphics g, Bitmap pic_1, Bitmap pic_2, Bitmap pic_3, int[] hist, int max)
        {
            int histHeight = 1;
            Bitmap img = new Bitmap(800, histHeight + 500);

            for (int i = 0; i < hist.Length; i++)
            {
                float pct = hist[i] / (float)max;   // What percentage of the max is this value?
                g.DrawLine(Pens.Black,
                    new Point(i, img.Height - 1),
                    new Point(i, img.Height - 1 - (int)(pct * histHeight)));
            }
            g.DrawImage(pic_1, 650, 30, pic_1.Width, pic_1.Height);
            g.DrawImage(pic_2, 650, 360, pic_2.Width, pic_2.Height);
            g.DrawImage(pic_3, 300, 200, pic_3.Width, pic_3.Height);
        }

        public void brightness(Bitmap pic, int bright , Graphics g)
        {
            int[] hist = new int[256];
            int max = 0;
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int newvalr = pixelColor.R + bright;
                    int newvalg = pixelColor.G + bright;
                    int newvalb = pixelColor.B + bright;
                    if (newvalr > 255)
                        newvalr = 255;
                    if (newvalg > 255)
                        newvalg = 255;
                    if (newvalb > 255)
                        newvalb = 255;
                    if (newvalr < 0)
                        newvalr = 0;
                    if (newvalg < 0)
                        newvalg = 0;
                    if (newvalb < 0)
                        newvalb = 0;
                    int gray = (int)(newvalr * 0.3 + newvalg * 0.59 + newvalb * 0.11);
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                    pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            int histHeight = 1;
            Bitmap img = new Bitmap(800, histHeight + 500);

            for (int i = 0; i < hist.Length; i++)
            {
                float pct = hist[i] / (float)max;   // What percentage of the max is this value?
                g.DrawLine(Pens.Black,
                    new Point(i, img.Height - 1),
                    new Point(i, img.Height - 1 - (int)(pct * histHeight)));
            }

            g.DrawImage(pic, 650, 200, pic.Width, pic.Height);
            pic.Save("d:\\IM\\brightness.png");

            //Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
           // return hist_data;
            //drawHistogram(g,hist, max);
        }


        public void contrast(Bitmap pic, double newmin, double newmax, Graphics g)
        {

            int[] hist = new int[256];
            int max = 0;
            //contrast
            double oldmin_r = -1;
            double oldmax_r = 1;
            double oldmin_g = -1;
            double oldmax_g = 1;
            double oldmin_b = -1;
            double oldmax_b = 1;

            double newmin_r = newmin;
            double newmax_r = newmax;
            double newmin_g = newmin;
            double newmax_g = newmax;
            double newmin_b = newmin;
            double newmax_b = newmax;



            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                }
            for (int j = 0; j < 256; j++)
            {
                if (hist[j] > 0 && oldmin_r == -1)
                    oldmin_r = j;
                if (hist[j] > 0)
                    oldmax_r = j;

                if (hist[j] > 0 && oldmin_g == -1)
                    oldmin_g = j;
                if (hist[j] > 0)
                    oldmax_g = j;

                if (hist[j] > 0 && oldmin_b == -1)
                    oldmin_b = j;
                if (hist[j] > 0)
                    oldmax_b = j;
            }

            for (int j = 255; j > 0; j--)
            {
                if (hist[j] > 0)
                    oldmax_r = j;

                if (hist[j] > 0)
                    oldmax_g = j;

                if (hist[j] > 0)
                    oldmax_b = j;
            }
            hist = new int[256];
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int newvalr = (int)(((pixelColor.R - oldmin_r) / (oldmax_r - oldmin_r)) * (newmax_r - newmin_r) + newmin_r);
                    int newvalg = (int)(((pixelColor.G - oldmin_g) / (oldmax_g - oldmin_g)) * (newmax_g - newmin_g) + newmin_g);
                    int newvalb = (int)(((pixelColor.B - oldmin_b) / (oldmax_b - oldmin_b)) * (newmax_b - newmin_b) + newmin_b);
                    
                    if (newvalr > 255)
                        newvalr = 255;
                    if (newvalg > 255)
                        newvalg = 255;
                    if (newvalb > 255)
                        newvalb = 255;
                    if (newvalr < 0)
                        newvalr = 0;
                    if (newvalg < 0)
                        newvalg = 0;
                    if (newvalb < 0)
                        newvalb = 0;
                     
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                    pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }

            int histHeight = 1;
            Bitmap img = new Bitmap(800, histHeight + 500);

            for (int i = 0; i < hist.Length; i++)
            {
                float pct = hist[i] / (float)max;   // What percentage of the max is this value?
                g.DrawLine(Pens.Black,
                    new Point(i, img.Height - 1),
                    new Point(i, img.Height - 1 - (int)(pct * histHeight)));
            }

            g.DrawImage(pic, 650, 200, pic.Width, pic.Height);
            pic.Save("d:\\IM\\contrast.png");

            //Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
            //return hist_data;
            //drawHistogram(g,hist, max);
        }

        public void gamma(Bitmap pic, double gamma , Graphics g)
        {
            Bitmap gamma_pic;
            gamma_pic = new Bitmap(pic.Width, pic.Height);
            int[] hist = new int[256];
            int max = 0;

            double oldmin_r = -1;
            double oldmax_r = 1;
            double oldmin_g = -1;
            double oldmax_g = 1;
            double oldmin_b = -1;
            double oldmax_b = 1;

            double newmin_r = 99999999999999;
            double newmax_r = -99999999999999;
            double newmin_g = 99999999999999;
            double newmax_g = -99999999999999;
            double newmin_b = 99999999999999;
            double newmax_b = -99999999999999;
            /*
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                }

            */
            for (int j = 0; j < 256; j++)
            {
                if (hist[j] > 0 && oldmin_r == -1)
                    oldmin_r = j;
                if (hist[j] > 0)
                    oldmax_r = j;

                if (hist[j] > 0 && oldmin_g == -1)
                    oldmin_g = j;
                if (hist[j] > 0)
                    oldmax_g = j;

                if (hist[j] > 0 && oldmin_b == -1)
                    oldmin_b = j;
                if (hist[j] > 0)
                    oldmax_b = j;
            }

            for (int j = 255; j > 0; j--)
            {
                if (hist[j] > 0)
                    oldmax_r = j;

                if (hist[j] > 0)
                    oldmax_g = j;

                if (hist[j] > 0)
                    oldmax_b = j;
            }
            
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int newvalr = (int)Math.Pow(pixelColor.R, gamma);
                    int newvalg = (int)Math.Pow(pixelColor.G, gamma);
                    int newvalb = (int)Math.Pow(pixelColor.B, gamma);

                     newvalr = (int)(((pixelColor.R - oldmin_r) / (oldmax_r - oldmin_r)) * (newmax_r - newmin_r) + newmin_r);
                     newvalg = (int)(((pixelColor.G - oldmin_g) / (oldmax_g - oldmin_g)) * (newmax_g - newmin_g) + newmin_g);
                     newvalb = (int)(((pixelColor.B - oldmin_b) / (oldmax_b - oldmin_b)) * (newmax_b - newmin_b) + newmin_b);

                    if (newvalr > 255)
                        newvalr = 255;
                    if (newvalg > 255)
                        newvalg = 255;
                    if (newvalb > 255)
                        newvalb = 255;
                    if (newvalr < 0)
                        newvalr = 0;
                    if (newvalg < 0)
                        newvalg = 0;
                    if (newvalb < 0)
                        newvalb = 0;
                    /*
                    int gray = (int)(newvalr * 0.3 + newvalg * 0.59 + newvalb * 0.11);
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                     * */
                    gamma_pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }

            //Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
            //return hist_data;
            //drawHistogram(g,hist, max);
            //g.DrawImage(gamma_pic, 300, 200, gamma_pic.Width, gamma_pic.Height);
            //gamma_pic.Save("d:\\IM\\subtract_1.png");
            /*
            int histHeight = 1;
            Bitmap img = new Bitmap(800, histHeight + 500);
            
            for (int i = 0; i < hist.Length; i++)
            {
                float pct = hist[i] / (float)max;   // What percentage of the max is this value?
                g.DrawLine(Pens.Black,
                    new Point(i, img.Height - 1),
                    new Point(i, img.Height - 1 - (int)(pct * histHeight)));
            }
            */
            g.DrawImage(gamma_pic, 650, 200, pic.Width, pic.Height);
            gamma_pic.Save("d:\\IM\\gamma.png");
        }

        public Tuple<int[], int> equalizedHistogram(Bitmap pic , Graphics g)
        {
            Bitmap equal_pic;
            equal_pic = new Bitmap(pic.Width, pic.Height);
            int[] hist = new int[256];
            int max = 0;

            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    int red = pixelColor.R;
                    pic.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                }

            double sum = 0;
            double num_pixels = pic.Width * pic.Height;
            double newR = 7;
            int[] round = new int[256];
            for (int i = 0; i < hist.Length; i++)
            {
                sum += hist[i];
                round[i] = (int)Math.Round((sum / num_pixels) * newR);
            }

            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    gray = round[gray];
                    pic.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            max = 0;
            hist = new int[256];

            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    int red = pixelColor.R;
                    pic.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                }
            Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
            return hist_data;
            //drawHistogram(g,hist, max);
        }

        public Tuple<int[], int> grayScale(Bitmap pic)
        {
            int[] hist = new int[256];
            int max = 0;
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    int red = pixelColor.R;
                    pic.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                }
            Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
            return hist_data;
            //drawHistogram(g,hist, max);
        }

        public Tuple<int[], int> not(Bitmap pic)
        {
            int[] hist = new int[256];
            int max = 0;
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int newvalr = 255 - pixelColor.R;
                    int newvalg = 255 - pixelColor.G;
                    int newvalb = 255 - pixelColor.B;
                    int gray = (int)(newvalr * 0.3 + newvalg * 0.59 + newvalb * 0.11);
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                    pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
            return hist_data;
            //drawHistogram(g,hist, max);
        }

        public void add(Bitmap pic_1 , Bitmap pic_2, double fraction , Graphics g)
        {
            Bitmap add_pic;
            add_pic = new Bitmap(pic_2.Width, pic_2.Height);
            int[] hist = new int[256];
            int max = 0;
            pic_1 = new Bitmap(pic_1, new Size(pic_2.Width, pic_2.Height));
            for (int i = 0; i < pic_2.Width; i++)
                for (int j = 0; j < pic_2.Height; j++)
                {
                    Color pixelColor1 = pic_2.GetPixel(i, j);
                    Color pixelColor2 = pic_1.GetPixel(i, j);
                    int newvalr = (int)(pixelColor1.R * fraction + pixelColor2.R * (1 - fraction));
                    int newvalg = (int)(pixelColor1.G * fraction + pixelColor2.G * (1 - fraction));
                    int newvalb = (int)(pixelColor1.B * fraction + pixelColor2.B * (1 - fraction));
                    int gray = (int)(newvalr * 0.3 + newvalg * 0.59 + newvalb * 0.11);
                    if (newvalr > 255)
                        newvalr = 255;

                    if (newvalg > 255)
                        newvalg = 255;
                    if (newvalb > 255)
                        newvalb = 255;
                    if (newvalr < 0)
                        newvalr = 0;
                    if (newvalg < 0)
                        newvalg = 0;
                    if (newvalb < 0)
                        newvalb = 0;
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                    add_pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            //drawHistogram(g,pic, hist, max);
            //Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
            //return hist_data;
            g.DrawImage(add_pic, 300, 200, add_pic.Width, add_pic.Height);
            add_pic.Save("d:\\IM\\add.png");
        }

        public void subtract(Bitmap pic_1, Bitmap pic_2 , Graphics g)
        {
            Bitmap sub_pic;
            sub_pic = new Bitmap(pic_2, new Size(pic_2.Width, pic_2.Height));
            int[] hist = new int[256];
            int max = 0;

            double oldmin = 0;
            double oldmax = 1;

            //pic_2 = new Bitmap(pic_1, new Size(pic_2.Width, pic_2.Height));
            pic_1 = new Bitmap(pic_1, new Size(pic_2.Width, pic_2.Height));
            // Graphics g = this.CreateGraphics();
            // g.Clear(this.BackColor);
            /*
            for (int j = 0; j < 256; j++)
            {
                if (hist[j] > 0 && oldmin == -1)
                    oldmin = j;
                if (hist[j] > 0)
                    oldmax = j;
            }
            */
            for (int i = 0; i < pic_2.Width; i++)
                for (int j = 0; j < pic_2.Height; j++)
                {
                    Color pixelColor1 = pic_2.GetPixel(i, j);
                    Color pixelColor2 = pic_1.GetPixel(i, j);
                    int newvalr = (int)(pixelColor1.R - pixelColor2.R);
                    int newvalg = (int)(pixelColor1.G - pixelColor2.G);
                    int newvalb = (int)(pixelColor1.B - pixelColor2.B);
                    /*
                     newvalr = (int)(((pixelColor1.R - oldmin) / (oldmax - oldmin)) * (255 - 0) + 0);
                     newvalg = (int)(((pixelColor1.G - oldmin) / (oldmax - oldmin)) * (255 - 0) + 0);
                     newvalb = (int)(((pixelColor1.B - oldmin) / (oldmax - oldmin)) * (255 - 0) + 0);
                    */
                    if (newvalr > 255)
                        newvalr = 255;

                    if (newvalg > 255)
                        newvalg = 255;
                    if (newvalb > 255)
                        newvalb = 255;
                    if (newvalr < 0)
                        newvalr = 0;
                    if (newvalg < 0)
                        newvalg = 0;
                    if (newvalb < 0)
                        newvalb = 0;
                    
                    int gray = (int)(newvalr * 0.3 + newvalg * 0.59 + newvalb * 0.11);
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                    sub_pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            //drawHistogram(g,pic_2, hist, max);
            g.DrawImage(sub_pic, 300, 200, sub_pic.Width, sub_pic.Height);
            sub_pic.Save("d:\\IM\\subtract_4.png");
            //Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
            //return hist_data;
        }


        public Tuple<int[], int> bit_slicing(Bitmap pic, string bits)
        {
            int bit= Convert.ToInt32(bits, 2);
            int[] hist = new int[256];
            int max = 0;
          //  int bit = 0 | (1 << index);
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    int newvalr = bit & pixelColor.R;
                    int newvalg = bit &  pixelColor.G;
                    int newvalb = bit &  pixelColor.B;
                    //if ((gray & bit) == 0)
                    //    gray = 0;
                    //else
                    //    gray = 255;
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                    pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            //drawHistogram(g,pic, hist, max);
            Tuple<int[], int> hist_data = new Tuple<int[], int>(hist, max);
            return hist_data;
        }

        // filters
      //  ***********************************************************************************************************************

        public double[,] meanFilter(int width, int height)
        {
            double[,] mask;
            mask = new double[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    mask[i, j] = 1.0 / (width * height);

                }
            return mask;
        }

        //option 1
        public double[,] gaussianFilter_1(int maskSize, double sigma)
        {
            double[,] mask;
            int height = maskSize;
            int width = maskSize;
            double sum = 0;

            mask = new double[maskSize, maskSize];

            double[,] c = new double[maskSize, maskSize];

            for (double x = -((double)maskSize / 2), i = 0; x < ((double)maskSize / 2); x++, i++)
            {
                for (double y = -((double)maskSize / 2), j = 0; y < (double)maskSize / 2; y++, j++)
                {
                    mask[(int)i, (int)j] = Math.Pow(Math.E, -(x * x + y * y) / (2.0f * sigma * sigma));
                }
            }
            //Normalization

            for (int i = 0; i < maskSize; i++)
            {
                for (int j = 0; j < maskSize; j++)
                {
                    sum += mask[i, j];
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mask[i, j] = mask[i, j] / sum;
                }
            }
            //rotating the mask 180 degrees
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    c[i, j] = mask[i, j];
                }
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mask[i, j] = c[(int)width - 1 - i, (int)height - 1 - j];
                }
            }

            return mask;
        }


        //option 2
        public double[,] gaussianFilter_2(double sigma)
        {
            double[,] mask;
            int width , height;
            //Compute Mask Size
            int n = (int)(3.7 * sigma - 0.5);
            double maskSize = 2 * n + 1;

            width = height = (int)maskSize;
            mask = new double[(int)maskSize, (int)maskSize];

            double[,] c = new double[(int)maskSize, (int)maskSize];

            //filling the mask

            for (double x = -(maskSize / 2.0f), i = 0; x < (maskSize / 2.0f); x++, i++)
                for (double y = -(maskSize / 2.0f), j = 0; y < maskSize / 2.0f; y++, j++)
                {
                    mask[(int)i, (int)j] = (1.0f / (2.0f * Math.PI * sigma * sigma)) * (Math.Pow(Math.E, -(x * x + y * y) / (2.0f * sigma * sigma)));
                }
            //rotating the mask 180 degrees

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    c[i, j] = mask[i, j];
                }
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mask[i, j] = c[(int)width - 1 - i, (int)height - 1 - j];
                }
            }

            return mask;
        }

        public double[,] laplacian_filter()
        {
            int filterWidth = 3;
            int filterHeight = 3;
            double[,] filter = new double[filterWidth, filterHeight];

            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;
            return filter;

        }

        public double[,] edgeDetection_filter(int direction)
        {
            int filterWidth = 3;
            int filterHeight = 3;
            double[,] filter = new double[filterWidth, filterHeight];


            if (direction == 1)
            {
                filter[0, 0] = filter[0, 1] = filter[0, 2] = 5;
                filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -3;
                filter[1, 1] = 0;
            }
            if (direction == 2)
            {
                filter[0, 0] = filter[1, 0] = filter[2, 0] = 5;
                filter[1, 0] = filter[1, 2] = filter[2, 1] = filter[2, 2] = filter[0, 1] = filter[0, 2]= -3;
                filter[1, 1] = 0;
            }
            if (direction == 3)
            {
                filter[0, 0] = filter[1, 0] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -3;
                filter[1, 0] = filter[1, 2] = filter[2, 1] = filter[0, 1] = filter[0, 2] = 5;
                filter[1, 1] = 0;
            }
            if (direction == 4)
            {
                filter[0, 0] = filter[0, 1] = filter[1, 0] = 5;
                filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = filter[0, 2] = -3;
                filter[1, 1] = 0;
            }
            return filter;
        }

        public Bitmap laplacian_sharping(Bitmap pic_padded , double[,] filter)
        {
            Bitmap sharpen_pic = (Bitmap)pic_padded.Clone();
            int filterHeight = filter.GetLength(0);
            int filterWidth = filter.GetLength(1);
            double rAcc, gAcc, bAcc;
            double factor = 1.0;
            double bias = 0.0;
            Color[,] sharped = new Color[pic_padded.Width, pic_padded.Height];


            // Lock image bits for read/write.
            BitmapData pbits = sharpen_pic.LockBits(new Rectangle(0, 0, pic_padded.Width, pic_padded.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Declare an array to hold the bytes of the bitmap.
            int bytes = pbits.Stride * pic_padded.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;

            for (int i = 0; i < pic_padded.Width - filterWidth; i++)
            {
                for (int j = 0; j < pic_padded.Height - filterHeight; j++)
                {
                    rAcc = gAcc = bAcc = 0.0;
                    //Color pixelColor = pic_padded.GetPixel(i , j);
                    for (int x = 0; i < filterWidth; x++)
                    {
                        for (int y = 0; j < filterHeight; y++)
                        {

                            int imageX = (i - filterWidth / 2 + x + pic_padded.Width) % pic_padded.Width;
                            int imageY = (j - filterHeight / 2 + y + pic_padded.Height) % pic_padded.Height;

                            rgb = imageY * pbits.Stride + 3 * imageX;
                            //Color pixelColor = pic_padded.GetPixel(x, y);

                            rAcc += (int)(filter[x, y] * rgbValues[rgb + 2]);
                            gAcc += (int)(filter[x, y] * rgbValues[rgb + 1]);
                            bAcc += (int)(filter[x, y] * rgbValues[rgb + 0]);
                        }
                        int r = Math.Min(Math.Max((int)(factor * rAcc + bias), 0), 255);
                        int g = Math.Min(Math.Max((int)(factor * gAcc + bias), 0), 255);
                        int b = Math.Min(Math.Max((int)(factor * bAcc + bias), 0), 255);

                        sharped[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            // Update the image with the sharpened pixels.
            for (int i = 0; i < pic_padded.Width; ++i)
            {
                for (int j = 0; j < pic_padded.Height; ++j)
                {
                    //sharpen_pic.SetPixel(i, j, sharped[i, j]);
                    rgb = j * pbits.Stride + 3 * i;

                    rgbValues[rgb + 2] = sharped[i, j].R;
                    rgbValues[rgb + 1] = sharped[i, j].G;
                    rgbValues[rgb + 0] = sharped[i, j].B;
                }
            }

            // Copy the RGB values back to the bitmap.
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            // Release image bits.
            sharpen_pic.UnlockBits(pbits);

            return sharpen_pic;
        }

        public Bitmap padding(Bitmap pic, int filter_width, int filter_height)
        {
            //this.width = width;
            //this.height = height;
            Bitmap pic_padded = new Bitmap(pic, new Size(pic.Width + filter_width, pic.Height + filter_height));

            //pic = new Bitmap(pic.Width+width , pic.Height+height);
            for (int i = pic.Width + 1; i < pic_padded.Width; i++)
                for (int j = 0; j < pic_padded.Height; j++)
                {
                    pic_padded.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            for (int i = 0; i < pic_padded.Width; i++)
                for (int j = pic.Height; j < pic_padded.Height; j++)
                {
                    pic_padded.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            return pic_padded;
        }
        /*
        public void post_process_cutoff(int r, int g, int b, out int rAcc, int gAcc, int bAcc)
        {
            rAcc = gAcc = bAcc = 0;
            if (r > 255)
                rAcc = 255;
            if (g > 255)
                gAcc = 255;
            if (b > 255)
                bAcc = 255;
            if (r < 0)
                rAcc = 0;
            if (b < 0)
                bAcc = 0;
            if (g < 0)
                gAcc = 0;
        }
        */
        public void linearFilter(Bitmap pic_padded, double[,] filter, int origX, int origY , image_processing_package.Main.post_process p , Graphics g , int v)
        {
            Bitmap out_pic;
            out_pic = new Bitmap(pic_padded, new Size(pic_padded.Width, pic_padded.Height));
            int filterHeight = filter.GetLength(0);
            int filterWidth = filter.GetLength(1);
            double rAcc, gAcc, bAcc;
            double new_r = 0;
            double new_g = 0;
            double new_b = 0;

            for (int i = 0; i < pic_padded.Width - filterWidth; i++)
            {
                for (int j = 0; j < pic_padded.Height - filterHeight; j++)
                {
                    rAcc = 0;
                    gAcc = 0;
                    bAcc = 0;

                    for (int x = 0; x < filterWidth; x++)
                    {
                        for (int y = 0; y < filterHeight; y++)
                        {
                            Color pixelColor = pic_padded.GetPixel(i + x, j + y);
                            rAcc += (filter[x, y] * pixelColor.R);
                            gAcc += (filter[x, y] * pixelColor.G);
                            bAcc += (filter[x, y] * pixelColor.B);
                        }
                    }
                    if (p == image_processing_package.Main.post_process.cutoff)
                    {
                        if (rAcc > 255)
                            rAcc = 255;
                        if (gAcc > 255)
                            gAcc = 255;
                        if (bAcc > 255)
                            bAcc = 255;
                        if (rAcc < 0)
                            rAcc = 0;
                        if (bAcc < 0)
                            bAcc = 0;
                        if (gAcc < 0)
                            gAcc = 0;

                        //set the accumulated value to the center pixel
                        out_pic.SetPixel(i + origX, j + origY, Color.FromArgb((int)rAcc, (int)gAcc, (int)bAcc));

                    }

                    
                    
                    if (p == image_processing_package.Main.post_process.normalization)
                    {
                        int min_r = 99999999;
                        int max_r = -99999999;
                        int min_g = 99999999;
                        int max_g = -99999999;
                        int min_b = 99999999;
                        int max_b = -99999999;

                        for (int x = 0; x < pic_padded.Width; x++)
                        {
                            for (int y = 0; y < pic_padded.Height; y++)
                            {
                                Color pixelColor = pic_padded.GetPixel(x, y);
                                int old_r = pixelColor.R;
                                int old_g = pixelColor.G;
                                int old_b = pixelColor.B;
                                if (old_r > max_r)
                                    max_r = old_r;
                                if (old_r < min_g)
                                    min_g = old_r;

                                if (old_g > max_g)
                                    max_g = old_g;
                                if (old_g < min_g)
                                    min_g = old_g;

                                if (old_b > max_b)
                                    max_b = old_b;
                                if (old_b < min_b)
                                    min_b = old_b;
                            }
                        }
                        for (int x = 0; x < pic_padded.Width; x++)
                        {
                            for (int y = 0; y < pic_padded.Height; y++)
                            {
                                Color pixelColor = pic_padded.GetPixel(x, y);
                                int old_r = pixelColor.R;
                                int old_g = pixelColor.G;
                                int old_b = pixelColor.B;

                                new_r = ((old_r - min_r) / (max_r - min_r))*255.0;
                                new_g = ((old_g - min_g) / (max_g - min_g)) * 255.0;
                                new_b = ((old_b - min_b) / (max_b - min_b)) * 255.0;
                               // MessageBox.Show(min_r.ToString());

                                //set the accumulated value to the center pixel
                                out_pic.SetPixel(i + origX, j + origY, Color.FromArgb((int)new_r, (int)new_g, (int)new_b));

                            }
                        }

                    }
                    if (p == image_processing_package.Main.post_process.nothing)
                    {
                        //set the accumulated value to the center pixel
                        out_pic.SetPixel(i + origX, j + origY, Color.FromArgb((int)rAcc, (int)gAcc, (int)bAcc));
                    }

                }
            }
            if (v != 1)
            {
                g.DrawImage(out_pic, 50, 200, out_pic.Width, out_pic.Height);
                out_pic.Save("d:\\IM\\filter.png");
            }
            else
            {
                /*
                // #2 Subtract the smoothed image from the original
                // pic_3 is the original image
                pic_3 = new Bitmap(filename);
                //Tuple<int[], int> hist_data = 
                op.subtract(pic, pic_3, g);
                // so that Mask im >> pic_3 , blurred >> pic_1 .

                // #3 3.	Add a weighted portion from the mask to the original image 
                // K × Mask(x,y)
                //op.multiplication(pic_3, k);
                pic = new Bitmap(filename);
                pic = op.unsharp_add(pic, pic_3, k);

                pic_3 = new Bitmap(filename);
                g.DrawImage(pic_3, 650, 200, pic_3.Width, pic_3.Height);
                g.DrawImage(pic, 50, 200, pic.Width, pic.Height);
                pic.Save("d:\\IM\\unsharp.png");
                 * */
 
            }

        }
        
        /*
        public Bitmap multiplication(Bitmap pic, double k)
        {
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int newvalr = (int)(pixelColor.R * k);
                    int newvalg = (int)(pixelColor.G * k);
                    int newvalb = (int)(pixelColor.B * k);
                    pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }

            return pic;
        }
        */
        public Bitmap unsharp_add(Bitmap pic_1, Bitmap pic_2, double k)
        {
            pic_1 = new Bitmap(pic_1, new Size(pic_2.Width, pic_2.Height));
            for (int i = 0; i < pic_2.Width; i++)
                for (int j = 0; j < pic_2.Height; j++)
                {
                    Color pixelColor1 = pic_2.GetPixel(i, j);
                    Color pixelColor2 = pic_1.GetPixel(i, j);
                    int newvalr = (int)(pixelColor1.R * k + pixelColor2.R );
                    int newvalg = (int)(pixelColor1.G * k + pixelColor2.G );
                    int newvalb = (int)(pixelColor1.B * k + pixelColor2.B );
                    if (newvalr > 255)
                        newvalr = 255;

                    if (newvalg > 255)
                        newvalg = 255;
                    if (newvalb > 255)
                        newvalb = 255;
                    if (newvalr < 0)
                        newvalr = 0;
                    if (newvalg < 0)
                        newvalg = 0;
                    if (newvalb < 0)
                        newvalb = 0;
                    pic_2.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            return pic_2;
        }



    }
}
