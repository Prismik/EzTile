namespace eztile
{
    partial class newMap
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
            this.mapHeight = new System.Windows.Forms.NumericUpDown();
            this.mapWidth = new System.Windows.Forms.NumericUpDown();
            this.mapSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tileHeight = new System.Windows.Forms.NumericUpDown();
            this.tileWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidth)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mapHeight);
            this.groupBox1.Controls.Add(this.mapWidth);
            this.groupBox1.Controls.Add(this.mapSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map";
            // 
            // mapHeight
            // 
            this.mapHeight.Location = new System.Drawing.Point(80, 58);
            this.mapHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.mapHeight.Name = "mapHeight";
            this.mapHeight.Size = new System.Drawing.Size(103, 20);
            this.mapHeight.TabIndex = 4;
            this.mapHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.mapHeight.ValueChanged += new System.EventHandler(this.mapHeight_ValueChanged);
            // 
            // mapWidth
            // 
            this.mapWidth.Location = new System.Drawing.Point(80, 32);
            this.mapWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.mapWidth.Name = "mapWidth";
            this.mapWidth.Size = new System.Drawing.Size(103, 20);
            this.mapWidth.TabIndex = 3;
            this.mapWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.mapWidth.ValueChanged += new System.EventHandler(this.mapWidth_ValueChanged);
            // 
            // mapSize
            // 
            this.mapSize.AutoSize = true;
            this.mapSize.Location = new System.Drawing.Point(18, 87);
            this.mapSize.Name = "mapSize";
            this.mapSize.Size = new System.Drawing.Size(95, 13);
            this.mapSize.TabIndex = 2;
            this.mapSize.Text = "3200 x 3200 pixels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tileHeight);
            this.groupBox2.Controls.Add(this.tileWidth);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(209, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 116);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tile";
            // 
            // tileHeight
            // 
            this.tileHeight.Location = new System.Drawing.Point(71, 58);
            this.tileHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tileHeight.Name = "tileHeight";
            this.tileHeight.Size = new System.Drawing.Size(83, 20);
            this.tileHeight.TabIndex = 3;
            this.tileHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tileHeight.ValueChanged += new System.EventHandler(this.tileHeight_ValueChanged);
            // 
            // tileWidth
            // 
            this.tileWidth.Location = new System.Drawing.Point(71, 32);
            this.tileWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tileWidth.Name = "tileWidth";
            this.tileWidth.Size = new System.Drawing.Size(83, 20);
            this.tileWidth.TabIndex = 2;
            this.tileWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tileWidth.ValueChanged += new System.EventHandler(this.tileWidth_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Width:";
            // 
            // newMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(397, 174);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "newMap";
            this.Text = "New map";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown mapHeight;
        private System.Windows.Forms.NumericUpDown mapWidth;
        private System.Windows.Forms.Label mapSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown tileHeight;
        private System.Windows.Forms.NumericUpDown tileWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}