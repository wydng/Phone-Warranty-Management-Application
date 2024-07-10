
namespace QL_baoHanh
{
    partial class register
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
            this.dk_ = new System.Windows.Forms.Button();
            this.dn_ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbgt = new System.Windows.Forms.ComboBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.txttk = new System.Windows.Forms.TextBox();
            this.txtdc = new System.Windows.Forms.TextBox();
            this.txtns = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_cv = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dk_
            // 
            this.dk_.Location = new System.Drawing.Point(131, 457);
            this.dk_.Name = "dk_";
            this.dk_.Size = new System.Drawing.Size(113, 39);
            this.dk_.TabIndex = 0;
            this.dk_.Text = "Đăng ký";
            this.dk_.UseVisualStyleBackColor = true;
            this.dk_.Click += new System.EventHandler(this.dk__Click);
            // 
            // dn_
            // 
            this.dn_.Location = new System.Drawing.Point(250, 457);
            this.dn_.Name = "dn_";
            this.dn_.Size = new System.Drawing.Size(113, 39);
            this.dn_.TabIndex = 1;
            this.dn_.Text = "Đăng nhập";
            this.dn_.UseVisualStyleBackColor = true;
            this.dn_.Click += new System.EventHandler(this.dn__Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(18, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Họ tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(18, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Năm sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(18, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(18, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên tài khoản:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(18, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(18, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "Giới tính:";
            // 
            // cbgt
            // 
            this.cbgt.FormattingEnabled = true;
            this.cbgt.Items.AddRange(new object[] {
            "--Chọn giới tính--",
            "Nam",
            "Nữ"});
            this.cbgt.Location = new System.Drawing.Point(188, 246);
            this.cbgt.Name = "cbgt";
            this.cbgt.Size = new System.Drawing.Size(254, 24);
            this.cbgt.TabIndex = 8;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(188, 88);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(254, 22);
            this.txtten.TabIndex = 9;
            // 
            // txttk
            // 
            this.txttk.Location = new System.Drawing.Point(188, 346);
            this.txttk.Name = "txttk";
            this.txttk.Size = new System.Drawing.Size(254, 22);
            this.txttk.TabIndex = 10;
            // 
            // txtdc
            // 
            this.txtdc.Location = new System.Drawing.Point(188, 199);
            this.txtdc.Name = "txtdc";
            this.txtdc.Size = new System.Drawing.Size(254, 22);
            this.txtdc.TabIndex = 11;
            // 
            // txtns
            // 
            this.txtns.Location = new System.Drawing.Point(188, 143);
            this.txtns.Name = "txtns";
            this.txtns.Size = new System.Drawing.Size(254, 22);
            this.txtns.TabIndex = 12;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(188, 400);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(254, 22);
            this.txtpass.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(139, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 46);
            this.label7.TabIndex = 14;
            this.label7.Text = "Đăng ký";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(18, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = "Chức vụ:";
            // 
            // cb_cv
            // 
            this.cb_cv.FormattingEnabled = true;
            this.cb_cv.Items.AddRange(new object[] {
            "--Chọn chức vụ--",
            "Admin",
            "Nhân viên"});
            this.cb_cv.Location = new System.Drawing.Point(188, 299);
            this.cb_cv.Name = "cb_cv";
            this.cb_cv.Size = new System.Drawing.Size(254, 24);
            this.cb_cv.TabIndex = 16;
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 516);
            this.Controls.Add(this.cb_cv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtns);
            this.Controls.Add(this.txtdc);
            this.Controls.Add(this.txttk);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.cbgt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dn_);
            this.Controls.Add(this.dk_);
            this.Name = "register";
            this.Text = "register";
            this.Load += new System.EventHandler(this.register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dk_;
        private System.Windows.Forms.Button dn_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbgt;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txttk;
        private System.Windows.Forms.TextBox txtdc;
        private System.Windows.Forms.TextBox txtns;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_cv;
    }
}