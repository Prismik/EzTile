namespace eztile
{
    partial class newTileSheet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tilesheetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spacing = new System.Windows.Forms.NumericUpDown();
            this.margin = new System.Windows.Forms.NumericUpDown();
            this.tileHeight = new System.Windows.Forms.NumericUpDown();
            this.tileWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.margin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.imageLocation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tilesheetName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tilesheet";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageLocation
            // 
            this.imageLocation.Location = new System.Drawing.Point(60, 56);
            this.imageLocation.Name = "imageLocation";
            this.imageLocation.Size = new System.Drawing.Size(234, 20);
            this.imageLocation.TabIndex = 3;
            this.imageLocation.TextChanged += new System.EventHandler(this.imageLocation_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image:";
            // 
            // tilesheetName
            // 
            this.tilesheetName.Location = new System.Drawing.Point(60, 17);
            this.tilesheetName.Name = "tilesheetName";
            this.tilesheetName.Size = new System.Drawing.Size(315, 20);
            this.tilesheetName.TabIndex = 1;
            this.tilesheetName.TextChanged += new System.EventHandler(this.tilesheetName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spacing);
            this.groupBox2.Controls.Add(this.margin);
            this.groupBox2.Controls.Add(this.tileHeight);
            this.groupBox2.Controls.Add(this.tileWidth);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiles";
            // 
            // spacing
            // 
            this.spacing.Location = new System.Drawing.Point(230, 61);
            this.spacing.Name = "spacing";
            this.spacing.Size = new System.Drawing.Size(120, 20);
            this.spacing.TabIndex = 7;
            // 
            // margin
            // 
            this.margin.Location = new System.Drawing.Point(230, 17);
            this.margin.Name = "margin";
            this.margin.Size = new System.Drawing.Size(120, 20);
            this.margin.TabIndex = 6;
            // 
            // tileHeight
            // 
            this.tileHeight.Location = new System.Drawing.Point(56, 61);
            this.tileHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tileHeight.Name = "tileHeight";
            this.tileHeight.Size = new System.Drawing.Size(98, 20);
            this.tileHeight.TabIndex = 5;
            this.tileHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tileHeight.ValueChanged += new System.EventHandler(this.tileHeight_ValueChanged);
            // 
            // tileWidth
            // 
            this.tileWidth.Location = new System.Drawing.Point(57, 17);
            this.tileWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tileWidth.Name = "tileWidth";
            this.tileWidth.Size = new System.Drawing.Size(97, 20);
            this.tileWidth.TabIndex = 4;
            this.tileWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tileWidth.ValueChanged += new System.EventHandler(this.tileWidth_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Spacing:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Margin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Width:";
            // 
            // newTileSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(406, 270);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "newTileSheet";
            this.Text = "New tilesheet";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.margin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tilesheetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox imageLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown spacing;
        private System.Windows.Forms.NumericUpDown margin;
        private System.Windows.Forms.NumericUpDown tileHeight;
        private System.Windows.Forms.NumericUpDown tileWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}