namespace Tech_Otchet_SMART
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
            this.buttonGetData = new System.Windows.Forms.Button();
            this.tbProcess = new System.Windows.Forms.TextBox();
            this.buttonSelectfileNameMas1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fileNameMas1 = new System.Windows.Forms.MaskedTextBox();
            this.buttonSelectfileNameMas2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileNameMas2 = new System.Windows.Forms.MaskedTextBox();
            this.buttonDeletefileNameMas1 = new System.Windows.Forms.Button();
            this.buttonDeletefileNameMas2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGetData
            // 
            this.buttonGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetData.Location = new System.Drawing.Point(519, 64);
            this.buttonGetData.Name = "buttonGetData";
            this.buttonGetData.Size = new System.Drawing.Size(184, 31);
            this.buttonGetData.TabIndex = 0;
            this.buttonGetData.Text = "Создать файлы отчетов";
            this.buttonGetData.UseVisualStyleBackColor = true;
            this.buttonGetData.Click += new System.EventHandler(this.buttonGetData_Click);
            // 
            // tbProcess
            // 
            this.tbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProcess.Location = new System.Drawing.Point(13, 117);
            this.tbProcess.Multiline = true;
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbProcess.Size = new System.Drawing.Size(755, 145);
            this.tbProcess.TabIndex = 1;
            // 
            // buttonSelectfileNameMas1
            // 
            this.buttonSelectfileNameMas1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectfileNameMas1.Location = new System.Drawing.Point(709, 10);
            this.buttonSelectfileNameMas1.Name = "buttonSelectfileNameMas1";
            this.buttonSelectfileNameMas1.Size = new System.Drawing.Size(23, 21);
            this.buttonSelectfileNameMas1.TabIndex = 56;
            this.buttonSelectfileNameMas1.Text = "...";
            this.buttonSelectfileNameMas1.UseVisualStyleBackColor = true;
            this.buttonSelectfileNameMas1.Click += new System.EventHandler(this.buttonSelectfileNameMas1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Файл (Массив №1):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileNameMas1
            // 
            this.fileNameMas1.Location = new System.Drawing.Point(129, 12);
            this.fileNameMas1.Name = "fileNameMas1";
            this.fileNameMas1.Size = new System.Drawing.Size(574, 20);
            this.fileNameMas1.TabIndex = 54;
            // 
            // buttonSelectfileNameMas2
            // 
            this.buttonSelectfileNameMas2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectfileNameMas2.Location = new System.Drawing.Point(709, 36);
            this.buttonSelectfileNameMas2.Name = "buttonSelectfileNameMas2";
            this.buttonSelectfileNameMas2.Size = new System.Drawing.Size(23, 21);
            this.buttonSelectfileNameMas2.TabIndex = 59;
            this.buttonSelectfileNameMas2.Text = "...";
            this.buttonSelectfileNameMas2.UseVisualStyleBackColor = true;
            this.buttonSelectfileNameMas2.Click += new System.EventHandler(this.buttonSelectfileNameMas2_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 58;
            this.label2.Text = "Файл (Массив №2):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileNameMas2
            // 
            this.fileNameMas2.Location = new System.Drawing.Point(129, 38);
            this.fileNameMas2.Name = "fileNameMas2";
            this.fileNameMas2.Size = new System.Drawing.Size(574, 20);
            this.fileNameMas2.TabIndex = 57;
            // 
            // buttonDeletefileNameMas1
            // 
            this.buttonDeletefileNameMas1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeletefileNameMas1.Location = new System.Drawing.Point(738, 10);
            this.buttonDeletefileNameMas1.Name = "buttonDeletefileNameMas1";
            this.buttonDeletefileNameMas1.Size = new System.Drawing.Size(23, 21);
            this.buttonDeletefileNameMas1.TabIndex = 60;
            this.buttonDeletefileNameMas1.Text = "X";
            this.buttonDeletefileNameMas1.UseVisualStyleBackColor = true;
            this.buttonDeletefileNameMas1.Click += new System.EventHandler(this.buttonDeletefileNameMas1_Click);
            // 
            // buttonDeletefileNameMas2
            // 
            this.buttonDeletefileNameMas2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeletefileNameMas2.Location = new System.Drawing.Point(738, 36);
            this.buttonDeletefileNameMas2.Name = "buttonDeletefileNameMas2";
            this.buttonDeletefileNameMas2.Size = new System.Drawing.Size(23, 21);
            this.buttonDeletefileNameMas2.TabIndex = 61;
            this.buttonDeletefileNameMas2.Text = "X";
            this.buttonDeletefileNameMas2.UseVisualStyleBackColor = true;
            this.buttonDeletefileNameMas2.Click += new System.EventHandler(this.buttonDeletefileNameMas2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 288);
            this.Controls.Add(this.buttonDeletefileNameMas2);
            this.Controls.Add(this.buttonDeletefileNameMas1);
            this.Controls.Add(this.buttonSelectfileNameMas2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileNameMas2);
            this.Controls.Add(this.buttonSelectfileNameMas1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileNameMas1);
            this.Controls.Add(this.tbProcess);
            this.Controls.Add(this.buttonGetData);
            this.Name = "Form1";
            this.Text = "unknown version";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetData;
        private System.Windows.Forms.TextBox tbProcess;
        private System.Windows.Forms.Button buttonSelectfileNameMas1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox fileNameMas1;
        private System.Windows.Forms.Button buttonSelectfileNameMas2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox fileNameMas2;
        private System.Windows.Forms.Button buttonDeletefileNameMas1;
        private System.Windows.Forms.Button buttonDeletefileNameMas2;
    }
}

