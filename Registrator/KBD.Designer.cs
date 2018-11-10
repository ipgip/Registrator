namespace Registrator
{
    partial class KBD
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.keyboard1 = new Registrator.Keyboard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyboard1
            // 
            this.keyboard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyboard1.Location = new System.Drawing.Point(0, 29);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(538, 214);
            this.keyboard1.TabIndex = 0;
            this.keyboard1.ClickChar += new System.EventHandler<Registrator.KeyArgs>(this.Keyboard1_ClickChar);
            this.keyboard1.BSPChar += new System.EventHandler<Registrator.KeyArgs>(this.Keyboard1_BSPChar);
            this.keyboard1.ENTChar += new System.EventHandler<Registrator.KeyArgs>(this.Keyboard1_ENTChar);
            // 
            // KBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyboard1);
            this.Name = "KBD";
            this.Size = new System.Drawing.Size(538, 243);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Keyboard keyboard1;
        private System.Windows.Forms.Label label1;
    }
}
