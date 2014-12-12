using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_processing_task
{
    public partial class Filters : Form
    {
        public Filters()
        {
            InitializeComponent();
        }

        private void Filters_Load(object sender, EventArgs e)
        {

        }

        string filename;

        private Bitmap pic;
        private Bitmap pic_padded;

        double[,] mask;
        int width, height;

        private Graphics g;


        protected override void OnShown(EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //    pic = new Bitmap(filenameO);


            //    grayScale();
            //   pic = new Bitmap(@"Jaguar.bmp");

            //  g.DrawImage(pic, 450, 250, 220, 220);

        }
        //Browse button
        private void select_button_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                // ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;

                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("something went wrong !!");
                Application.Restart();
            }
            pic = new Bitmap(filename);
            g.DrawImage(pic, 20, 75, 450, 350);
        }




        private double[,] MeanFilter(int width, int height)
        {

            this.width = width;
            this.height = height;

            mask = new double[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    mask[i, j] = 1.0f / (width * height);

                }
            return mask;

        }
        private void MeanFilter_Padding(Bitmap pic, int width, int height)
        {
            //this.width = width;
            //this.height = height;
            pic_padded = new Bitmap(pic, pic.Width + width, pic.Height + height);

            //pic = new Bitmap(pic.Width+width , pic.Height+height);
            for (int i = pic.Width + 1; i < pic_padded.Width; i++)
                for (int j =0; j < pic_padded.Height; j++)
                {
                    pic_padded.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            for (int i = 0; i < pic_padded.Width; i++)
                for (int j = pic.Height; j < pic_padded.Height; j++)
                {
                    pic_padded.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
        }

        //option 1
        private double[,] GaussianFilter(int maskSize, double sigma)
        {


            this.height = maskSize;
            this.width = maskSize;
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
        private double[,] GaussianFilter(double sigma)
        {

            //Compute Mask Size
            int n = (int)(3.7 * sigma - 0.5);

            double maskSize = 2 * n + 1;


            this.width = this.height = (int)maskSize;

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

        private double[,] laplacian_filter()
        {
            int filterWidth = 3;
            int filterHeight = 3;
            double[,] filter = new double[filterWidth, filterHeight];

            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;
            return filter;
 
        }
        //private double[,] unsharp(int mask_size, double sigma, double k)
        //{
        //    LinearFilter(pic, GaussianFilter(mask_size, sigma), (int)height / 2, (int)width / 2);
        //   // Bitmap smothedimage = pic_padded; pic
        //    return Filters;
        //}




        private void LinearFilter(Bitmap pic_padded, double[,] filter, int origX, int origY /*, Enum Postprocess*/)
        {
            int filterHeight = filter.GetLength(0);
            int filterWidth = filter.GetLength(1);


            //important
            // for GaussianFilter 2  filter replace filterHeight with height and filterWidth with width 



            int rAcc, gAcc, bAcc;
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
                            rAcc += (int)(filter[x, y] * pixelColor.R);
                            gAcc += (int)(filter[x, y] * pixelColor.G);
                            bAcc += (int)(filter[x, y] * pixelColor.B);
                        }
                    }
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
                    pic_padded.SetPixel(i + origX, j + origY, Color.FromArgb(rAcc, gAcc, bAcc));

                }
            }

            g = this.CreateGraphics();

            //g.Clear(this.BackColor);
            g.DrawImage(pic_padded, 550, 75, 450, 350);


        }

        // buttons

        private void MeanFilter_button_Click(object sender, EventArgs e)
        {
            int origX = Convert.ToInt32(mean_OrigX_textBox.Text);
            int origY = Convert.ToInt32(mean_OrigY_textBox.Text);
            MeanFilter_Padding(pic, 3, 3);
            //g = this.CreateGraphics();
            //g.DrawImage(pic_padded, 550, 75, 450, 350);
            LinearFilter(pic_padded, MeanFilter(3, 3), origX, origY);
        }

        private void gaussian_filter_1_button_Click(object sender, EventArgs e)
        {
            
            int mask_size = Convert.ToInt32(mask_size_1_textBox.Text);
            double sigma = Convert.ToDouble(sigma_1_textBox.Text);

            LinearFilter(pic, GaussianFilter(mask_size, sigma), (int)height / 2, (int)width / 2);
        }

        private void gaussian_filter_2_button_Click(object sender, EventArgs e)
        {

            double sigma = Convert.ToDouble(sigma_2_textBox.Text);

            LinearFilter(pic, GaussianFilter(sigma), (int)height / 2, (int)width / 2);
        }

        private void laplacian_sharpening_button_Click(object sender, EventArgs e)
        {
            LinearFilter(pic, laplacian_filter(), (int)height / 2, (int)width / 2);
        }

        private void unsharp_button_Click(object sender, EventArgs e)
        {
            
            int mask_size = Convert.ToInt32(unsharp_mask_size_textBox.Text);
            double sigma = Convert.ToDouble(unsharp_sigma_textBox.Text);
            double k = Convert.ToDouble(unsharp_k_textBox.Text);
            //LinearFilter(pic, unsharp(mask_size,sigma,k), (int)height / 2, (int)width / 2);

        }

        private void edge_detection_button_Click(object sender, EventArgs e)
        {

        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            pic = new Bitmap(filename);
            g.DrawImage(pic, 20, 75, 450, 350);
        }


    }
}