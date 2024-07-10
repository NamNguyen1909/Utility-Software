namespace Utility_Apps
{
    partial class SetShutdownTime
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetShutdownTime));
            this.numericUpDownHour = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownMinute = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownSecond = new System.Windows.Forms.NumericUpDown();
            this.btShutdown = new System.Windows.Forms.Button();
            this.btRestart = new System.Windows.Forms.Button();
            this.btCancle = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecond)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownHour
            // 
            this.numericUpDownHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownHour.Location = new System.Drawing.Point(89, 61);
            this.numericUpDownHour.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownHour.Name = "numericUpDownHour";
            this.numericUpDownHour.Size = new System.Drawing.Size(84, 34);
            this.numericUpDownHour.TabIndex = 0;
            this.numericUpDownHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "giờ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(351, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "phút";
            // 
            // numericUpDownMinute
            // 
            this.numericUpDownMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMinute.Location = new System.Drawing.Point(261, 61);
            this.numericUpDownMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownMinute.Name = "numericUpDownMinute";
            this.numericUpDownMinute.Size = new System.Drawing.Size(84, 34);
            this.numericUpDownMinute.TabIndex = 2;
            this.numericUpDownMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownMinute.ValueChanged += new System.EventHandler(this.numericUpDownMinute_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(529, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "giây";
            // 
            // numericUpDownSecond
            // 
            this.numericUpDownSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSecond.Location = new System.Drawing.Point(439, 61);
            this.numericUpDownSecond.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownSecond.Name = "numericUpDownSecond";
            this.numericUpDownSecond.Size = new System.Drawing.Size(84, 34);
            this.numericUpDownSecond.TabIndex = 4;
            this.numericUpDownSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownSecond.ValueChanged += new System.EventHandler(this.numericUpDownSecond_ValueChanged);
            // 
            // btShutdown
            // 
            this.btShutdown.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btShutdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShutdown.Location = new System.Drawing.Point(71, 161);
            this.btShutdown.Name = "btShutdown";
            this.btShutdown.Size = new System.Drawing.Size(160, 42);
            this.btShutdown.TabIndex = 6;
            this.btShutdown.Text = "Shutdown";
            this.btShutdown.UseVisualStyleBackColor = false;
            this.btShutdown.Click += new System.EventHandler(this.btShutdown_Click);
            // 
            // btRestart
            // 
            this.btRestart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRestart.Location = new System.Drawing.Point(261, 161);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(160, 42);
            this.btRestart.TabIndex = 7;
            this.btRestart.Text = "Restart";
            this.btRestart.UseVisualStyleBackColor = false;
            this.btRestart.Click += new System.EventHandler(this.btRestart_Click);
            // 
            // btCancle
            // 
            this.btCancle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancle.Location = new System.Drawing.Point(451, 161);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(160, 42);
            this.btCancle.TabIndex = 8;
            this.btCancle.Text = "Hủy";
            this.btCancle.UseVisualStyleBackColor = false;
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SetShutdownTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 259);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btRestart);
            this.Controls.Add(this.btShutdown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownSecond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownMinute);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownHour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetShutdownTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hẹn giờ tắt máy";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecond)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownHour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownMinute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownSecond;
        private System.Windows.Forms.Button btShutdown;
        private System.Windows.Forms.Button btRestart;
        private System.Windows.Forms.Button btCancle;
        private System.Windows.Forms.Timer timer1;
    }
}