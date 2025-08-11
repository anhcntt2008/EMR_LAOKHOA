namespace BOSERP
{
    partial class Canvas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CanvasPaint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPaint)).BeginInit();
            this.SuspendLayout();
            // 
            // CanvasPaint
            // 
            this.CanvasPaint.Location = new System.Drawing.Point(3, 3);
            this.CanvasPaint.Name = "CanvasPaint";
            this.CanvasPaint.Size = new System.Drawing.Size(480, 331);
            this.CanvasPaint.TabIndex = 0;
            this.CanvasPaint.TabStop = false;
            this.CanvasPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasPaint_MouseMove);
            this.CanvasPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasPaint_MouseDown);
            this.CanvasPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasPaint_MouseUp);
            // 
            // Canvas
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.CanvasPaint);
            this.DoubleBuffered = true;
            this.Name = "Canvas";
            this.Size = new System.Drawing.Size(547, 343);
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPaint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CanvasPaint;
    }
}
