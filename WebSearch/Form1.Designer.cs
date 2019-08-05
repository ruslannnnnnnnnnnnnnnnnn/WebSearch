namespace WebSearch
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PauseBt = new System.Windows.Forms.Button();
            this.PauseSecond = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.HostBox = new System.Windows.Forms.TextBox();
            this.PauseBox = new System.Windows.Forms.GroupBox();
            this.SerialezeBt = new System.Windows.Forms.Button();
            this.BeginBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.DeserialezeBt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NumericBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Begin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PauseSecond)).BeginInit();
            this.PauseBox.SuspendLayout();
            this.BeginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PauseBt
            // 
            this.PauseBt.Location = new System.Drawing.Point(248, 19);
            this.PauseBt.Name = "PauseBt";
            this.PauseBt.Size = new System.Drawing.Size(75, 23);
            this.PauseBt.TabIndex = 0;
            this.PauseBt.Text = "пауза";
            this.PauseBt.UseVisualStyleBackColor = true;
            this.PauseBt.Click += new System.EventHandler(this.PauseBt_Click);
            // 
            // PauseSecond
            // 
            this.PauseSecond.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.PauseSecond.Location = new System.Drawing.Point(102, 22);
            this.PauseSecond.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.PauseSecond.Name = "PauseSecond";
            this.PauseSecond.Size = new System.Drawing.Size(120, 20);
            this.PauseSecond.TabIndex = 1;
            this.PauseSecond.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.PauseSecond.ValueChanged += new System.EventHandler(this.PauseSecond_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "пауза мл. сек.";
            // 
            // HostBox
            // 
            this.HostBox.Location = new System.Drawing.Point(88, 17);
            this.HostBox.Name = "HostBox";
            this.HostBox.Size = new System.Drawing.Size(141, 20);
            this.HostBox.TabIndex = 3;
            // 
            // PauseBox
            // 
            this.PauseBox.Controls.Add(this.SerialezeBt);
            this.PauseBox.Controls.Add(this.PauseBt);
            this.PauseBox.Controls.Add(this.PauseSecond);
            this.PauseBox.Controls.Add(this.label1);
            this.PauseBox.Location = new System.Drawing.Point(39, 35);
            this.PauseBox.Name = "PauseBox";
            this.PauseBox.Size = new System.Drawing.Size(329, 80);
            this.PauseBox.TabIndex = 4;
            this.PauseBox.TabStop = false;
            this.PauseBox.Visible = false;
            // 
            // SerialezeBt
            // 
            this.SerialezeBt.Location = new System.Drawing.Point(229, 48);
            this.SerialezeBt.Name = "SerialezeBt";
            this.SerialezeBt.Size = new System.Drawing.Size(94, 23);
            this.SerialezeBt.TabIndex = 3;
            this.SerialezeBt.Text = "сериализовать";
            this.SerialezeBt.UseVisualStyleBackColor = true;
            this.SerialezeBt.Click += new System.EventHandler(this.SerialezeBt_Click);
            // 
            // BeginBox
            // 
            this.BeginBox.Controls.Add(this.label4);
            this.BeginBox.Controls.Add(this.PathBox);
            this.BeginBox.Controls.Add(this.DeserialezeBt);
            this.BeginBox.Controls.Add(this.label3);
            this.BeginBox.Controls.Add(this.NumericBox);
            this.BeginBox.Controls.Add(this.label2);
            this.BeginBox.Controls.Add(this.Begin);
            this.BeginBox.Controls.Add(this.HostBox);
            this.BeginBox.Location = new System.Drawing.Point(32, 121);
            this.BeginBox.Name = "BeginBox";
            this.BeginBox.Size = new System.Drawing.Size(336, 145);
            this.BeginBox.TabIndex = 5;
            this.BeginBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "папка";
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(88, 69);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(141, 20);
            this.PathBox.TabIndex = 9;
            // 
            // DeserialezeBt
            // 
            this.DeserialezeBt.Location = new System.Drawing.Point(88, 106);
            this.DeserialezeBt.Name = "DeserialezeBt";
            this.DeserialezeBt.Size = new System.Drawing.Size(234, 23);
            this.DeserialezeBt.TabIndex = 8;
            this.DeserialezeBt.Text = "начать с сериализованного";
            this.DeserialezeBt.UseVisualStyleBackColor = true;
            this.DeserialezeBt.Click += new System.EventHandler(this.DeserialezeBt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "нумеровать с";
            // 
            // NumericBox
            // 
            this.NumericBox.Location = new System.Drawing.Point(88, 43);
            this.NumericBox.Name = "NumericBox";
            this.NumericBox.Size = new System.Drawing.Size(141, 20);
            this.NumericBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "хост";
            // 
            // Begin
            // 
            this.Begin.Location = new System.Drawing.Point(247, 17);
            this.Begin.Name = "Begin";
            this.Begin.Size = new System.Drawing.Size(75, 23);
            this.Begin.TabIndex = 4;
            this.Begin.Text = "начать";
            this.Begin.UseVisualStyleBackColor = true;
            this.Begin.Click += new System.EventHandler(this.Begin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 304);
            this.Controls.Add(this.BeginBox);
            this.Controls.Add(this.PauseBox);
            this.Name = "Form1";
            this.Text = "WebRob";
            ((System.ComponentModel.ISupportInitialize)(this.PauseSecond)).EndInit();
            this.PauseBox.ResumeLayout(false);
            this.PauseBox.PerformLayout();
            this.BeginBox.ResumeLayout(false);
            this.BeginBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PauseBt;
        private System.Windows.Forms.NumericUpDown PauseSecond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HostBox;
        private System.Windows.Forms.GroupBox PauseBox;
        private System.Windows.Forms.GroupBox BeginBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NumericBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Begin;
        private System.Windows.Forms.Button SerialezeBt;
        private System.Windows.Forms.Button DeserialezeBt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PathBox;
    }
}

