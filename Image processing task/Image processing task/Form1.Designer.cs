namespace Image_processing_task
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Not_click = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.original_ = new System.Windows.Forms.Button();
            this.Equalization = new System.Windows.Forms.Button();
            this.contarst_ = new System.Windows.Forms.Button();
            this.Contrast_min = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contrast_max = new System.Windows.Forms.TextBox();
            this.Brightness_ = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Brightness_offset = new System.Windows.Forms.TextBox();
            this.gamma_value = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gamma_ = new System.Windows.Forms.Button();
            this.Gray_ = new System.Windows.Forms.Button();
            this.Bit_slicing__ = new System.Windows.Forms.Button();
            this.index_ = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Subtract_ = new System.Windows.Forms.Button();
            this.Browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.filters_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Not_click
            // 
            this.Not_click.Location = new System.Drawing.Point(456, 65);
            this.Not_click.Name = "Not_click";
            this.Not_click.Size = new System.Drawing.Size(75, 23);
            this.Not_click.TabIndex = 0;
            this.Not_click.Text = "Not";
            this.Not_click.UseVisualStyleBackColor = true;
            this.Not_click.Click += new System.EventHandler(this.Not_click_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1041, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "original";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // original_
            // 
            this.original_.Location = new System.Drawing.Point(456, 13);
            this.original_.Name = "original_";
            this.original_.Size = new System.Drawing.Size(75, 23);
            this.original_.TabIndex = 2;
            this.original_.Text = "Original";
            this.original_.UseVisualStyleBackColor = true;
            this.original_.Click += new System.EventHandler(this.original__Click);
            // 
            // Equalization
            // 
            this.Equalization.Location = new System.Drawing.Point(298, 12);
            this.Equalization.Name = "Equalization";
            this.Equalization.Size = new System.Drawing.Size(126, 23);
            this.Equalization.TabIndex = 3;
            this.Equalization.Text = "Histogram Equalization";
            this.Equalization.UseVisualStyleBackColor = true;
            this.Equalization.Click += new System.EventHandler(this.Equalization_Click);
            // 
            // contarst_
            // 
            this.contarst_.Location = new System.Drawing.Point(12, 12);
            this.contarst_.Name = "contarst_";
            this.contarst_.Size = new System.Drawing.Size(60, 23);
            this.contarst_.TabIndex = 4;
            this.contarst_.Text = "Contrast";
            this.contarst_.UseVisualStyleBackColor = true;
            this.contarst_.Click += new System.EventHandler(this.contarst__Click);
            // 
            // Contrast_min
            // 
            this.Contrast_min.Location = new System.Drawing.Point(117, 15);
            this.Contrast_min.Name = "Contrast_min";
            this.Contrast_min.Size = new System.Drawing.Size(40, 20);
            this.Contrast_min.TabIndex = 5;
            this.Contrast_min.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Min";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Max";
            // 
            // contrast_max
            // 
            this.contrast_max.Location = new System.Drawing.Point(198, 15);
            this.contrast_max.Name = "contrast_max";
            this.contrast_max.Size = new System.Drawing.Size(40, 20);
            this.contrast_max.TabIndex = 7;
            this.contrast_max.Text = "255";
            // 
            // Brightness_
            // 
            this.Brightness_.Location = new System.Drawing.Point(10, 62);
            this.Brightness_.Name = "Brightness_";
            this.Brightness_.Size = new System.Drawing.Size(60, 23);
            this.Brightness_.TabIndex = 9;
            this.Brightness_.Text = "Brightness";
            this.Brightness_.UseVisualStyleBackColor = true;
            this.Brightness_.Click += new System.EventHandler(this.Brightness__Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Offset";
            // 
            // Brightness_offset
            // 
            this.Brightness_offset.Location = new System.Drawing.Point(115, 65);
            this.Brightness_offset.Name = "Brightness_offset";
            this.Brightness_offset.Size = new System.Drawing.Size(40, 20);
            this.Brightness_offset.TabIndex = 11;
            this.Brightness_offset.Text = "0";
            // 
            // gamma_value
            // 
            this.gamma_value.Location = new System.Drawing.Point(292, 68);
            this.gamma_value.Name = "gamma_value";
            this.gamma_value.Size = new System.Drawing.Size(40, 20);
            this.gamma_value.TabIndex = 14;
            this.gamma_value.Text = "1";
            this.gamma_value.TextChanged += new System.EventHandler(this.gamma_value_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "value";
            // 
            // gamma_
            // 
            this.gamma_.Location = new System.Drawing.Point(187, 65);
            this.gamma_.Name = "gamma_";
            this.gamma_.Size = new System.Drawing.Size(60, 23);
            this.gamma_.TabIndex = 12;
            this.gamma_.Text = "Gamma";
            this.gamma_.UseVisualStyleBackColor = true;
            this.gamma_.Click += new System.EventHandler(this.gamma__Click);
            // 
            // Gray_
            // 
            this.Gray_.Location = new System.Drawing.Point(349, 65);
            this.Gray_.Name = "Gray_";
            this.Gray_.Size = new System.Drawing.Size(75, 23);
            this.Gray_.TabIndex = 15;
            this.Gray_.Text = "Gray";
            this.Gray_.UseVisualStyleBackColor = true;
            this.Gray_.Click += new System.EventHandler(this.Gray__Click);
            // 
            // Bit_slicing__
            // 
            this.Bit_slicing__.Location = new System.Drawing.Point(10, 108);
            this.Bit_slicing__.Name = "Bit_slicing__";
            this.Bit_slicing__.Size = new System.Drawing.Size(75, 23);
            this.Bit_slicing__.TabIndex = 16;
            this.Bit_slicing__.Text = "Bit_slicing";
            this.Bit_slicing__.UseVisualStyleBackColor = true;
            this.Bit_slicing__.Click += new System.EventHandler(this.button2_Click);
            // 
            // index_
            // 
            this.index_.Location = new System.Drawing.Point(91, 111);
            this.index_.Name = "index_";
            this.index_.Size = new System.Drawing.Size(40, 20);
            this.index_.TabIndex = 17;
            this.index_.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Fraction";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(481, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Subtract_
            // 
            this.Subtract_.Location = new System.Drawing.Point(548, 121);
            this.Subtract_.Name = "Subtract_";
            this.Subtract_.Size = new System.Drawing.Size(75, 23);
            this.Subtract_.TabIndex = 21;
            this.Subtract_.Text = "Subtract";
            this.Subtract_.UseVisualStyleBackColor = true;
            this.Subtract_.Click += new System.EventHandler(this.button3_Click);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(247, 107);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 49);
            this.Browse.TabIndex = 22;
            this.Browse.Text = "Select the second photo";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(151, 107);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 49);
            this.button3.TabIndex = 23;
            this.button3.Text = "Select the first photo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // filters_button
            // 
            this.filters_button.Location = new System.Drawing.Point(687, 18);
            this.filters_button.Name = "filters_button";
            this.filters_button.Size = new System.Drawing.Size(75, 23);
            this.filters_button.TabIndex = 24;
            this.filters_button.Text = "Filters";
            this.filters_button.UseVisualStyleBackColor = true;
            this.filters_button.Click += new System.EventHandler(this.filters_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 547);
            this.Controls.Add(this.filters_button);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Subtract_);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.index_);
            this.Controls.Add(this.Bit_slicing__);
            this.Controls.Add(this.Gray_);
            this.Controls.Add(this.gamma_value);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gamma_);
            this.Controls.Add(this.Brightness_offset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Brightness_);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contrast_max);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Contrast_min);
            this.Controls.Add(this.contarst_);
            this.Controls.Add(this.Equalization);
            this.Controls.Add(this.original_);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Not_click);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Not_click;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button original_;
        private System.Windows.Forms.Button Equalization;
        private System.Windows.Forms.Button contarst_;
        private System.Windows.Forms.TextBox Contrast_min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contrast_max;
        private System.Windows.Forms.Button Brightness_;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Brightness_offset;
        private System.Windows.Forms.TextBox gamma_value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button gamma_;
        private System.Windows.Forms.Button Gray_;
        private System.Windows.Forms.Button Bit_slicing__;
        private System.Windows.Forms.TextBox index_;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Subtract_;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button filters_button;



    }
}

