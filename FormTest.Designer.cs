namespace cube_thing
{
    partial class FormTest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.canvasHolder = new System.Windows.Forms.Panel();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.fpscounter = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.canvasHolder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fpscounter);
            this.splitContainer1.Panel2.Controls.Add(this.left);
            this.splitContainer1.Panel2.Controls.Add(this.right);
            this.splitContainer1.Panel2.Controls.Add(this.back);
            this.splitContainer1.Panel2.Controls.Add(this.forward);
            this.splitContainer1.Size = new System.Drawing.Size(952, 419);
            this.splitContainer1.SplitterDistance = 728;
            this.splitContainer1.TabIndex = 1;
            // 
            // canvasHolder
            // 
            this.canvasHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasHolder.Location = new System.Drawing.Point(0, 0);
            this.canvasHolder.Name = "canvasHolder";
            this.canvasHolder.Size = new System.Drawing.Size(728, 419);
            this.canvasHolder.TabIndex = 0;
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(65, 33);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(27, 23);
            this.left.TabIndex = 3;
            this.left.Text = "L";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.Move_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(131, 33);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(27, 23);
            this.right.TabIndex = 2;
            this.right.Text = "R";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.Move_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(98, 54);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(27, 23);
            this.back.TabIndex = 1;
            this.back.Text = "B";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.Move_Click);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(98, 12);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(27, 23);
            this.forward.TabIndex = 0;
            this.forward.Text = "F";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.Move_Click);
            // 
            // fpscounter
            // 
            this.fpscounter.AutoSize = true;
            this.fpscounter.Location = new System.Drawing.Point(3, 150);
            this.fpscounter.Name = "fpscounter";
            this.fpscounter.Size = new System.Drawing.Size(30, 13);
            this.fpscounter.TabIndex = 4;
            this.fpscounter.Text = "0 fps";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 419);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel canvasHolder;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label fpscounter;
    }
}