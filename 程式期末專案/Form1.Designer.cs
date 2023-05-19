
namespace 程式期末專案
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSignin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textaccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textpassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSignin
            // 
            this.buttonSignin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(52)))), ((int)(((byte)(158)))), ((int)(((byte)(151)))));
            this.buttonSignin.FlatAppearance.BorderSize = 0;
            this.buttonSignin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignin.Font = new System.Drawing.Font("等距更紗黑體 Slab TC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSignin.ForeColor = System.Drawing.Color.White;
            this.buttonSignin.Location = new System.Drawing.Point(86, 151);
            this.buttonSignin.Name = "buttonSignin";
            this.buttonSignin.Size = new System.Drawing.Size(75, 46);
            this.buttonSignin.TabIndex = 0;
            this.buttonSignin.Text = "登入";
            this.buttonSignin.UseVisualStyleBackColor = false;
            this.buttonSignin.Click += new System.EventHandler(this.buttonSignin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("等距更紗黑體 Slab TC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "帳號:";
            // 
            // textaccount
            // 
            this.textaccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textaccount.Font = new System.Drawing.Font("等距更紗黑體 Slab TC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textaccount.Location = new System.Drawing.Point(96, 28);
            this.textaccount.Name = "textaccount";
            this.textaccount.Size = new System.Drawing.Size(100, 32);
            this.textaccount.TabIndex = 2;
            this.textaccount.TextChanged += new System.EventHandler(this.textaccount_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("等距更紗黑體 Slab TC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(32, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "密碼:";
            // 
            // textpassword
            // 
            this.textpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textpassword.Font = new System.Drawing.Font("等距更紗黑體 Slab TC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textpassword.Location = new System.Drawing.Point(96, 92);
            this.textpassword.Name = "textpassword";
            this.textpassword.PasswordChar = '*';
            this.textpassword.Size = new System.Drawing.Size(100, 32);
            this.textpassword.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(246, 228);
            this.Controls.Add(this.textpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textaccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSignin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "登入";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSignin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textaccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textpassword;
    }
}

