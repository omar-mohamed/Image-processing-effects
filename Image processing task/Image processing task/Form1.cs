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
namespace Image_processing_task
{
    public partial class Form1 : Form
    {
        string filenameO;
        private Bitmap pic;
        private Bitmap pic2;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        //Browse button
        private void button3_Click_1(object sender, EventArgs e)
        {
            string filename;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                 filename = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                 pic2 = new Bitmap(filename);
            }
            
           
        }
        protected override void OnShown(EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
        //    pic = new Bitmap(filenameO);
            
            
        //    grayScale();
         //   pic = new Bitmap(@"Jaguar.bmp");
            
          //  g.DrawImage(pic, 450, 250, 220, 220);
           
        }


        private void contrast(double newmin,double newmax)
        {
            int[] hist = new int[256];
            int max = 0;
            //contrast
            double oldmin = 0;
            double oldmax = -1;


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
                    if (hist[j] > 0 && oldmin == -1)
                        oldmin = j;
                    if (hist[j] > 0)
                        oldmax = j;
                }
                hist = new int[256];
                for (int i = 0; i < pic.Width; i++)
                    for (int j = 0; j < pic.Height; j++)
                    {
                        Color pixelColor = pic.GetPixel(i, j);
                        int newvalr = (int)(((pixelColor.R - oldmin) / (oldmax - oldmin)) * (newmax - newmin) + newmin);
                        int newvalg = (int)(((pixelColor.G - oldmin) / (oldmax - oldmin)) * (newmax - newmin) + newmin);
                        int newvalb = (int)(((pixelColor.B - oldmin) / (oldmax - oldmin)) * (newmax - newmin) + newmin);
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

            drawHistogram(hist, max);
        }

        private void grayScale()
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
            drawHistogram(hist, max);
        }

        private void Subtract()
        {
            int[] hist = new int[256];
            int max = 0;
            pic2 = new Bitmap(pic2, new Size(pic.Width, pic.Height));
           // Graphics g = this.CreateGraphics();
           // g.Clear(this.BackColor);



            for (int i = 0; i < pic.Width ; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor1 = pic.GetPixel(i, j);
                    Color pixelColor2 = pic2.GetPixel(i, j);
                    int newvalr = pixelColor1.R - pixelColor2.R;
                    int newvalg = pixelColor1.G - pixelColor2.G;
                    int newvalb = pixelColor1.B - pixelColor2.B;
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
            drawHistogram(hist, max);


        }

        private void Add(double fraction)
        {
            int[] hist = new int[256];
            int max = 0;
            pic2 = new Bitmap(pic2, new Size(pic.Width, pic.Height));
         //   Graphics g = this.CreateGraphics();
          //  g.Clear(this.BackColor);
        



            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor1 = pic.GetPixel(i, j);
                    Color pixelColor2 = pic2.GetPixel(i, j);
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
                    pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            drawHistogram(hist, max);


        }

        private void drawHistogram(int[] hist ,int max)
        {
            int histHeight = 10;
            Bitmap img = new Bitmap(800, histHeight + 500);

            for (int i = 0; i < hist.Length; i++)
            {
                float pct = hist[i] / (float)max;   // What percentage of the max is this value?
                g.DrawLine(Pens.Black,
                    new Point(i, img.Height - 1),   
                    new Point(i, img.Height - 1 - (int)(pct * histHeight)));
            }
        }

        private void equalizedHistogram()
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

            double sum = 0;
            double num_pixels = pic.Width * pic.Height;
            double newR = 7; 
            int[] round = new int[256];
            for (int i = 0; i < hist.Length; i++)
            {
                sum += hist[i];
                round[i] =(int) Math.Round((sum / num_pixels) * newR);
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
             drawHistogram(hist, max);

        }

        private void Gamma(double gamma)
        {
            int[] hist = new int[256];
            int max = 0;
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int newvalr = (int)Math.Pow(pixelColor.R,gamma);
                    int newvalg = (int)Math.Pow(pixelColor.G,gamma);
                    int newvalb = (int)Math.Pow(pixelColor.B, gamma);
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
            drawHistogram(hist, max);
        }

        private void brightness(int bright)
        {
            int[] hist = new int[256];
            int max = 0;
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int newvalr =pixelColor.R+ bright;
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
            drawHistogram(hist, max);
        }


        private void Not()
        {
            int[] hist = new int[256];
            int max = 0;
            for (int i = 0; i < pic.Width; i++)
                for (int j = 0; j < pic.Height; j++)
                {
                    Color pixelColor = pic.GetPixel(i, j);
                    int newvalr = 255- pixelColor.R ;
                    int newvalg = 255- pixelColor.G ;
                    int newvalb = 255- pixelColor.B ;
                    int gray = (int)(newvalr * 0.3 + newvalg * 0.59 + newvalb * 0.11);
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                    pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            drawHistogram(hist, max);
        }

        private void Bit_slicing(string bits)
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
                    int newvalr = bit& pixelColor.R;
                    int newvalg = bit&  pixelColor.G;
                    int newvalb = bit&  pixelColor.B;
                    //if ((gray & bit) == 0)
                    //    gray = 0;
                    //else
                    //    gray = 255;
                    if (gray > max)
                        max = gray;
                    hist[gray]++;
                    pic.SetPixel(i, j, Color.FromArgb(newvalr, newvalg, newvalb));
                }
            drawHistogram(hist, max);
        }

        private void Not_click_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Not();
            g.DrawImage(pic, 450, 250, 220, 220);
        }

        private void original__Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            grayScale();
            pic = new Bitmap(filenameO);
            g.DrawImage(pic, 450, 250, 220, 220);
        }

        private void Equalization_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            equalizedHistogram();
            pic = new Bitmap(filenameO);
            g.DrawImage(pic, 450, 250, 220, 220);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void contarst__Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            contrast(Convert.ToDouble(Contrast_min.Text), Convert.ToDouble(contrast_max.Text));
            g.DrawImage(pic, 450, 250, 220, 220);
        }

        private void Brightness__Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            brightness(Convert.ToInt32(Brightness_offset.Text));
            g.DrawImage(pic, 450, 250, 220, 220);
        }


        private void Gray__Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            grayScale();
            g.DrawImage(pic, 450, 250, 220, 220);
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Bit_slicing(index_.Text);
            g.DrawImage(pic, 450, 250, 220, 220);
        }
        private void gamma__Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Gamma(Convert.ToDouble(gamma_value.Text));
            g.DrawImage(pic, 450, 250, 220, 220);
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        //Add button
        private void button2_Click_1(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Add(Convert.ToDouble(textBox1.Text));
            g.DrawImage(pic, 450, 250, 220, 220);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Subtract button
        private void button3_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Subtract();
            g.DrawImage(pic, 450, 250, 220, 220);
        }

        private void gamma_value_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
           
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                 filenameO = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                 pic = new Bitmap(filenameO);
            }
            g.DrawImage(pic, 450, 250, 220, 220);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void filters_button_Click(object sender, EventArgs e)
        {
            Filters x = new Filters();
            x.Show();
        }

        


        

       



    }
}
