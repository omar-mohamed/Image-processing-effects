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

namespace image_processing_package
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        string filename;
        public Bitmap pic;
        public Bitmap pic_2;
        public static Bitmap pic_4;
        public static Bitmap pic_3;
        public static Graphics g;
        public static Matrix X = new Matrix();
        Operations op = new Operations();
        protected override void OnShown(EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);

            //select_photo.PerformClick();
            // apply_button.PerformClick();
        }

        //Browse button
        private void select_button_Click(object sender, EventArgs e)
        {
                try
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    // ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        filename = ofd.FileName;
                        g = this.CreateGraphics();
                        g.Clear(this.BackColor);
                    }
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("something went wrong !!");
                    Application.Restart();
                }
                pic = new Bitmap(filename);
                g.DrawImage(pic, 350, 200, pic.Width, pic.Height);
            }

        private void select_another_button_Click(object sender, EventArgs e)
        {
            if (pic != null)
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
                pic_2 = new Bitmap(filename);
                g.Clear(this.BackColor);
                g.DrawImage(pic, 650, 30, pic.Width, pic.Height);
                g.DrawImage(pic_2, 650, 360, pic_2.Width, pic_2.Height);
            }
            else
                MessageBox.Show("please select the main photo first");

        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            pic = new Bitmap(filename);
            g.DrawImage(pic, 350, 200, pic.Width, pic.Height);

        }

        private void rotation_button_Click(object sender, EventArgs e)
        {

            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //Matrix X = new Matrix();
            X.Translate(150f + pic.Width / 2, 120f + pic.Height / 2);
            X.Rotate(Convert.ToSingle(angle_textBox.Text));
            X.Translate(-150f - pic.Width / 2, -120f - pic.Height / 2);
            g.Transform = X;
            // Draw image
            g.DrawImage(pic, new Rectangle(350, 200, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel);
            pic.Save("d:\\IM\\rotation.png");
        }

        private void shear_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
           // Matrix X = new Matrix();
            X.Translate(150f + pic.Width / 2, 120f + pic.Height / 2);
            X.Shear(Convert.ToSingle(shear_x_textBox.Text), Convert.ToSingle(shear_y_textBox.Text));
            X.Translate(-150f - pic.Width / 2, -120f - pic.Height / 2);
            g.Transform = X;
            // Draw image
            g.DrawImage(pic, new Rectangle(350, 200, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel);
            pic.Save("d:\\IM\\shear.png");
        }

        private void scale_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //Matrix X = new Matrix();
            X.Translate(150f + pic.Width / 2, 120f + pic.Height / 2);
            X.Scale(Convert.ToSingle(scale_x_textBox.Text), Convert.ToSingle(scale_y_textBox.Text));
            X.Translate(-150f - pic.Width / 2, -120f - pic.Height / 2);
            g.Transform = X;
            // Draw image
            g.DrawImage(pic, new Rectangle(50, 100, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel);
            pic.Save("d:\\IM\\scale.png");
        }

        private void all_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            X.Translate(150f + pic.Width / 2, 120f + pic.Height / 2);
            X.Scale(Convert.ToSingle(scale_x_textBox.Text), Convert.ToSingle(scale_y_textBox.Text));
            X.Translate(-150f - pic.Width / 2, -120f - pic.Height / 2);
            g.Transform = X;

            X.Translate(150f + pic.Width / 2, 120f + pic.Height / 2);
            X.Rotate(Convert.ToSingle(angle_textBox.Text));
            X.Translate(-150f - pic.Width / 2, -120f - pic.Height / 2);
            g.Transform = X;

            X.Translate(150f + pic.Width / 2, 120f + pic.Height / 2);
            X.Shear(Convert.ToSingle(shear_x_textBox.Text), Convert.ToSingle(shear_y_textBox.Text));
            X.Translate(-150f - pic.Width / 2, -120f - pic.Height / 2);
            g.Transform = X;

            // Draw image
            g.DrawImage(pic, new Rectangle(350, 200, pic.Width, pic.Height), 0, 0, pic.Width, pic.Height, GraphicsUnit.Pixel);
            pic.Save("d:\\IM\\all.png");

        }

        //*******************************************************************************************************************
        private void brightness_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //Tuple<int[], int> hist_data =
                op.brightness(pic, Convert.ToInt32(brightness_offset_textBox.Text)  , g);
            //op.drawHistogram(g, pic, hist_data.Item1, hist_data.Item2);
            //pic.Save("d:\\IM\\brightness.png");
        }

        private void contarst_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //Tuple<int[], int> hist_data = 
                op.contrast(pic, Convert.ToDouble(contrast_min_textBox.Text), Convert.ToDouble(contrast_max_textBox.Text),g);
            //op.drawHistogram(g, pic, hist_data.Item1, hist_data.Item2);
            //pic.Save("d:\\IM\\contrast.png");
        }

        private void gamma_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
           // Tuple<int[], int> hist_data =
                op.gamma(pic, Convert.ToDouble(gamma_value_textBox.Text), g);
            //op.drawHistogram(g, pic, hist_data.Item1, hist_data.Item2);
           // pic.Save("d:\\IM\\gamma_1.png");
        }

        private void equalization_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Tuple<int[], int> hist_data = op.equalizedHistogram(pic , g);
            pic = new Bitmap(filename);
            op.drawHistogram(g, pic, hist_data.Item1, hist_data.Item2);
            pic.Save("d:\\IM\\equalization.png");
        }

        private void gray__button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Tuple<int[], int> hist_data = op.grayScale(pic);
            op.drawHistogram(g, pic, hist_data.Item1, hist_data.Item2);
            pic.Save("d:\\IM\\gray.png");
        }

        private void not__button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Tuple<int[], int> hist_data = op.not(pic);
            op.drawHistogram(g, pic, hist_data.Item1, hist_data.Item2);
            pic.Save("d:\\IM\\not.png");
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //Tuple<int[], int> hist_data = 
                op.add(pic , pic_2, Convert.ToDouble(add_fraction_textBox.Text) , g);
            //Bitmap pic_3 = new Bitmap(filename);
           // op.drawHistogram_logicOperations(g, pic, pic_3, pic_2, hist_data.Item1, hist_data.Item2);
            //g.DrawImage(pic, 300, 200, 300, 300);
            //pic_2.Save("d:\\IM\\add.png");
        }

        private void subtract_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //Tuple<int[], int> hist_data =
                op.subtract(pic, pic_2 , g);
            //Bitmap pic_3 = new Bitmap(filename);
            //op.drawHistogram_logicOperations(g, pic, pic_3, pic_2, hist_data.Item1, hist_data.Item2);
            //g.DrawImage(pic, 300, 200, 300, 300);
            //pic_2.Save("d:\\IM\\subtract.png");
        }

        private void bit_slicing_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Tuple<int[], int> hist_data = op.bit_slicing(pic, pixel_index_textBox.Text);
            op.drawHistogram(g, pic, hist_data.Item1, hist_data.Item2);
            pic.Save("d:\\IM\\bit_slicing.png");
        }

        //filters
        //************************************************************************************************************************************
        public enum post_process
        {
            cutoff,
            normalization,
            nothing
        };

        private void mean_filter_button_Click(object sender, EventArgs e)
        {

            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            int origX = Convert.ToInt32(mean_origX_textBox.Text);
            int origY = Convert.ToInt32(mean_origY_textBox.Text);
            int filter_width = Convert.ToInt32(mean_width_textBox.Text);
            int filter_height = Convert.ToInt32(mean_height_textBox.Text);
            post_process p = post_process.nothing;

            op.linearFilter(op.padding(pic, filter_width, filter_height), op.meanFilter(filter_width, filter_height), origX, origY, p , g,0);
            //pic_2 = new Bitmap(filename);
            //g.DrawImage(pic_2, 650, 200, pic_2.Width, pic_2.Height);
            //g.DrawImage(pic, 50, 200, pic.Width, pic.Height);
            //pic.Save("d:\\IM\\mean_filter.png");

        }

        private void gaussian_filter_1_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);

            int mask_size = Convert.ToInt32(mask_size_1_textBox.Text);
            double sigma = Convert.ToDouble(sigma_1_textBox.Text);
            int filter_width = mask_size;
            int filter_height = mask_size;
            post_process p = post_process.nothing;

           op.linearFilter(op.padding(pic, filter_width, filter_height), op.gaussianFilter_1(mask_size, sigma), filter_width / 2, filter_height / 2 , p , g,0);
            /*
            pic_2 = new Bitmap(filename);
            g.DrawImage(pic_2, 650, 200, pic_2.Width, pic_2.Height);
            g.DrawImage(pic, 50, 200, pic.Width, pic.Height);
            pic.Save("d:\\IM\\gaussian_1.png");
             * */
        }

        private void gaussian_filter_2_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);

            double sigma = Convert.ToDouble(sigma_2_textBox.Text);
            //Compute Mask Size
            int n = (int)(3.7 * sigma - 0.5);
            double mask_size = 2 * n + 1;

            int filter_width = (int)mask_size;
            int filter_height = (int)mask_size;
            post_process p = post_process.nothing;

           op.linearFilter(op.padding(pic, filter_width, filter_height), op.gaussianFilter_2(sigma), filter_width / 2, filter_height / 2 , p , g,0 );
            /*
            pic_2 = new Bitmap(filename);
            g.DrawImage(pic_2, 650, 200, pic_2.Width, pic_2.Height);
            g.DrawImage(pic, 50, 200, pic.Width, pic.Height);
            pic.Save("d:\\IM\\gaussian_2.png");
             * */
        }

        private void laplacian_sharpening_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);

            int filter_width = 3;
            int filter_height = 3;
            post_process p = post_process.cutoff;
            op.linearFilter(op.padding(pic, filter_width, filter_height), op.laplacian_filter(), filter_width / 2, filter_height / 2 , p,g,0);
            //pic = op.laplacian_sharping(op.padding(pic, filter_width, filter_height), op.laplacian_filter());
            pic_2 = new Bitmap(filename);
            g.DrawImage(pic_2, 650, 200, pic_2.Width, pic_2.Height);
            g.DrawImage(pic, 50, 200, pic.Width, pic.Height);
            pic.Save("d:\\IM\\laplacian.png");
        }

        private void unsharp_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);

            int mask_size = Convert.ToInt32(unsharp_mask_size_textBox.Text);
            double sigma = Convert.ToDouble(unsharp_sigma_textBox.Text);
            double k = Convert.ToDouble(unsharp_k_textBox.Text);

            // #1 Smooth the original image using Gaussian filter [Option1]
            int filter_width = mask_size;
            int filter_height = mask_size;
            post_process p = post_process.nothing;
           // pic = op.linearFilter(op.padding(pic, filter_width, filter_height), op.gaussianFilter_1(mask_size, sigma), filter_width / 2, filter_height / 2, p);

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

        }

        private void edge_detection_button_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);

            int direction = Convert.ToInt32(direction_textBox.Text);
            int filter_width = 3;
            int filter_height = 3;
            post_process p = post_process.normalization;
           // pic = op.linearFilter(op.padding(pic, filter_width, filter_height), op.edgeDetection_filter(direction), filter_width / 2, filter_height / 2, p);
            pic_2 = new Bitmap(filename);
            g.DrawImage(pic_2, 650, 200, pic_2.Width, pic_2.Height);
            g.DrawImage(pic, 50, 200, pic.Width, pic.Height);
            pic.Save("d:\\IM\\edge.png");

        }






    }
}
