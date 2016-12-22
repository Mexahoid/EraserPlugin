namespace EraserPlugin
{
    partial class EraserPluginUserControl
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
            this.CtrlTBWidth = new System.Windows.Forms.TrackBar();
            this.CtrlLblMisc1 = new System.Windows.Forms.Label();
            this.CtrlLblMisc2 = new System.Windows.Forms.Label();
            this.CtrlLblMisc3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlTBWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlTBWidth
            // 
            this.CtrlTBWidth.Location = new System.Drawing.Point(0, 16);
            this.CtrlTBWidth.Maximum = 20;
            this.CtrlTBWidth.Minimum = 1;
            this.CtrlTBWidth.Name = "CtrlTBWidth";
            this.CtrlTBWidth.Size = new System.Drawing.Size(158, 45);
            this.CtrlTBWidth.TabIndex = 0;
            this.CtrlTBWidth.Value = 1;
            // 
            // CtrlLblMisc1
            // 
            this.CtrlLblMisc1.AutoSize = true;
            this.CtrlLblMisc1.Location = new System.Drawing.Point(63, 0);
            this.CtrlLblMisc1.Name = "CtrlLblMisc1";
            this.CtrlLblMisc1.Size = new System.Drawing.Size(53, 13);
            this.CtrlLblMisc1.TabIndex = 1;
            this.CtrlLblMisc1.Text = "Толщина";
            // 
            // CtrlLblMisc2
            // 
            this.CtrlLblMisc2.AutoSize = true;
            this.CtrlLblMisc2.Location = new System.Drawing.Point(3, 48);
            this.CtrlLblMisc2.Name = "CtrlLblMisc2";
            this.CtrlLblMisc2.Size = new System.Drawing.Size(13, 13);
            this.CtrlLblMisc2.TabIndex = 2;
            this.CtrlLblMisc2.Text = "1";
            // 
            // CtrlLblMisc3
            // 
            this.CtrlLblMisc3.AutoSize = true;
            this.CtrlLblMisc3.Location = new System.Drawing.Point(139, 48);
            this.CtrlLblMisc3.Name = "CtrlLblMisc3";
            this.CtrlLblMisc3.Size = new System.Drawing.Size(19, 13);
            this.CtrlLblMisc3.TabIndex = 3;
            this.CtrlLblMisc3.Text = "20";
            // 
            // EraserPluginUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CtrlLblMisc3);
            this.Controls.Add(this.CtrlLblMisc2);
            this.Controls.Add(this.CtrlLblMisc1);
            this.Controls.Add(this.CtrlTBWidth);
            this.Name = "EraserPluginUserControl";
            this.Size = new System.Drawing.Size(172, 75);
            ((System.ComponentModel.ISupportInitialize)(this.CtrlTBWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar CtrlTBWidth;
        private System.Windows.Forms.Label CtrlLblMisc1;
        private System.Windows.Forms.Label CtrlLblMisc2;
        private System.Windows.Forms.Label CtrlLblMisc3;
    }
}
