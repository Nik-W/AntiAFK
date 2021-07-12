namespace AntiAFK
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.processComboBox = new System.Windows.Forms.ComboBox();
            this.timerInterval = new System.Windows.Forms.NumericUpDown();
            this.arrowRadioButton = new System.Windows.Forms.RadioButton();
            this.motionRadioButton = new System.Windows.Forms.RadioButton();
            this.escCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.topMostButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.timerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timerInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Имя процесса";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Интервал (сек.)";
            // 
            // processComboBox
            // 
            this.processComboBox.FormattingEnabled = true;
            this.processComboBox.Location = new System.Drawing.Point(15, 18);
            this.processComboBox.Name = "processComboBox";
            this.processComboBox.Size = new System.Drawing.Size(150, 21);
            this.processComboBox.TabIndex = 0;
            // 
            // timerInterval
            // 
            this.timerInterval.Location = new System.Drawing.Point(15, 65);
            this.timerInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timerInterval.Name = "timerInterval";
            this.timerInterval.Size = new System.Drawing.Size(50, 20);
            this.timerInterval.TabIndex = 1;
            this.timerInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // arrowRadioButton
            // 
            this.arrowRadioButton.AutoSize = true;
            this.arrowRadioButton.Checked = true;
            this.arrowRadioButton.Location = new System.Drawing.Point(10, 42);
            this.arrowRadioButton.Name = "arrowRadioButton";
            this.arrowRadioButton.Size = new System.Drawing.Size(71, 17);
            this.arrowRadioButton.TabIndex = 6;
            this.arrowRadioButton.TabStop = true;
            this.arrowRadioButton.Text = " ← ↑ → ↓";
            this.arrowRadioButton.UseVisualStyleBackColor = true;
            // 
            // motionRadioButton
            // 
            this.motionRadioButton.AutoSize = true;
            this.motionRadioButton.Location = new System.Drawing.Point(10, 65);
            this.motionRadioButton.Name = "motionRadioButton";
            this.motionRadioButton.Size = new System.Drawing.Size(67, 17);
            this.motionRadioButton.TabIndex = 8;
            this.motionRadioButton.TabStop = true;
            this.motionRadioButton.Text = "W A S D";
            this.motionRadioButton.UseVisualStyleBackColor = true;
            // 
            // escCheckBox
            // 
            this.escCheckBox.AutoSize = true;
            this.escCheckBox.Checked = true;
            this.escCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.escCheckBox.Location = new System.Drawing.Point(10, 19);
            this.escCheckBox.Name = "escCheckBox";
            this.escCheckBox.Size = new System.Drawing.Size(44, 17);
            this.escCheckBox.TabIndex = 5;
            this.escCheckBox.Text = "Esc";
            this.escCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.escCheckBox);
            this.groupBox1.Controls.Add(this.motionRadioButton);
            this.groupBox1.Controls.Add(this.arrowRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(101, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 96);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поведение";
            // 
            // topMostButton
            // 
            this.topMostButton.Image = global::AntiAFK.Properties.Resources.attach;
            this.topMostButton.Location = new System.Drawing.Point(198, 18);
            this.topMostButton.Name = "topMostButton";
            this.topMostButton.Size = new System.Drawing.Size(21, 21);
            this.topMostButton.TabIndex = 4;
            this.topMostButton.UseVisualStyleBackColor = true;
            this.topMostButton.Click += new System.EventHandler(this.topMostButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Image = ((System.Drawing.Image)(resources.GetObject("updateButton.Image")));
            this.updateButton.Location = new System.Drawing.Point(171, 18);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(21, 21);
            this.updateButton.TabIndex = 3;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // timerButton
            // 
            this.timerButton.Image = ((System.Drawing.Image)(resources.GetObject("timerButton.Image")));
            this.timerButton.Location = new System.Drawing.Point(15, 93);
            this.timerButton.Name = "timerButton";
            this.timerButton.Size = new System.Drawing.Size(40, 40);
            this.timerButton.TabIndex = 2;
            this.timerButton.UseVisualStyleBackColor = true;
            this.timerButton.Click += new System.EventHandler(this.timerButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 149);
            this.Controls.Add(this.topMostButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.timerInterval);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.processComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AntiAFK";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.timerInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button timerButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox processComboBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.NumericUpDown timerInterval;
        private System.Windows.Forms.RadioButton arrowRadioButton;
        private System.Windows.Forms.RadioButton motionRadioButton;
        private System.Windows.Forms.CheckBox escCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button topMostButton;
    }
}

