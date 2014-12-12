namespace Image_processing_task
{
    partial class Filters
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
            this.select_button = new System.Windows.Forms.Button();
            this.MeanFilter_button = new System.Windows.Forms.Button();
            this.gaussian_filter_1_button = new System.Windows.Forms.Button();
            this.gaussian_filter_2_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mask_size_1_textBox = new System.Windows.Forms.TextBox();
            this.sigma_1_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sigma_2_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.laplacian_sharpening_button = new System.Windows.Forms.Button();
            this.unsharp_sigma_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.unsharp_mask_size_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.unsharp_button = new System.Windows.Forms.Button();
            this.unsharp_k_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edge_detection_button = new System.Windows.Forms.Button();
            this.mean_OrigY_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mean_OrigX_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.reset_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // select_button
            // 
            this.select_button.Location = new System.Drawing.Point(21, 439);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(75, 37);
            this.select_button.TabIndex = 0;
            this.select_button.Text = "Select a Photo";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.select_button_Click_1);
            // 
            // MeanFilter_button
            // 
            this.MeanFilter_button.Location = new System.Drawing.Point(21, 17);
            this.MeanFilter_button.Name = "MeanFilter_button";
            this.MeanFilter_button.Size = new System.Drawing.Size(75, 37);
            this.MeanFilter_button.TabIndex = 1;
            this.MeanFilter_button.Text = "Mean Filter";
            this.MeanFilter_button.UseVisualStyleBackColor = true;
            this.MeanFilter_button.Click += new System.EventHandler(this.MeanFilter_button_Click);
            // 
            // gaussian_filter_1_button
            // 
            this.gaussian_filter_1_button.Location = new System.Drawing.Point(232, 17);
            this.gaussian_filter_1_button.Name = "gaussian_filter_1_button";
            this.gaussian_filter_1_button.Size = new System.Drawing.Size(75, 37);
            this.gaussian_filter_1_button.TabIndex = 2;
            this.gaussian_filter_1_button.Text = "Gaussian Filter 1";
            this.gaussian_filter_1_button.UseVisualStyleBackColor = true;
            this.gaussian_filter_1_button.Click += new System.EventHandler(this.gaussian_filter_1_button_Click);
            // 
            // gaussian_filter_2_button
            // 
            this.gaussian_filter_2_button.Location = new System.Drawing.Point(448, 17);
            this.gaussian_filter_2_button.Name = "gaussian_filter_2_button";
            this.gaussian_filter_2_button.Size = new System.Drawing.Size(75, 37);
            this.gaussian_filter_2_button.TabIndex = 3;
            this.gaussian_filter_2_button.Text = "Gaussian Filter 2";
            this.gaussian_filter_2_button.UseVisualStyleBackColor = true;
            this.gaussian_filter_2_button.Click += new System.EventHandler(this.gaussian_filter_2_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MaskSize";
            // 
            // mask_size_1_textBox
            // 
            this.mask_size_1_textBox.Location = new System.Drawing.Point(369, 18);
            this.mask_size_1_textBox.Name = "mask_size_1_textBox";
            this.mask_size_1_textBox.Size = new System.Drawing.Size(56, 20);
            this.mask_size_1_textBox.TabIndex = 5;
            // 
            // sigma_1_textBox
            // 
            this.sigma_1_textBox.Location = new System.Drawing.Point(369, 38);
            this.sigma_1_textBox.Name = "sigma_1_textBox";
            this.sigma_1_textBox.Size = new System.Drawing.Size(56, 20);
            this.sigma_1_textBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sigma";
            // 
            // sigma_2_textBox
            // 
            this.sigma_2_textBox.Location = new System.Drawing.Point(570, 26);
            this.sigma_2_textBox.Name = "sigma_2_textBox";
            this.sigma_2_textBox.Size = new System.Drawing.Size(56, 20);
            this.sigma_2_textBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sigma";
            // 
            // laplacian_sharpening_button
            // 
            this.laplacian_sharpening_button.Location = new System.Drawing.Point(652, 17);
            this.laplacian_sharpening_button.Name = "laplacian_sharpening_button";
            this.laplacian_sharpening_button.Size = new System.Drawing.Size(75, 37);
            this.laplacian_sharpening_button.TabIndex = 10;
            this.laplacian_sharpening_button.Text = "Laplacian Sharpening";
            this.laplacian_sharpening_button.UseVisualStyleBackColor = true;
            this.laplacian_sharpening_button.Click += new System.EventHandler(this.laplacian_sharpening_button_Click);
            // 
            // unsharp_sigma_textBox
            // 
            this.unsharp_sigma_textBox.Location = new System.Drawing.Point(879, 26);
            this.unsharp_sigma_textBox.Name = "unsharp_sigma_textBox";
            this.unsharp_sigma_textBox.Size = new System.Drawing.Size(56, 20);
            this.unsharp_sigma_textBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(823, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Sigma";
            // 
            // unsharp_mask_size_textBox
            // 
            this.unsharp_mask_size_textBox.Location = new System.Drawing.Point(879, 6);
            this.unsharp_mask_size_textBox.Name = "unsharp_mask_size_textBox";
            this.unsharp_mask_size_textBox.Size = new System.Drawing.Size(56, 20);
            this.unsharp_mask_size_textBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(823, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "MaskSize";
            // 
            // unsharp_button
            // 
            this.unsharp_button.Location = new System.Drawing.Point(742, 17);
            this.unsharp_button.Name = "unsharp_button";
            this.unsharp_button.Size = new System.Drawing.Size(75, 37);
            this.unsharp_button.TabIndex = 11;
            this.unsharp_button.Text = "Unsharp & Highboost";
            this.unsharp_button.UseVisualStyleBackColor = true;
            this.unsharp_button.Click += new System.EventHandler(this.unsharp_button_Click);
            // 
            // unsharp_k_textBox
            // 
            this.unsharp_k_textBox.Location = new System.Drawing.Point(879, 46);
            this.unsharp_k_textBox.Name = "unsharp_k_textBox";
            this.unsharp_k_textBox.Size = new System.Drawing.Size(56, 20);
            this.unsharp_k_textBox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(823, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "k";
            // 
            // edge_detection_button
            // 
            this.edge_detection_button.Location = new System.Drawing.Point(963, 17);
            this.edge_detection_button.Name = "edge_detection_button";
            this.edge_detection_button.Size = new System.Drawing.Size(75, 37);
            this.edge_detection_button.TabIndex = 18;
            this.edge_detection_button.Text = "Edge Detection";
            this.edge_detection_button.UseVisualStyleBackColor = true;
            this.edge_detection_button.Click += new System.EventHandler(this.edge_detection_button_Click);
            // 
            // mean_OrigY_textBox
            // 
            this.mean_OrigY_textBox.Location = new System.Drawing.Point(158, 35);
            this.mean_OrigY_textBox.Name = "mean_OrigY_textBox";
            this.mean_OrigY_textBox.Size = new System.Drawing.Size(56, 20);
            this.mean_OrigY_textBox.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "OrigY";
            // 
            // mean_OrigX_textBox
            // 
            this.mean_OrigX_textBox.Location = new System.Drawing.Point(158, 15);
            this.mean_OrigX_textBox.Name = "mean_OrigX_textBox";
            this.mean_OrigX_textBox.Size = new System.Drawing.Size(56, 20);
            this.mean_OrigX_textBox.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "OrigX";
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(116, 439);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(75, 37);
            this.reset_button.TabIndex = 23;
            this.reset_button.Text = "Reset";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 519);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.mean_OrigY_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mean_OrigX_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.edge_detection_button);
            this.Controls.Add(this.unsharp_k_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.unsharp_sigma_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unsharp_mask_size_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.unsharp_button);
            this.Controls.Add(this.laplacian_sharpening_button);
            this.Controls.Add(this.sigma_2_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sigma_1_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mask_size_1_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gaussian_filter_2_button);
            this.Controls.Add(this.gaussian_filter_1_button);
            this.Controls.Add(this.MeanFilter_button);
            this.Controls.Add(this.select_button);
            this.Name = "Filters";
            this.Text = "Filters";
            this.Load += new System.EventHandler(this.Filters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select_button;
        private System.Windows.Forms.Button MeanFilter_button;
        private System.Windows.Forms.Button gaussian_filter_1_button;
        private System.Windows.Forms.Button gaussian_filter_2_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mask_size_1_textBox;
        private System.Windows.Forms.TextBox sigma_1_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sigma_2_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button laplacian_sharpening_button;
        private System.Windows.Forms.TextBox unsharp_sigma_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox unsharp_mask_size_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button unsharp_button;
        private System.Windows.Forms.TextBox unsharp_k_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button edge_detection_button;
        private System.Windows.Forms.TextBox mean_OrigY_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mean_OrigX_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button reset_button;
    }
}