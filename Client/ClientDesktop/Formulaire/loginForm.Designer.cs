
namespace ClientDesktop.Formulaire
{
	partial class loginForm
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
			this.btnLogin = new System.Windows.Forms.Button();
			this.txtBoxLogin = new System.Windows.Forms.TextBox();
			this.txtboxPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(262, 304);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(191, 29);
			this.btnLogin.TabIndex = 0;
			this.btnLogin.Text = "Se connecter";
			this.btnLogin.UseVisualStyleBackColor = true;
			
			// 
			// txtBoxLogin
			// 
			this.txtBoxLogin.Location = new System.Drawing.Point(383, 171);
			this.txtBoxLogin.Name = "txtBoxLogin";
			this.txtBoxLogin.Size = new System.Drawing.Size(125, 27);
			this.txtBoxLogin.TabIndex = 1;
			// 
			// txtboxPassword
			// 
			this.txtboxPassword.Location = new System.Drawing.Point(383, 231);
			this.txtboxPassword.Name = "txtboxPassword";
			this.txtboxPassword.Size = new System.Drawing.Size(125, 27);
			this.txtboxPassword.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(253, 171);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Login";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(253, 231);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Mot de passe";
			// 
			// loginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtboxPassword);
			this.Controls.Add(this.txtBoxLogin);
			this.Controls.Add(this.btnLogin);
			this.Name = "loginForm";
			this.Text = "loginForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.TextBox txtBoxLogin;
		private System.Windows.Forms.TextBox txtboxPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}