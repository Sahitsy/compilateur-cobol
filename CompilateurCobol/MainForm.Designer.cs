/*
 * Crée par SharpDevelop.
 * Utilisateur: RAKOTOSA
 * Date: 03/11/2021
 * Heure: 13:09
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace CompilateurCobol
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textBoxPreCompil;
		private System.Windows.Forms.Button buttonCompiler;
		private System.Windows.Forms.TextBox textBoxFicSrc;
		private System.Windows.Forms.TextBox textBoxFicSor;
		private System.Windows.Forms.TextBox textBoxOUTInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBoxEXT;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ListBox listBoxSRCadd;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckBox checkBoxSQLite;
		private System.Windows.Forms.CheckBox checkBoxEsqlOC;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBoxBDD;
		private System.Windows.Forms.GroupBox groupBoxSRC;
		private System.Windows.Forms.GroupBox groupBoxCOMPIL;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textBoxPreCompil = new System.Windows.Forms.TextBox();
			this.buttonCompiler = new System.Windows.Forms.Button();
			this.textBoxFicSrc = new System.Windows.Forms.TextBox();
			this.textBoxFicSor = new System.Windows.Forms.TextBox();
			this.textBoxOUTInfo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBoxEXT = new System.Windows.Forms.ComboBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.listBoxSRCadd = new System.Windows.Forms.ListBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBoxSQLite = new System.Windows.Forms.CheckBox();
			this.checkBoxEsqlOC = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBoxBDD = new System.Windows.Forms.GroupBox();
			this.groupBoxSRC = new System.Windows.Forms.GroupBox();
			this.groupBoxCOMPIL = new System.Windows.Forms.GroupBox();
			this.groupBoxBDD.SuspendLayout();
			this.groupBoxSRC.SuspendLayout();
			this.groupBoxCOMPIL.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxPreCompil
			// 
			this.textBoxPreCompil.BackColor = System.Drawing.Color.Black;
			this.textBoxPreCompil.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPreCompil.ForeColor = System.Drawing.SystemColors.Window;
			this.textBoxPreCompil.Location = new System.Drawing.Point(10, 102);
			this.textBoxPreCompil.MaxLength = 0;
			this.textBoxPreCompil.Multiline = true;
			this.textBoxPreCompil.Name = "textBoxPreCompil";
			this.textBoxPreCompil.ReadOnly = true;
			this.textBoxPreCompil.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPreCompil.Size = new System.Drawing.Size(601, 89);
			this.textBoxPreCompil.TabIndex = 20;
			// 
			// buttonCompiler
			// 
			this.buttonCompiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCompiler.Location = new System.Drawing.Point(519, 37);
			this.buttonCompiler.Name = "buttonCompiler";
			this.buttonCompiler.Size = new System.Drawing.Size(92, 31);
			this.buttonCompiler.TabIndex = 17;
			this.buttonCompiler.Text = "Compiler";
			this.buttonCompiler.UseVisualStyleBackColor = true;
			this.buttonCompiler.Click += new System.EventHandler(this.ButtonCompilerClick);
			// 
			// textBoxFicSrc
			// 
			this.textBoxFicSrc.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxFicSrc.Location = new System.Drawing.Point(123, 21);
			this.textBoxFicSrc.MaxLength = 0;
			this.textBoxFicSrc.Name = "textBoxFicSrc";
			this.textBoxFicSrc.ReadOnly = true;
			this.textBoxFicSrc.Size = new System.Drawing.Size(411, 20);
			this.textBoxFicSrc.TabIndex = 3;
			// 
			// textBoxFicSor
			// 
			this.textBoxFicSor.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxFicSor.Location = new System.Drawing.Point(106, 43);
			this.textBoxFicSor.MaxLength = 0;
			this.textBoxFicSor.Name = "textBoxFicSor";
			this.textBoxFicSor.ReadOnly = true;
			this.textBoxFicSor.Size = new System.Drawing.Size(407, 20);
			this.textBoxFicSor.TabIndex = 15;
			// 
			// textBoxOUTInfo
			// 
			this.textBoxOUTInfo.BackColor = System.Drawing.Color.Black;
			this.textBoxOUTInfo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxOUTInfo.ForeColor = System.Drawing.Color.White;
			this.textBoxOUTInfo.Location = new System.Drawing.Point(10, 220);
			this.textBoxOUTInfo.MaxLength = 0;
			this.textBoxOUTInfo.Multiline = true;
			this.textBoxOUTInfo.Name = "textBoxOUTInfo";
			this.textBoxOUTInfo.ReadOnly = true;
			this.textBoxOUTInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxOUTInfo.Size = new System.Drawing.Size(601, 89);
			this.textBoxOUTInfo.TabIndex = 22;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Programme principal";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(26, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 35);
			this.label2.TabIndex = 5;
			this.label2.Text = "Fichiers additionnels";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(536, 21);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 20);
			this.button1.TabIndex = 4;
			this.button1.Text = "Sélectionner";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// comboBoxEXT
			// 
			this.comboBoxEXT.FormattingEnabled = true;
			this.comboBoxEXT.Items.AddRange(new object[] {
			".exe",
			".dll",
			".c"});
			this.comboBoxEXT.Location = new System.Drawing.Point(106, 16);
			this.comboBoxEXT.Name = "comboBoxEXT";
			this.comboBoxEXT.Size = new System.Drawing.Size(82, 21);
			this.comboBoxEXT.TabIndex = 14;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// listBoxSRCadd
			// 
			this.listBoxSRCadd.FormattingEnabled = true;
			this.listBoxSRCadd.Location = new System.Drawing.Point(123, 49);
			this.listBoxSRCadd.Name = "listBoxSRCadd";
			this.listBoxSRCadd.Size = new System.Drawing.Size(411, 56);
			this.listBoxSRCadd.TabIndex = 6;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(536, 49);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 20);
			this.button2.TabIndex = 7;
			this.button2.Text = "Sélectionner";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 23);
			this.label3.TabIndex = 15;
			this.label3.Text = "Fichier en sortie";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(536, 85);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 20);
			this.button3.TabIndex = 8;
			this.button3.Text = "Effacer";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// checkBoxSQLite
			// 
			this.checkBoxSQLite.ForeColor = System.Drawing.Color.Red;
			this.checkBoxSQLite.Location = new System.Drawing.Point(106, 13);
			this.checkBoxSQLite.Name = "checkBoxSQLite";
			this.checkBoxSQLite.Size = new System.Drawing.Size(175, 24);
			this.checkBoxSQLite.TabIndex = 10;
			this.checkBoxSQLite.Text = "Ajouter les fichiers pour SQLite";
			this.checkBoxSQLite.UseVisualStyleBackColor = true;
			// 
			// checkBoxEsqlOC
			// 
			this.checkBoxEsqlOC.ForeColor = System.Drawing.Color.Red;
			this.checkBoxEsqlOC.Location = new System.Drawing.Point(368, 13);
			this.checkBoxEsqlOC.Name = "checkBoxEsqlOC";
			this.checkBoxEsqlOC.Size = new System.Drawing.Size(145, 24);
			this.checkBoxEsqlOC.TabIndex = 11;
			this.checkBoxEsqlOC.Text = "Pré-compilation esqlOC";
			this.checkBoxEsqlOC.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(10, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(187, 23);
			this.label4.TabIndex = 19;
			this.label4.Text = "Resultat de la Pré-compilation";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(10, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "Compiler en";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(10, 194);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(178, 23);
			this.label6.TabIndex = 21;
			this.label6.Text = "Resultat de la Compilation";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(466, 73);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(145, 23);
			this.button4.TabIndex = 18;
			this.button4.Text = "Ouvrir le dossier de sortie";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// groupBoxBDD
			// 
			this.groupBoxBDD.Controls.Add(this.checkBoxSQLite);
			this.groupBoxBDD.Controls.Add(this.checkBoxEsqlOC);
			this.groupBoxBDD.Location = new System.Drawing.Point(12, 133);
			this.groupBoxBDD.Name = "groupBoxBDD";
			this.groupBoxBDD.Size = new System.Drawing.Size(534, 43);
			this.groupBoxBDD.TabIndex = 9;
			this.groupBoxBDD.TabStop = false;
			this.groupBoxBDD.Text = "2 - BASE DE DONNEES";
			// 
			// groupBoxSRC
			// 
			this.groupBoxSRC.Controls.Add(this.label2);
			this.groupBoxSRC.Controls.Add(this.listBoxSRCadd);
			this.groupBoxSRC.Controls.Add(this.button3);
			this.groupBoxSRC.Controls.Add(this.button2);
			this.groupBoxSRC.Controls.Add(this.button1);
			this.groupBoxSRC.Controls.Add(this.label1);
			this.groupBoxSRC.Controls.Add(this.textBoxFicSrc);
			this.groupBoxSRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxSRC.Location = new System.Drawing.Point(12, 12);
			this.groupBoxSRC.Name = "groupBoxSRC";
			this.groupBoxSRC.Size = new System.Drawing.Size(622, 115);
			this.groupBoxSRC.TabIndex = 1;
			this.groupBoxSRC.TabStop = false;
			this.groupBoxSRC.Text = "1 - FICHIERS SOURCE";
			// 
			// groupBoxCOMPIL
			// 
			this.groupBoxCOMPIL.Controls.Add(this.textBoxOUTInfo);
			this.groupBoxCOMPIL.Controls.Add(this.label6);
			this.groupBoxCOMPIL.Controls.Add(this.button4);
			this.groupBoxCOMPIL.Controls.Add(this.label4);
			this.groupBoxCOMPIL.Controls.Add(this.textBoxPreCompil);
			this.groupBoxCOMPIL.Controls.Add(this.label5);
			this.groupBoxCOMPIL.Controls.Add(this.comboBoxEXT);
			this.groupBoxCOMPIL.Controls.Add(this.label3);
			this.groupBoxCOMPIL.Controls.Add(this.textBoxFicSor);
			this.groupBoxCOMPIL.Controls.Add(this.buttonCompiler);
			this.groupBoxCOMPIL.Location = new System.Drawing.Point(12, 182);
			this.groupBoxCOMPIL.Name = "groupBoxCOMPIL";
			this.groupBoxCOMPIL.Size = new System.Drawing.Size(622, 324);
			this.groupBoxCOMPIL.TabIndex = 12;
			this.groupBoxCOMPIL.TabStop = false;
			this.groupBoxCOMPIL.Text = "3 - COMPILATION";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 517);
			this.Controls.Add(this.groupBoxBDD);
			this.Controls.Add(this.groupBoxSRC);
			this.Controls.Add(this.groupBoxCOMPIL);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "CompilateurCobol";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBoxBDD.ResumeLayout(false);
			this.groupBoxSRC.ResumeLayout(false);
			this.groupBoxSRC.PerformLayout();
			this.groupBoxCOMPIL.ResumeLayout(false);
			this.groupBoxCOMPIL.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
