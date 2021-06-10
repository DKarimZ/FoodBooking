
namespace ClientDesktop
{
	partial class fenetreAjoutPlat
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtBNomPlat = new System.Windows.Forms.TextBox();
			this.lbTypeplat = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtboxingredientaajouter = new System.Windows.Forms.TextBox();
			this.tbquantiteingredientaajouter = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.dgvIngredientsinnewplat = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.btnAjouteringredient = new System.Windows.Forms.Button();
			this.btnAjouterplat = new System.Windows.Forms.Button();
			this.IngredientGridView = new System.Windows.Forms.DataGridView();
			this.platGridView = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredientsinnewplat)).BeginInit();
			this.tableLayoutPanel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.platGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.IngredientGridView, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.platGridView, 2, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 553);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(294, 55);
			this.label1.TabIndex = 0;
			this.label1.Text = "Création d\'un nouveau plat";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(303, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(294, 55);
			this.label2.TabIndex = 1;
			this.label2.Text = "Liste des ingrédients";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(603, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(294, 55);
			this.label3.TabIndex = 2;
			this.label3.Text = "Liste des plats";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 58);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 323F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 436);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.76699F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.23301F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(287, 103);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.60656F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.39344F));
			this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.txtBNomPlat, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.lbTypeplat, 1, 1);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 11);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(281, 89);
			this.tableLayoutPanel4.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "Nom";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "Type ";
			// 
			// txtBNomPlat
			// 
			this.txtBNomPlat.Location = new System.Drawing.Point(97, 3);
			this.txtBNomPlat.Name = "txtBNomPlat";
			this.txtBNomPlat.Size = new System.Drawing.Size(150, 27);
			this.txtBNomPlat.TabIndex = 2;
			// 
			// lbTypeplat
			// 
			this.lbTypeplat.FormattingEnabled = true;
			this.lbTypeplat.ItemHeight = 20;
			this.lbTypeplat.Location = new System.Drawing.Point(97, 47);
			this.lbTypeplat.Name = "lbTypeplat";
			this.lbTypeplat.Size = new System.Drawing.Size(150, 24);
			this.lbTypeplat.TabIndex = 3;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 116);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 2;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.58763F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.41237F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(288, 317);
			this.tableLayoutPanel5.TabIndex = 1;
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.ColumnCount = 2;
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.79433F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.20567F));
			this.tableLayoutPanel8.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel8.Controls.Add(this.label9, 1, 0);
			this.tableLayoutPanel8.Controls.Add(this.txtboxingredientaajouter, 0, 1);
			this.tableLayoutPanel8.Controls.Add(this.tbquantiteingredientaajouter, 1, 1);
			this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 2;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(282, 56);
			this.tableLayoutPanel8.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Location = new System.Drawing.Point(3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(188, 28);
			this.label6.TabIndex = 0;
			this.label6.Text = "Ingredient a ajouter";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(197, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 20);
			this.label9.TabIndex = 1;
			this.label9.Text = "quantité";
			// 
			// txtboxingredientaajouter
			// 
			this.txtboxingredientaajouter.Location = new System.Drawing.Point(3, 31);
			this.txtboxingredientaajouter.Name = "txtboxingredientaajouter";
			this.txtboxingredientaajouter.Size = new System.Drawing.Size(188, 27);
			this.txtboxingredientaajouter.TabIndex = 2;
			// 
			// tbquantiteingredientaajouter
			// 
			this.tbquantiteingredientaajouter.Location = new System.Drawing.Point(197, 31);
			this.tbquantiteingredientaajouter.Name = "tbquantiteingredientaajouter";
			this.tbquantiteingredientaajouter.Size = new System.Drawing.Size(82, 27);
			this.tbquantiteingredientaajouter.TabIndex = 3;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.50355F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.49645F));
			this.tableLayoutPanel6.Controls.Add(this.dgvIngredientsinnewplat, 0, 0);
			this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 65);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(282, 249);
			this.tableLayoutPanel6.TabIndex = 3;
			// 
			// dgvIngredientsinnewplat
			// 
			this.dgvIngredientsinnewplat.AllowUserToAddRows = false;
			this.dgvIngredientsinnewplat.AllowUserToDeleteRows = false;
			this.dgvIngredientsinnewplat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIngredientsinnewplat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvIngredientsinnewplat.Location = new System.Drawing.Point(3, 3);
			this.dgvIngredientsinnewplat.Name = "dgvIngredientsinnewplat";
			this.dgvIngredientsinnewplat.ReadOnly = true;
			this.dgvIngredientsinnewplat.RowHeadersWidth = 51;
			this.dgvIngredientsinnewplat.RowTemplate.Height = 29;
			this.dgvIngredientsinnewplat.Size = new System.Drawing.Size(190, 243);
			this.dgvIngredientsinnewplat.TabIndex = 0;
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.ColumnCount = 2;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel7.Controls.Add(this.btnAjouteringredient, 0, 0);
			this.tableLayoutPanel7.Controls.Add(this.btnAjouterplat, 1, 0);
			this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 500);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(294, 50);
			this.tableLayoutPanel7.TabIndex = 4;
			// 
			// btnAjouteringredient
			// 
			this.btnAjouteringredient.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnAjouteringredient.Location = new System.Drawing.Point(3, 3);
			this.btnAjouteringredient.Name = "btnAjouteringredient";
			this.btnAjouteringredient.Size = new System.Drawing.Size(141, 44);
			this.btnAjouteringredient.TabIndex = 0;
			this.btnAjouteringredient.Text = "Ajouter Ingredient";
			this.btnAjouteringredient.UseVisualStyleBackColor = true;
			this.btnAjouteringredient.Click += new System.EventHandler(this.btnAjouteringredient_Click);
			// 
			// btnAjouterplat
			// 
			this.btnAjouterplat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnAjouterplat.Location = new System.Drawing.Point(150, 3);
			this.btnAjouterplat.Name = "btnAjouterplat";
			this.btnAjouterplat.Size = new System.Drawing.Size(141, 44);
			this.btnAjouterplat.TabIndex = 1;
			this.btnAjouterplat.Text = "Ajouter Plat";
			this.btnAjouterplat.UseVisualStyleBackColor = true;
			this.btnAjouterplat.Click += new System.EventHandler(this.btnAjouterplat_Click);
			// 
			// IngredientGridView
			// 
			this.IngredientGridView.AllowUserToAddRows = false;
			this.IngredientGridView.AllowUserToDeleteRows = false;
			this.IngredientGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.IngredientGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IngredientGridView.Location = new System.Drawing.Point(303, 58);
			this.IngredientGridView.Name = "IngredientGridView";
			this.IngredientGridView.ReadOnly = true;
			this.IngredientGridView.RowHeadersWidth = 51;
			this.IngredientGridView.RowTemplate.Height = 29;
			this.IngredientGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.IngredientGridView.Size = new System.Drawing.Size(294, 436);
			this.IngredientGridView.TabIndex = 5;
			this.IngredientGridView.SelectionChanged += new System.EventHandler(this.IngredientGridView_SelectionChanged);
			// 
			// platGridView
			// 
			this.platGridView.AllowUserToAddRows = false;
			this.platGridView.AllowUserToDeleteRows = false;
			this.platGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.platGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.platGridView.Location = new System.Drawing.Point(603, 58);
			this.platGridView.Name = "platGridView";
			this.platGridView.ReadOnly = true;
			this.platGridView.RowHeadersWidth = 51;
			this.platGridView.RowTemplate.Height = 29;
			this.platGridView.Size = new System.Drawing.Size(294, 436);
			this.platGridView.TabIndex = 6;
			// 
			// fenetreAjoutPlat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 553);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(918, 600);
			this.Name = "fenetreAjoutPlat";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fenetreAjoutPlat";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel8.ResumeLayout(false);
			this.tableLayoutPanel8.PerformLayout();
			this.tableLayoutPanel6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredientsinnewplat)).EndInit();
			this.tableLayoutPanel7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.platGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtBNomPlat;
		private System.Windows.Forms.ListBox lbTypeplat;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.Button btnAjouteringredient;
		private System.Windows.Forms.Button btnAjouterplat;
		private System.Windows.Forms.DataGridView IngredientGridView;
		private System.Windows.Forms.DataGridView platGridView;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtboxingredientaajouter;
		private System.Windows.Forms.TextBox tbquantiteingredientaajouter;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.DataGridView dgvIngredientsinnewplat;
	}
}