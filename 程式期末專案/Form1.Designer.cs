
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
            this.buttonSignin.Location = new System.Drawing.Point(109, 151);
            this.buttonSignin.Name = "buttonSignin";
            this.buttonSignin.Size = new System.Drawing.Size(75, 23);
            this.buttonSignin.TabIndex = 0;
            this.buttonSignin.Text = "登入";
            this.buttonSignin.UseVisualStyleBackColor = true;
            this.buttonSignin.Click += new System.EventHandler(this.buttonSignin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "帳號:";
            // 
            // textaccount
            // 
            this.textaccount.Location = new System.Drawing.Point(119, 28);
            this.textaccount.Name = "textaccount";
            this.textaccount.Size = new System.Drawing.Size(100, 25);
            this.textaccount.TabIndex = 2;
            this.textaccount.TextChanged += new System.EventHandler(this.textaccount_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "密碼:";
            // 
            // textpassword
            // 
            this.textpassword.Location = new System.Drawing.Point(119, 92);
            this.textpassword.Name = "textpassword";
            this.textpassword.PasswordChar = '*';
            this.textpassword.Size = new System.Drawing.Size(100, 25);
            this.textpassword.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 217);
            this.Controls.Add(this.textpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textaccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSignin);
            this.Name = "Form1";
            this.Text = "登入";
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

